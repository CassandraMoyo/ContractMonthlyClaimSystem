---Contract Monthly Claim System
This project is designed to manage user registration, login, and claim submission within a contract-based work environment.

---Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or use in memory database

---Clone the repository:
 -git clone https://github.com/yourusername/ContractMonthlyClaimSystem.git

---Usage

- Navigate to `ContractMonthlyClaimSystem` to access the application.
- Register a new user, edit personal details, and log in with registered credentials.
- Use different roles to navigate through various functionalities (Independent Contractor, Program Coordinator, Academic Manager).
- Submit a cliam if you are a Independent Contractor
- Verify a claim if you are a Program Coordinator
- Approve a claim  if you are a Academic Manager

*Code Overview*
--Models

- Registered: Represents the user entity with properties like RegID, Name, Surname, Contact, Address, Email, Password, and Role.
- Claims: Represents the claim entity with properties like ClaimID, qualification, module,  group,  date,  hours work,  rate, file
- Verification: Represents the the list of claims that must be verified by theProgram Coordinator entity with properties from the Registered  and Claims.
- Approval: Represents the the list of claims that must be approve by the Academic Manager entity with properties from the Registered ,Claims, and Verification.

--Controllers
- HomeController: Manages registration and login.
- UsersController: Manages user-related actions such as registration, login, and editing personal details.
- ClaimsController: Manages claim-related actions such as claim submission, view, and editing claim details.
- VerificationController: Manages claim verification-related actions such as verify, deny.
- ApprovalController: Manages calim approval-related actions such as the final approval of claim.

--Views
- Index: landing page with  HTML form for user registration or login.
- Register: HTML form for user registration.
- Login: HTML form for user login.
- EditPersonalDetails: HTML form for editing user personal details.
- Claim: HTML table for Independent Contractors to view and edit Claims.
- ViewClaims: HTML table for Independent Contractor to view or edit claims.
- VerifyClaim: HTML table for  Program Coordinator to view ,verify or deny Claims.
- ApproveClaim: HTML table for  Academic Manage finalize claims approvals.
