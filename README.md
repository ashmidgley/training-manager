# Lift Manager

## Setup
1. Connect to localhost in Sql Server Management Studio
2. Create new Database named LiftManager with default settings
3. Add new login with the below credentials:
```
Username 'liftmanager'
Password 'Password1!'
```
4. Add user mapping to LiftManager Database with db_owner priveleges
5. Open solution in Visual Studio
6. Open Package Manager Console prompt in Visual Studio
7. In project drop down select 'LiftManager'
8. Type the below command then press enter:
```
Update-Database
```
9. You should see a full list of migrations running against your newly created Database

Once setup complete, run the application using IISExpress in Visual Studio.

Happy lifting meatheads :+1:
