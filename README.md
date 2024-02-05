This project is dedicated to the RTT Aywaille club.

This will allow the possibility of managing customers to the "Wine Fair" that the club organizes each year.

Technologies :
	- Import data from an Excel file to search after customer who have already visited the "Wine Faire" in recent years ;
	- Add a customer to the raffle by clicking him in the list ;
	- Create a new customer to add him in the Excel file directly ;
	- Edit a existing customer to update their information ;

Versions : 

V1 :
	This first version will allow importing data from an Excel file containing the customers of the Aywaille Wine Fair.

	Moreover:
		- We can search for a customer by last name, first name and email;
		- We can encode new customers in another file with new customers;
		- We can encode customers to add them to the raffle in a new excel file;
		- You can encode an existing client to edit it in a new excel file;

	These Excel files will be stored in the path: “C:/FoireDuVin2024/”.

V2 : 
	This second version will allow importing data from an Excel file containing the customers of the Aywaille Wine Fair.

	Update of the first version:
		- You must import an excel file before adding a new customer. Like this, this one can be added to the excel file directly ;
		- Two types of file will be stored to the path “C:/FoireDuVin2024/”, and it is the raffle ;
		- The edit technology is going to update the customer in the imported file (NOT DONE!)

V3 :
	This third version is 100% compatible for less than 200 data, because the Excel library is limited to 200 rows to write.
	Over than this limit, he deletes all perhaps the first 200.
	For a big event, it's impossible to keep.

	So the creation and the update of a customer is directly in the file imported

V4 :
	This fourth version is one of the definitve version. All the first Users Stories are done and functionnal.
	