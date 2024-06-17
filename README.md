<h1 align="center">
  🥐 Pierre's Treats 🥐
</h1>
<p align="center">
  Bakery storefront powered by ASP.NET<br />
  <a href="https://pierrestreats.onrender.com/" target="_blank">View the Site</a>
</p>

## ❔ Description
This project utilizes ASP.NET to allow a shop owner to keep an inventory of "treats" and flavors that they are available in. The project is built in a many-to-many relationship format using EF Core and has full CRUD (Create, Read, Update, Delete) functionality on entities. 
Additionally, unauthenticated users (customers) can only Read items and can't perform Create, Update, or Delete functions on them.

Features:
* Allows authenticated users full CRUD of treats and flavors.
* Allows authenticated users to assign a flavor to any number of treats.
* Allows authenticated users to assign an treat to any number of flavors.
* Allows unauthenticated users to view all treats and flavors.


## 💻 Technologies Used

* [C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET / MVC](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)
* [Entity Framework / EFCore](https://learn.microsoft.com/en-us/ef/core/)
* [ASP.NET Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
* [MySQL](https://www.mysql.com/)
* [Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/)


## 🔧 Setup / Installation Steps

### 1 - Setup/Installation Prerequisite Requirements
This section will cover how to install the .NET SDK and MySQL Community Server. If you already have these applications installed and running at at least version 8.0, proceed to the section [Project Setup Requirements](#2---project-setup-requirements) section below.

#### Prerequisite A: .NET SDK Installation

###### Step 1: Download .NET SDK
* Download the .NET 6 SDK (Software Development Kit). To view all download options for the .NET 6 SDK, visit this page. Or, click on any of the following links for an immediate download from Microsoft:

  For [Windows](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-windows-x64-installer)

  For [Macs with Apple Chip](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-arm64-installer)

  For [Macs with Intel Chip](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.402-macos-x64-installer)


###### Step 2: Install the SDK
* Open the file. This will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.


###### Step 3: Test Installation
* Confirm the installation is successful. First, restart your command line shell (Terminal or GitBash) if it's already open, and then run the command "dotnet --version" (without quotes). You should see a version number as a response.


#### Prerequisite B: MySQL Community Server

##### MacOS Instructions:

###### MacOS Step 1: Download the MySQL Community Server Installer
* Start by downloading the MySQL Community Server .dmg file from the MySQL Community Server page:

  For [Catalina and above, AND an M2 chip](https://dev.mysql.com/downloads/file/?id=518602)

  For [Catalina and above, AND an M1 chip](https://dev.mysql.com/downloads/file/?id=508094)

  For [Catalina and above, AND an Intel chip](https://dev.mysql.com/downloads/file/?id=508095)

  For [High Sierra or Mojave](https://dev.mysql.com/downloads/file/?id=484914)


###### MacOS Step 2: Install MySQL Community Server
* Launch the installer. Accept all prompts until you reach the Configuration page. Once you've reached Configuration, select or set the following options (use default if not specified):

  * Use Legacy Password Encryption.
  * Set password to a password of your choosing. This password will become necessary later for project setup.
  * Select "Finish".


###### MacOS Step 3: Configure Environment Variables
* Open the terminal to set your environment variables using either of the following commands. When finished, close all terminal windows.

  * For bash users:
    ```bash
    echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile
    ```

  * For zsh users:
    ```bash
    echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.zshrc
    ```


###### MacOS Step 4: Test Installation (MySQL Community Server)
* From a new terminal window, attempt to login to mysql to confirm it is configured properly.
  Substitue "YOUR_PASSWORD_HERE" for the password you set during installation.

  ```bash
  mysql -uroot -pYOUR_PASSWORD_HERE
  ```
  There will be an intro message, and the prompt should change to: `mysql> `. This confirms that mysql is installed and everything is working as expected.
  If you instead receive a `mysql: command not found` error, attempt to uninstall any versions of the applications that are previously installed, then follow this installation guide again.


##### Windows 10/11 Instructions:

###### Windows Step 1: Download the MySQL Web Installer
* Download the MySQL Web Installer from the [MySQL Downloads](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi) page. 


###### Windows Step 2: Install the MySQL Web Programs
* Follow along with the installer as described below. If a step is not specifically listed, accept the defaults.

  * Select "Yes" if prompted to update.
  * Accept license terms.
  * Choose "Custom" setup type.
  * In the "Select Products and Features" menu, choose the following:
    * Check the box titled "Enable the Select Features page to customize product features".
    * Under *MySQL Servers > MySQL Server > MySQL Server 8.0*, select "MySQL Server 8.0.19" (or latest available version).
    * Under *Applications > MySQL Workbench > MySQL Workbench 8.0*, select "MySQL Workbench 8.0.19" (or latest available version).
  * Select "Next", then "Execute". Wait for download and installation. This can take some time.
  * Continue through the following Configuration steps:
    * Set "High Availability" to "Standalone".
    * Set "Type and Networking" to "Defaults are OK".
    * Set "Authentication Method" to "Use Legacy Authentication Method".
    * Set password to a password of your choosing. This password will become necessary later for project setup.
    * Set "Windows Service" to "Defaults are OK". Ensure that the following options are selected:
      * "Configure MySQL Server as a Windows Service".
      * "Start the MySQL Server at System Startup".
      * "Run Windows Service" should be set to "Standard System Account".
  * Complete the installation as prompted.


###### Windows Step 3: Configure Environment Variables
* The terminal (CLI, PowerShell, and GitBash) now need to be configured to recognize the mysql command. This can be done through changing the environment variables.

  * Press the **Windows** key and **R** key simultaneously to bring up the Run prompt. 
  * In the run prompt, type in `sysdm.cpl`, then press Enter.
  * In the System Properties window that appears, navigate to the "Advanced" tab, then select "Environment Variables...".
    * In the Environment Variables window, under the "System Variables" section, double-click on the "Path" variable to launch it's editing window.
      * In the editing window, select the "New" button in the top right, then enter the installation path of the MySQL Server. 
      For most installations, this should be `C:\Program Files\MySQL\MySQL Server 8.0\bin`, but may vary depending on the version installed.
      * When finished, select "OK".
    * Select "OK".
  * Select "Apply", then select "OK".


###### Windows Step 4: Test Installation (MySQL Community Server)
* Finally, from a new PowerShell window, attempt to login to mysql to confirm it is configured properly.
  Substitue "YOUR_PASSWORD_HERE" for the password you set during installation.

  ```powershell
  mysql -uroot -pYOUR_PASSWORD_HERE.
  ```

  There will be an intro message, and the prompt should change to: `mysql> `. This confirms that mysql is installed and everything is working as expected.
  If you instead receive a `The term 'mysql' is not recognized as the name of a cmdlet, function, script file, or operable program` error, double-check that the environment variables were set up correctly. If all else fails, attempt to uninstall any versions of the applications that are previously installed, then follow this installation guide again.



### 2 - Project Setup Requirements

##### Step 1: Clone Repo
* Clone this repository to your desktop by running the following command from your Git Bash console:
  ```bash
   git clone https://github.com/mejia-dev/PierresTreats.git
   ```

##### Step 2: Create appsettings.json
* This project requires a file titled `appsettings.json` residing in the project directory (not the root directory).
  * Navigate to the project directory:
    ```bash
    cd PierresTreats/PierresTreats
    ```
  * Create the file:
    ```bash
    touch appsettings.json
    ```
  * Using a text editor of your choice, modify the file to include the following JSON data:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=pierres_treats;uid=YOUR_USERNAME_HERE;pwd=YOUR_PASSWORD_HERE;"
      }
    }
    ```

    Please note that the DefaultConnection string is essentially broken up into five distinct lines. Replace data from the template as needed for your environment.
    * `Server=localhost;`
    * `Port=3306;`
    * `database=pierres_treats;`
    * `uid=YOUR_USERNAME_HERE;`
    * `pwd=YOUR_PASSWORD_HERE;`



### 3 - Run the Project
* Navigate to the project directory, and to the project subfolder:
  ```bash
  cd PierresTreats/PierresTreats
  ```

* Run the following command to install dependencies:
  ```bash
  dotnet restore
  ```

* Run the following command to set up the database schema:
  ```bash
  dotnet ef database update
  ```

* Run the project using:
  ```bash
  dotnet run
  ```



## ⚠️ Known Bugs
If you see an issue, please report it on the [Issues](https://github.com/mejia-dev/PierresTreats/issues) page.
* none


## 🗣️ User Stories
* The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update, and delete functionality. All users should be able to have read functionality.
* There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
* A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.
Objectives


## ⚖️ License

Copyright (C) 2024 Aaron Mejia<br />
Open Source under the [GPLv3 License](./LICENSE.txt).