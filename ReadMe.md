<h1 align="center">Payment Provider Package</h3>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#usage">Usage</a>
      <ul>
         <li>
            <a href="#usage-one-running-swaggerscalar-ui">
               Usage One: Running swagger/Scalar UI
            </a>
         </li>
         <li>
            <a href="#usage-two-get-a-nuget-package-of-the-infrastructure-project">
               Usage Two: Get a nuget package of the Infrastructure project
            </a>
         </li>
      </ul>
   </li>
<ol>
</details>


<!-- ABOUT THE PROJECT -->

## About The Project

### Built With

* .Net Standard 2.0
* .Net 10 [Minimal Api]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

### Prerequisites

* [.Net Standard 2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)
* [.Net Minial Api/.Net 10](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-10.0&tabs=visual-studio)

### Installation

1. Clone the [repo](https://github.com/AskXclaim/PaymentProviderPackage) [preferrable from the 'Main' branch].
2. Open the folder where you cloned it to and open the .sln file.
3. Run nuget restore
4. Build the solution.
5. Create a secrets.json file. You can do so
   following [this](https://blog.jetbrains.com/dotnet/2023/01/17/securing-sensitive-information-with-net-user-secrets/)
   tutorial
6. Add the 'secretKey' section to the file. Ps: Remember to replace the place holder with your secret key as supplied to
   you from checkout.com

```json
{
  "secretKey": "<Your checkout.com secret key>"
}
```

7. Change git remote url to avoid accidental pushes to base project
   ```sh
   git remote set-url origin github_username/repo_name
   git remote -v # confirm the changes
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->

## Usage

### Usage One: Running swagger/Scalar UI

Set start up project to the 'Web Api' project, and run. You should get a Scalar UI or Swagger UI Page depending on what
configuration setting you set it to run on.

If you get an error similar to this
`Error NETSDK1005 : Assets file 'project.assets.json' doesn't have a target for '.NETStandard,Version=v2.0'. Ensure that restore has run and that you have included '.NETStandard,Version=v2.0' in the TargetFrameworks for your project.`
Delete all the `obj` & `bin` folders in all the projects and do a nuget restore or a nuget forced restore.

[This articule](https://learn.microsoft.com/en-us/nuget/consume-packages/package-restore) provides information on how to
do a nuget restore etc.

### Usage Two: Get a nuget package of the Infrastructure project
Generate a nuget package using instructions from [this](https://learn.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli) or [this](https://www.jetbrains.com/help/rider/Creating_NuGet_packages.html) tutorial and consume where needed.
<p align="right">(<a href="#readme-top">back to top</a>)</p>
