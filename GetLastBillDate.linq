<Query Kind="Expression">
  <Connection>
    <ID>efcdf5e6-d253-4020-bd51-30d48d8628a1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//from row in Bills
//orderby row.BillDate descending
//select row.BillDate

Bills.Max(row => row.BillDate)
//^ Among the bills, get the max (largest) row for billdate