Company Management System API Project: 
The purpose of this project is to create a data management system using SQL database tables for personnel, including employees and managers, and their departments.  
Companies can use this application as a tool for retrieving and organizing data.  Users will be able to insert data into the database tables, modify the data within 
them, and delete data that is no longer needed.

Employee Table: 
The purpose of this table is to provide data about each employee.  The table will include the employee’s id number, first and last name, the date the employee was 
hired, the employee’s email address, the manager that is assigned to the employee, the department the employee works in, and the employee’s hourly rate.  

Manager Table: 
The purpose of this table is to provide data about each manager.  It includes the manager’s id, first and last name, the department the manager works in, the date 
the manager was hired, the email address, the list and number of employees for each manager, and the manager’s salary.  

Department Table:
The purpose of this table is to provide data about each department.  It includes the department’s id number, name, and list of personnel.  

Personnel Table: 
The purpose of this table is to provide data that both the manager and employee will inherit from.  These properties include the id, first and last name, department
id number as a foreign key, hire date, and email address.  
