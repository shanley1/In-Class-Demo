<Query Kind="Expression">
  <Connection>
    <ID>efcdf5e6-d253-4020-bd51-30d48d8628a1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from eachRow in SpecialEvents
where eachRow.Active
select new // ActiveEvent()
{
	Code = eachRow.EventCode, 
	Description = eachRow.Description
}

