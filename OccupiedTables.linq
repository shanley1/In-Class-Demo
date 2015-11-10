<Query Kind="Statements">
  <Connection>
    <ID>efcdf5e6-d253-4020-bd51-30d48d8628a1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Find out information on the tables in the restaurant at a specific 
var date = Bills.Max(b => b.BillDate).Date;
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0,30,0));
date.Add(time).Dump("The test data/time I am using");

// Step 1 - Get the table info along with any walk-in bills and reservation bills for a specific time slot.
var step1 = from data in Tables 
			select new 
			{
				Table = data.TableNumber, 
				Seating = data.Capacity,
				//This sub-query gets the bills for walk-in customers.
				WalkIns = from walkIn in data.Bills
						  where walkIn.BillDate.Year == date.Year
						  	&& walkIn.BillDate.Month == date.Month
						  	&& walkIn.BillDate.Day== date.Day
							// if the walk-in has NOT paid, they are still there || if the walk-in has paid but is still sitting there.
							&& (!walkIn.OrderPaid.HasValue || walkIn.OrderPaid.Value >= time)														
						  select walkIn,
						  
				// This sub-query gets the bills from reservations
				Reservations = from booking in data.ReservationTables
							   from reservationParty in booking.Reservation.Bills
							   where reservationParty.BillDate.Year == date.Year
							   	  && reservationParty.BillDate.Month == date.Month
						  		  && reservationParty.BillDate.Day== date.Day
								  && (!reservationParty.OrderPaid.HasValue || reservationParty.OrderPaid.Value >= time)
							   select reservationParty
			};
step1.Dump("Results of Step 1");

// Step 2 - Union the walk-in bills and the reservation bills while extraction the relevent bill info.
// 			.ToList() helps resolve the error
//			"Types in Union or Concat are constructed incompatibly"
var step2 = from data in step1.ToList()
			select new 
			{
				Table = data.Table,
				Seating = data.Seating,
				CommonBilling = from info in (data.WalkIns.Union(data.Reservations))
								select new // trimmed down billing info
								{
									BillID = info.BillID,
									BillTotal = info.BillItems.Sum(bi => bi.Quantity * bi.SalePrice),
									Waiter = info.Waiter.FirstName,
									Reservation = info.Reservation
								}
			};
step2.Dump("Results of Step 2");			

// Step 3 - Get just the CommonBilling item
// 			(presumes no overlaps can occur - i.e., two groups at the same table at the same time)
var step3 = from data in step2.ToList()
			select new 
			{
				Table = data.Table,
				Seating =  data.Seating,
				//Checks count of members seated. If > 0 then its True (people are seated at the table).
				Taken = data.CommonBilling.Count() > 0,
				//.FirstOrDefault() is effectively "Flattening" my collection of 1 item into a single object whose
				// properties I can get in step 4 using the dot (.) operator
				CommonBilling = data.CommonBilling.FirstOrDefault()
			};
step3.Dump("Results of Step 3");			

// step4 - Build our intanded seating summary info.
var step4 = from data in step3 
			select new // SeatingSummary() // the DTO class to use in my BLL
			{
				Table  = data.Table,
				Seating = data.Seating,
				Taken = data.Taken, 
				//use a ternary expression to conditionally get the BillID (if it exists)
				BillID = data.Taken ?				// if (data.Taken)
						 data.CommonBilling.BillID	// value to use if true
					   : (int?) null,				// value to use if false
				BillTotal = data.Taken ? 
							data.CommonBilling.BillTotal : (decimal?) null,
				Waiter = data.Taken ? data.CommonBilling.Waiter : (string) null,
				ReservationName = data.Taken ? 
								  (data.CommonBilling.Reservation != null ?
								   data.CommonBilling.Reservation.CustomerName : (string) null) : (string) null								
			};
step4.Dump("The final, boiled-down list of table occupancy at a point in time");			