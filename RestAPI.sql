--CREATE DATABASE CMS

USE CMS

GO

--Medicine details table
CREATE TABLE medicine_details(
medicine_id INT PRIMARY KEY IDENTITY,
medicine_name VARCHAR(100) NOT NULL,
medicine_quantity INT NOT NULL,
medicine_price INT NOT NULL,
[expiry_date] DATE NOT NULL,
manufacturing_date DATE NOT NULL
);

--Test details
CREATE TABLE test_details(
test_id INT PRIMARY KEY IDENTITY,
test_name VARCHAR(100) NOT NULL,
maximum_value INT NOT NULL,
minimum_value INT NOT NULL,
normal_value INT NOT NULL,
test_amount INT NOT NULL
);

--Patient
CREATE TABLE patients(
patient_id INT PRIMARY KEY IDENTITY,
patient_name VARCHAR(100) NOT NULL,
patient_phone VARCHAR(20) NOT NULL,
patient_location VARCHAR(50) NOT NULL,
patient_weight INT NOT NULL,
patient_gender VARCHAR(15) NOT NULL,
patient_blood VARCHAR(5) NOT NULL,
patient_dob DATE NOT NULL
);


--Role
CREATE TABLE roles(
role_id INT PRIMARY KEY IDENTITY,
role_name VARCHAR(50) NOT NULL
);

--Vitals
CREATE TABLE vitals(
vital_id INT PRIMARY KEY IDENTITY,
blood_pressure INT NOT NULL,
pulse_rate INT NOT NULL,
body_temp INT NOT NULL,
breath_rate INT NOT NULL,
vital_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id)
);

--Payment
CREATE TABLE payments(
payment_id INT PRIMARY KEY IDENTITY,
payment_mode VARCHAR(20) NOT NULL,
transaction_number INT NOT NULL,
payments_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id)
);

--Units
CREATE TABLE units(
unit_id INT PRIMARY KEY IDENTITY,
test_unit VARCHAR(10) NOT NULL,
test_id INT FOREIGN KEY REFERENCES test_details(test_id)
);

--Staff
CREATE TABLE staffs(
staff_id INT PRIMARY KEY IDENTITY,
staff_name VARCHAR(50) NOT NULL,
staff_phone VARCHAR(20) NOT NULL,
staff_address VARCHAR(50) NOT NULL,
staff_email VARCHAR(20) NOT NULL,
staff_dob DATE NOT NULL,
staff_joining_date DATE NOT NULL
);

--Qualification
CREATE TABLE qualifications(
qualification_id INT PRIMARY KEY IDENTITY,
qualification_name VARCHAR(50) NOT NULL,
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Authentication
CREATE TABLE authentications(
[user_id] INT PRIMARY KEY IDENTITY,
[user_name] VARCHAR(50) NOT NULL,
[password] VARCHAR(50) NOT NULL,
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Consultation Bills
CREATE TABLE consultation_bills(
consultation_bill_id INT PRIMARY KEY IDENTITY,
consultation_date_time DATETIME NOT NULL,
consultation_amount INT NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Token
CREATE TABLE tokens(
token_id INT PRIMARY KEY IDENTITY,
token_num TINYINT NOT NULL,
token_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Prescribed medicine
CREATE TABLE prescribed_medicines(
prescription_id INT PRIMARY KEY IDENTITY,
prescription_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Test Report
CREATE TABLE test_reports(
report_id INT PRIMARY KEY IDENTITY,
patient_value INT NOT NULL,
patient_name VARCHAR(50) NOT NULL,
report_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
test_id INT FOREIGN KEY REFERENCES test_details(test_id)
);

--Test advice
CREATE TABLE test_advices(
advice_id INT PRIMARY KEY IDENTITY,
test_name VARCHAR(50) NOT NULL,
test_advice_date_time DATETIME NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);

--Test list
CREATE TABLE test_lists(
test_list_id INT PRIMARY KEY IDENTITY,
test_name VARCHAR(50) NOT NULL,
test_amount INT NOT NULL,
advice_id INT FOREIGN KEY REFERENCES test_advices(advice_id),
test_id INT FOREIGN KEY REFERENCES test_details(test_id)
);

--Lab Billing
CREATE TABLE lab_bills(
lab_bill_id INT PRIMARY KEY IDENTITY,
lab_bill_date_time DATETIME NOT NULL,
test_name VARCHAR(50) NOT NULL,
lab_bill_amount INT NOT NULL,
test_list_id INT FOREIGN KEY REFERENCES test_lists(test_list_id),
patient_id INT FOREIGN KEY REFERENCES patients(patient_id)
);

--Manufacture
CREATE TABLE manufactures(
manufacture_id INT PRIMARY KEY IDENTITY,
manufacture_name VARCHAR(50) NOT NULL,
manufacture_email VARCHAR(20) NOT NULL,
manufacture_phone VARCHAR(20) NOT NULL,
manufacture_address VARCHAR(50) NOT NULL
);

--Medicine Inventory
CREATE TABLE medicine_inventories(
inventory_id INT PRIMARY KEY IDENTITY,
medicine_name VARCHAR(20) NOT NULL,
medicine_type VARCHAR(20) NOT NULL,
medicine_quantity INT NOT NULL,
medicine_id INT FOREIGN KEY REFERENCES medicine_details(medicine_id),
manufacture_id INT FOREIGN KEY REFERENCES manufactures(manufacture_id)
);

--Medicine Bill
CREATE TABLE medicine_bills(
medicine_bill_id INT PRIMARY KEY IDENTITY,
medicine_bill_date_time DATETIME NOT NULL,
medicine_quantity INT NOT NULL,
medicine_amount INT NOT NULL,
medicine_name VARCHAR(20) NOT NULL,
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
inventory_id INT FOREIGN KEY REFERENCES medicine_inventories(inventory_id),
prescription_id INT FOREIGN KEY REFERENCES prescribed_medicines(prescription_id)
);

--Medicine List
CREATE TABLE medicine_lists(
medicine_list_id INT PRIMARY KEY IDENTITY,
medicine_name VARCHAR(20) NOT NULL,
dosage INT NOT NULL,
duration INT NOT NULL,
medicine_id INT FOREIGN KEY REFERENCES medicine_details(medicine_id),
prescription_id INT FOREIGN KEY REFERENCES prescribed_medicines(prescription_id)
);

--Medical History
CREATE TABLE medical_history(
medical_list_id INT PRIMARY KEY IDENTITY,
old_data VARCHAR(20),
new_data VARCHAR(20),
patient_id INT FOREIGN KEY REFERENCES patients(patient_id),
staff_id INT FOREIGN KEY REFERENCES staffs(staff_id)
);