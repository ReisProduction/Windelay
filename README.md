##  Table of Contents

- [ Overview](#overview)
- [ Features](#features)
- [ Project Structure](#project-structure)
  - [ Project Index](#project-index)
- [ Getting Started](#getting-started)
  - [ Prerequisites](#prerequisites)
  - [ Installation](#installation)
  - [ Usage](#usage)
  - [ Testing](#testing)
- [ Contributing](#contributing)
- [ License](#license)

---

##  Overview

Windelay is a high-performance, open-source C# library designed to provide precise timing control and flexible delay mechanisms for Windows applications. It offers **12 different delay strategies** optimized for various scenarios, from high-precision spinning to hybrid approaches combining multiple timing techniques. Whether you need microsecond-level accuracy or medium-duration delays with cancellation support, Windelay delivers the right tool for your timing requirements.

**Key Use Cases:**
- High-frequency trading systems and real-time applications
- Game development requiring frame-perfect timing
- System monitoring and performance-critical operations  
- Async/await patterns with precise delay control
- Cancellable timeout operations

---

##  Features

|      | Feature         | Summary       |
| :--- | :---:           | :---          |
| ⚙️  | **Architecture**  | <ul><li>Utilizes **CSharp** as the primary language for development.</li><li>Employs a modular structure with distinct folders for Models, Services, and Utilities.</li><li>Defines native methods in **NativeMethods.cs** for system resource handling and timing operations.</li></ul> |
| 🔩 | **Code Quality**  | <ul><li>Follows best practices for C# development, ensuring clean code and adherence to coding standards.</li><li>Implements secure coding practices with strong naming conventions.</li><li>Defines interfaces in **IDelayAction.cs** to manage delay actions efficiently.</li></ul> |
| 📄 | **Documentation** | <ul><li>Comprehensive documentation in **Windelay.csproj** managing project metadata, dependencies, and deployment processes.</li><li>Includes inline code comments for better code understanding and maintainability.</li><li>Documentation available for installation, usage, and testing using **nuget** package manager.</li></ul> |
| 🔌 | **Integrations**  | <ul><li>Integrates with system libraries for seamless functionality and compatibility.</li><li>Uses **nuget** as the package manager for managing dependencies and ensuring proper packaging.</li><li>Encapsulates delay settings through **DelayAction.cs** for asynchronous operations.</li></ul> |
| 🧩 | **Modularity**    | <ul><li>Organizes code into separate folders for distinct functionalities like Models, Services, and Utilities.</li><li>Defines clear boundaries between components to promote reusability and maintainability.</li><li>Centralizes delay handling logic in **DelayExecutor.cs** for consistent and efficient delay management.</li></ul> |
| 🧪 | **Testing**       | <ul><li>Provides testing instructions using **dotnet test** command for ensuring code reliability and functionality.</li><li>Includes unit tests for critical components like delay mechanisms and native methods.</li><li>Ensures test coverage for key functionalities to maintain code quality and performance.</li></ul> |
| ⚡️  | **Performance**   | <ul><li>Optimizes delay mechanisms in **DelayExecutor.cs** for precise and efficient timing control.</li><li>Implements performance tuning through native methods for system-level timing precision.</li><li>Utilizes different timing strategies to tailor delays for specific scenarios, improving overall performance.</li></ul> |
| 🛡️ | **Security**      | <ul><li>Implements strong naming and secure coding practices for data protection.</li><li>Implements secure delay handling mechanisms to prevent timing attacks and ensure data integrity.</li><li>Follows secure coding practices to mitigate potential security vulnerabilities.</li></ul> |

---

##  Project Structure

```sh
└── Windelay/
    ├── DelayExecutor.cs
    ├── DelayType.cs
    ├── DelayAction.cs
    ├── IDelayAction.cs
    ├── README.md
    ├── LICENSE
    ├── Windelay.csproj
    ├── ReisProduction.ico
    ├── ReisProduction.png
    └── Services/
        └── NativeMethods.cs
```


###  Project Index
<details open>
	<summary><b><code>Windelay/</code></b></summary>
	<details> <!-- root Submodule -->
		<summary><b>root</b></summary>
		<blockquote>
			<table>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/DelayExecutor.cs'>DelayExecutor.cs</a></b></td>
				<td>- Implementing various delay mechanisms, the code file orchestrates different timing strategies for precise and efficient delays<br>- By selecting the appropriate method based on the delay type, it ensures accurate timing control tailored to specific scenarios<br>- This centralized approach streamlines delay handling across the codebase, enhancing performance and reliability.</td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/DelayType.cs'>DelayType.cs</a></b></td>
				<td>Defines various delay types used within the project to manage timing and synchronization operations.</td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/DelayAction.cs'>DelayAction.cs</a></b></td>
				<td>Defines a DelayAction record within the encapsulating delay settings for asynchronous operations in the project architecture.</td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/IDelayAction.cs'>IDelayAction.cs</a></b></td>
				<td>- Defines an interface for delay actions in the project, specifying properties for delay time, cancellation token, and delay type<br>- This interface plays a crucial role in managing delays within the codebase architecture.</td>
			</tr>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/Windelay.csproj'>Windelay.csproj</a></b></td>
				<td>- Manages project metadata and dependencies, ensuring proper packaging and distribution<br>- Integrates with system libraries and defines project properties for versioning, licensing, and platform compatibility<br>- Facilitates seamless deployment and release processes, enhancing project discoverability and accessibility.</td>
			</tr>
			</table>
		</blockquote>
	</details>
	<details> <!-- Services Submodule -->
		<summary><b>Services</b></summary>
		<blockquote>
			<table>
			<tr>
				<td><b><a href='https://github.com/ReisProduction/Windelay/blob/master/Services/NativeMethods.cs'>NativeMethods.cs</a></b></td>
				<td>Define native methods for handling system resources and timing in the project architecture.</td>
			</tr>
			</table>
		</blockquote>
	</details>
</details>

---
##  Getting Started

###  Prerequisites

Before getting started with Windelay, ensure your runtime environment meets the following requirements:

- **Programming Language:** CSharp
- **Package Manager:** Nuget


###  Installation

Install Windelay using one of the following methods:

**Build from source:**

1. Clone the Windelay repository:
```sh
❯ git clone https://github.com/ReisProduction/Windelay
```

2. Navigate to the project directory:
```sh
❯ cd Windelay
```

3. Install the project dependencies:


**Using `nuget`** &nbsp; [<img align="center" src="https://img.shields.io/badge/C%23-239120.svg?style={badge_style}&logo=c-sharp&logoColor=white" />](https://docs.microsoft.com/en-us/dotnet/csharp/)

```sh
❯ dotnet restore
```




###  Usage

**Basic Hybrid Delay (Recommended):**
```csharp
using ReisProduction.Windelay;

// Simple 100ms delay with hybrid approach
DelayAction delay = new(DelayMilisecond: 100, Token: CancellationToken.None);
await DelayExecutor.HandleDelay(delay);
```

**High-Resolution Spin for Microsecond Precision:**
```csharp
// Ultra-precise 10ms delay using CPU spinning
DelayAction preciseDelay = new(
    DelayMilisecond: 10, 
    Token: CancellationToken.None, 
    DelayType: DelayType.HighResSpin
);
await DelayExecutor.HandleDelay(preciseDelay);
```

**Cancellable Delay:**
```csharp
using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));
DelayAction cancelableDelay = new(
    DelayMilisecond: 10000, 
    Token: cts.Token, 
    DelayType: DelayType.HybridDelay
);
try { await DelayExecutor.HandleDelay(cancelableDelay); }
catch (OperationCanceledException) { Console.WriteLine("Delay cancelled"); }
```

**Explore Different Delay Strategies:**
Windelay supports 12 delay types: `HybridDelay`, `HighResSpin`, `SpinDelay`, `WaitableTimer`, `HighResSleep`, `SleepDelay`, `TaskDelay`, `TaskDelayWait`, `EventWaitHandle`, `TimersTimerDelay`, `TimerDelay`, and `FormsTimerDelay`. Choose based on your precision and CPU usage requirements.


###  Testing
Run the test suite using the following command:
**Using `nuget`** &nbsp; [<img align="center" src="https://img.shields.io/badge/C%23-239120.svg?style={badge_style}&logo=c-sharp&logoColor=white" />](https://docs.microsoft.com/en-us/dotnet/csharp/)

```sh
❯ dotnet test
```


---

##  Contributing

- **💬 [Join the Discussions](https://github.com/ReisProduction/Windelay/discussions)**: Share your insights, provide feedback, or ask questions.
- **🐛 [Report Issues](https://github.com/ReisProduction/Windelay/issues)**: Submit bugs found or log feature requests for the `Windelay` project.
- **💡 [Submit Pull Requests](https://github.com/ReisProduction/Windelay/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/ReisProduction/Windelay
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/ReisProduction/Windelay/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=ReisProduction/Windelay">
   </a>
</p>
</details>

---

##  License

This project is protected under the [MIT](https://choosealicense.com/licenses/mit) License. For more details, refer to the [LICENSE](https://github.com/ReisProduction/Windelay?tab=MIT-1-ov-file) file.

---