create database crime;

use crime

CREATE TABLE Crime (
 CrimeID INT PRIMARY KEY,
 IncidentType VARCHAR(255),
 IncidentDate DATE,
 [Location] VARCHAR(255),
 [Description] TEXT,
 [Status] VARCHAR(20)
);
CREATE TABLE Victim (
 VictimID INT PRIMARY KEY,
 CrimeID INT,
 [Name] VARCHAR(255),
 ContactInfo VARCHAR(255),
 Injuries VARCHAR(255),
 FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);
CREATE TABLE Suspect (
 SuspectID INT PRIMARY KEY,
 CrimeID INT,
 [Name] VARCHAR(255),
 [Description] TEXT,
 CriminalHistory TEXT,
 FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);

INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Location, Description, Status)
VALUES
 (1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
 (2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'Under Investigation'),
 (3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed')

 insert into Crime values  (3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed')

 insert into Crime values   (4, 'Theft', '2023-09-11', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'open')
  insert into Crime values(5, 'Robbery', '2023-09-20', '123 Main St, Cityville', 'Unarmed Robbery', 'Open')
   insert into Crime values   (6, 'Theft', '2023-09-26', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'open')


   delete from Crime where IncidentType='Theft'

   select * from Victim

 INSERT INTO Victim (VictimID, CrimeID, Name, ContactInfo, Injuries)
VALUES
 (1, 1, 'John Doe', 'johndoe@example.com', 'Minor injuries'),
 (2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased'),
  (3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None');

  insert into Victim  values (3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None',32)


  Insert into Victim values(4,4,'Ajith', 'ajith@gmail.com','Minor injuries',30);

  INSERT INTO Suspect (SuspectID, CrimeID, Name, Description, CriminalHistory)
VALUES
 (1, 1, 'Robber 1', 'Armed and masked robber', 'Previous robbery convictions'),
 (2, 2, 'Unknown', 'Investigation ongoing', NULL),
 (3, 3, 'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests');


 INsert into Suspect values(4,4,'John Doe','Theft in store',NULL);
  INsert into Suspect values(5,5,'John Doe','Theft in Showroom','Theft');


 --1. Select all open incidents.

 select * from Crime where status = 'open'

 --2. Find the total number of incidents.

 select count(CrimeID) from Crime

--3. List all unique incident types.

select distinct  IncidentType  from Crime

--4. Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'.

select * from crime where IncidentDate between '2023-09-01' and '2023-09-10'

--5. List persons involved in incidents in descending order of age.

Select * from Victim 
Order By Age desc

--6. Find the average age of persons involved in incidents.

select avg(age) as [Average age] from Victim 


--7. List incident types and their counts, only for open cases.

select distinct IncidentType, count(incidentType) from Crime where Status='open' 
GROUP BY IncidentType

--8. Find persons with names containing 'Doe'.

select * from Victim where CHARINDEX('doe',Name)>1


--9. Retrieve the names of persons involved in open cases and closed cases.

select Victim.Name from 
Crime join Victim
on Crime.CrimeID= Victim.VictimID
where Crime.Status='open'

--10. List incident types where there are persons aged 30 or 35 involved

SELECT Crime.IncidentType from 
Crime join Victim 
on Crime.CrimeID = Victim.CrimeID
Where Age=30 or Age=35;

.

--11. Find persons involved in incidents of the same type as 'Robbery'.

select Victim.Name from 
Crime join Victim
on Crime.CrimeID= Victim.VictimID
where Crime.IncidentType='Robbery'

--12. List incident types with more than one open case.

select IncidentType from Crime
where status='open'
group By IncidentType
having count(incidentType)>1

--13. List all incidents with suspects whose names also appear as victims in other incidents.

select * from 
Crime join Victim 
on Crime.CrimeID= Victim.CrimeID
where Victim.Name IN (
		SELECT Name from Suspect
		)

--14. Retrieve all incidents along with victim and suspect details.

select * from 
Crime  join Victim
on Crime.CrimeID= Victim.CrimeID
join Suspect 
on Victim.crimeID = Suspect.CrimeID

--15. Find incidents where the suspect is older than any victim.

select * from  Suspect
select * from Victim

Select c.CrimeID,c.IncidentType,c.IncidentDate,s.name from
Crime c join Victim v 
on c.CrimeID= v.CrimeID
join Suspect s 
on V.CrimeID=s.CrimeID
GROUP BY c.CrimeID,c.IncidentType,c.IncidentDate,s.Name,v.age,s.age
Having s.age> any (select age from victim)



--16. Find suspects involved in multiple incidents:


Select Name from Suspect 
group By Name
Having COUNT(Name)>1

--17. List incidents with no suspects involved.

SELECT c.*
FROM Crime c
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE s.SuspectID IS NULL;


--18. List all cases where at least one incident is of type 'Homicide' and all other incidents are of type  'Robbery'.

Select Crime.CrimeID,Crime.IncidentType from
Crime join Victim
on Crime.CrimeID= Victim.CrimeID
GROUP By Crime.CrimeID,Crime.IncidentType
Having 
Sum(CASE when Crime.IncidentType='Homicide' Then 1 else 0 END)>=1
OR
Count(*) = (SELECT COUNT(*) from Crime where IncidentType='Robbery')-1;

select * from Crime
select * from Victim

--Crime.IncidentType='Robbery'

--SUM(CASE when Crime.Incidenttype = 'Robbery' THEN 1 else 0 END)= Count(*)-(Select count(*) from Crime where IncidentType='Homicide')

		select * from Crime


--19. Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or 'No Suspect' if there are none.

SELECT c.CrimeID,ISNULL(s.Name, 'NO SUSPECT') AS SuspectName,c.IncidentType
FROM 
Crime c LEFT JOIN Suspect s 
ON c.CrimeID = s.CrimeID
GROUP BY  c.CrimeID, ISNULL(s.Name, 'NO SUSPECT'),c.IncidentType;


select * from Crime
select * from Suspect

--20. List all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'

SELECT s.Name,C.CrimeID
FROM 
Crime c JOIN Suspect s 
ON c.CrimeID = s.CrimeID
GROUP BY s.Name,c.IncidentType,c.CrimeID
having c.IncidentType='Robbery' OR c.IncidentType='Assault'

