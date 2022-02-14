USE [CMS]
GO

INSERT INTO [dbo].[roles]
           ([role_name])
     VALUES
           ('Receptionist'),
           ('Doctor'),
           ('Pharmacist'),
           ('Lab Technician'),
           ('Administrator')

GO


INSERT INTO [dbo].[manufactures]
           ([manufacture_name]
           ,[manufacture_email]
           ,[manufacture_phone]
           ,[manufacture_address])
     VALUES
           ('AAA Ezee Soulnature Healthcare',
		   'soulnature@gmail.com',
		   '919811053751',
		   'New Delhi'),
		   ('Aarogya Herbals',
		   'herbals@herbalsaarogya.com',
		   '6328534',
		   'New Delhi'),
		   ('Aash Biotech Pvt Ltd',
		   'info@aashbiotech.com',
		   '917940039970',
		   'Ahmedabad'),
		   ('Accent Microcell Industries',
		   'accentmicrocell@gmail.com',
		   '917926579633',
		   'Ahmedabad'),
		   ('Accure Labs Pvt. Ltd.',
		   'siddharth@accurelabs.com',
		   '9111 41037221',
		   'New Delhi'),
		   ('Admit Pharmaceuticals Pvt.Ltd.',
		   'marketing@admitpharma.co.in',
		   '02812464018',
		   'Gujarat'),
		   ('Airpack Exports',
		   'airpac@vsnl.com',
		   '91-22- 5691 2900',
		   'Mumbai'),
		   ('Alkem Laboratories Ltd',
		   'maitra@alkem.com',
		   ' 91 22 24952851/2',
		   'Mumbai'),
		   ('ALLERGAN INDIA LIMITED',
		   'allergan@vsnl.com',
		   '91-80-229-9125',
		   'Bangalore '),
		   ('ALPHA ORGANICS PVT. LTD',
		   'ngl@bom3.vsnl.net.in',
		   '91-22-834 6659',
		   'Mumbai')

GO



INSERT INTO [dbo].[staffs]
           ([staff_name]
           ,[staff_phone]
           ,[staff_address]
           ,[staff_email]
           ,[staff_dob]
           ,[staff_joining_date])
     VALUES
           ('Alfina',
           '6238723485',
           'Kollam',
           'alfina@gmail.com',
           '1999-11-05',
           '2021-12-08'),
		   ('Arshin',
           '9496997346',
           'Kannur',
           'arshin@gmail.com',
           '1997-07-17',
           '2021-12-01'),
		    ('Binitha',
           '8281076718',
           'TVM',
           'Binitha@gmail.com',
           '1997-11-13',
           '2021-12-20'),
		    ('Gazni',
           '8848698338',
           'Ernakulam',
           'gazni@gmail.com',
           '1999-03-26',
           '2021-12-01'),
		    ('Anns',
           '9496997123',
           'Kannur',
           'anns@gmail.com',
           '1997-12-21',
           '2021-12-21'),
		    ('Aparna',
           '7306997346',
           'Ernakulam',
           'aparna@gmail.com',
           '2000-03-17',
           '2021-12-12'),
		    ('Job',
           '7706997346',
           'Bangalore',
           'job@gmail.com',
           '1998-07-28',
           '2021-11-01'),
		    ('Hari',
           '6256997126',
           'Kasargod',
           'hari@gmail.com',
           '1996-01-17',
           '2021-12-09'),
		    ('Regan',
           '9496123346',
           'Kannur',
           'regan@gmail.com',
           '1994-07-17',
           '2020-12-01'),
		    ('Achu',
           '9496127346',
           'Kannur',
           'achu@gmail.com',
           '1992-10-27',
           '2019-1-1')
GO



INSERT INTO [dbo].[patients]
           ([patient_name]
           ,[patient_phone]
           ,[patient_location]
           ,[patient_weight]
           ,[patient_gender]
           ,[patient_blood]
           ,[patient_dob])
     VALUES
           ('Adams Irene'
           ,9678563423
           ,'New York'
           ,58
           ,'Male'
           ,'B+'
           ,'1975-06-02'),
		   ('Carl Adolfson'
           ,9678563478
           ,'California'
           ,90
           ,'Male'
           ,'B-'
           ,'1980-08-02'),
		   ('Massa Albert'
           ,7878563423
           ,'New York'
           ,60
           ,'Female'
           ,'A+'
           ,'1990-10-23'),
		   ('Hazel Georgia'
           ,5678563423
           ,'Alaska'
           ,50
           ,'Female'
           ,'AB+'
           ,'1995-02-06'),
		   ('Emma Watson'
           ,3458563423
           ,'Alabama'
           ,63
           ,'Female'
           ,'O+'
           ,'1990-06-22'),
		   ('Harvey Anderson'
           ,9677863423
           ,'Colorado'
           ,67
           ,'Male'
           ,'B+'
           ,'1997-12-02'),
		   ('Kenneth Lewis'
           ,3456563423
           ,'Florida'
           ,25
           ,'Male'
           ,'AB+'
           ,'2016-06-02'),
		   ('Daisey Henry'
           ,3338563423
           ,'Ohio'
           ,38
           ,'Female'
           ,'A+'
           ,'2003-05-22'),
		   ('Viola Janosky'
           ,2318563423
           ,'Texas'
           ,100
           ,'Female'
           ,'B+'
           ,'1965-12-12'),
		   ('William Rodlin'
           ,1278563423
           ,'Virginia'
           ,78
           ,'Male'
           ,'A-'
           ,'1998-03-02');
GO


INSERT INTO [dbo].[medicine_details]
           ([medicine_name]
           ,[medicine_quantity]
           ,[medicine_price]
           ,[expiry_date]
           ,[manufacturing_date])
     VALUES
           ('Azithromycin'
           ,250
           ,71
           ,'2022-12-10'
           ,'2018-12-10'),
		   ('Paracetamol 500mg'
           ,500
           ,71
           ,'2027-11-18'
           ,'2022-11-10'),
		   ('Mometasone furoate'
           ,200
           ,123
           ,'2022-12-10'
           ,'2018-12-10'),
		   ('Melalumin'
           ,230
           ,180
           ,'2023-03-10'
           ,'2018-12-10'),
		   ('Vitamin C tablets'
           ,300
           ,55
           ,'2022-12-10'
           ,'2018-12-10'),
		   ('Vitamin B Complex'
           ,220
           ,45
           ,'2022-10-10'
           ,'2021-12-10'),
		   ('Ferrous Sulphate'
           ,150
           ,71
           ,'2022-12-10'
           ,'2018-12-10'),
		   ('Amorolfine'
           ,210
           ,400
           ,'2025-04-10'
           ,'2019-12-10'),
		   ('Lignocaine Hydhrochloride gel'
           ,212
           ,79
           ,'2024-12-10'
           ,'2021-08-17'),
		   ('Docosanol'
           ,150
           ,65
           ,'2026-09-16'
           ,'2021-06-10'),
		   ('Ibuprofen'
           ,120
           ,100
           ,'2023-06-16'
           ,'2018-12-10'),
		   ('Ketoprofen'
           ,130
           ,59
           ,'2024-07-11'
           ,'2019-12-10'),
		   ('Azithral'
           ,119
           ,100
           ,'2024-02-24'
           ,'2021-02-10'),
		   ('Augmentin'
           ,212
           ,201
           ,'2021-12-10'
           ,'2019-01-05');


GO

INSERT INTO [dbo].[test_details]
           ([test_name]
           ,[maximum_value]
           ,[minimum_value]
           ,[test_amount])
     VALUES
           ('Ammonia',
		   50,
		   15,
		   200),
		   ('Ceruloplasmin',
		   60,
		   15,
		   250),
		   ('Chloride',
		   105,
		   95,
		   300),
		   ('Copper',
		   150,
		   75,
		   300),
		    ('Aminolevulinic acid, Delta (ALA)',
		   23,
		   15,
		   350),
		   ('Blood urea nitrogen',
		   21,
		   8,
		   150),
		   ('Ferritin',
		   300,
		   12,
		   350),
		   ('Glucose',
		   110,
		   65,
		   400),
		   ('Activated partial thromboplastin time (aPTT)',
		   40,
		   30,
		   400),
		   ('Activated partial thromboplastin time (aPTT)',
		   150,
		   36,
		   400)

		   

GO


