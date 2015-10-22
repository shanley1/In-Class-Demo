<Query Kind="Expression">
  <Connection>
    <ID>efcdf5e6-d253-4020-bd51-30d48d8628a1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from eachRow in Reservations
where eachRow.ReservationStatus == 'B' //use "B" in Visual Studio
		// TBA -- && eachRowhas the correct EventCode...
orderby eachRow.ReservationDate
//select eachRow
group eachRow by new { eachRow.ReservationDate.Month,eachRow.ReservationDate.Day }
into dailyReservation
select new // DailyReservation() // Create a class called DailyReservation
{
	Month = dailyReservation.Key.Month,
	Day = dailyReservation.Key.Day,
	Reservations = from booking in dailyReservation
				   select new // Booking() // Create a Booking DTO class
				   {
				   		Name = booking.CustomerName, 
						Time = booking.ReservationDate.TimeofDay,
						NumberInParty = booking.NumberInParty,
						Phone = booking.ContactPhone,
						Event = booking.SpecialEvents.Description 
				   }
}