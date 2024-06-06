# CVLookup (Self-project)
### Description
  - CVLookup is a website that will connect the Employers with the Candidates
  - The candidates can use it for finding the jobs that they want or consistent with them
  - The Employers can use it for finding candidates that suitable for there company
  - CVLoopup Web-API is provides Restful API service for CVLookup Website base on C#, ASP.NET core, ASP.NET WebAPI
### Technology
  - Front-End: Javascript, ReactJs, Redux Toolkit, CSS, Bootstrap
  - Back-End: C#, ASP.NET core 6, ASP.NET WebAPI
  - Database: MS SQL Server
### Swagger UI
  ![Image 1](https://drive.google.com/uc?export=view&id=1sy3HRWSTZyoFWYqOfC_ey1ym3G6UVOCZ)
  ![Image 1](https://drive.google.com/uc?export=view&id=1cjR5etwhkDq1fUD17wqzllTVV1LY78ea)
### Main Funtions
  > ### Authentication
  > - Must using the **REAL** email to receive active link
  > - Using JWT for authorize

  > ### Admin
  > - **Employer Management**
  > 
  > - **Candidate Management**
  > 
  > - **Account Management**
  > 
  > - **Account - User Management** :notebook_with_decorative_cover:*[*note: manage which account belong to user]*
  > 
  > - **Curriculum Vitae Management**
  > 
  > - **Experience Management**
  > 
  > - **Job Address Management**
  > 
  > - **Job Career Management**
  > 
  > - **Job Field Management**
  > 
  > - **Job Form Management**
  > 
  > - **Job Position Management**
  > 
  > - **Notification Management**
  > 
  > - **Recruitment Management**
  > 
  > - **Recruitment - CV Management** :notebook_with_decorative_cover:*[*note: manage which cv applied to recruitment]*
  > 
  > - **Role Management**
  > 
  > - **User - Role Management** :notebook_with_decorative_cover:*[*note: manage which role belong to user]*
  > 
  
  > ### Employers
  > - **Manage Account**
  > - **Manage Recruitment**
  > - **Manage CV applied to Recruitment (Reject/Accept)**
  > - **Post Recruitments to find Candidates**
  > - **Receive Notification**

  > ### Candidates
  > - **Manage Account**
  > - **Manage CV**
  > - **Finding Job**
  > - **Apply CV for Job**
  > - **Receive Notification**

  > ### Guest
  > - **Finding Job**
### HOW TO RUN
  > - **CVLookup-WebAPI**
  >   - Install .NET 6 from [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
  >   - Clone project from github:```git clone https://github.com/minhthuan26/CVLookup-WebAPI.git```
  >   - Open project on Visual Studio _[_**If you don't have it, please install: [Visual Studio](https://visualstudio.microsoft.com/)]*
  >   - Change the information in ```lauchSettings.json``` and ```appSettings.json``` if you need
  >   - Press ```Ctrl + F5``` to run

  > - **CVLookup-UI**
  >   - Install NodeJs from [NodeJs](https://nodejs.org/en/download/prebuilt-installer)
  >   - Install Visual Studio Code from [Visual Studio Code](https://code.visualstudio.com/)
  >   - Clone project from github:```git clone https://github.com/minhthuan26/CVLookup-UI.git```
  >   - Open project on Visual Studio Code
  >   - Press ```Ctrl + J``` to open terminal then enter the command ```npm i``` to download dependencies
  >   - Enter the command ```npm start``` to run
