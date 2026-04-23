# Hello World - .NET

A simple .NET Console application with intentional vulnerabilities for Snyk integration testing.

## Vulnerabilities

- **Weak MD5 hashing** - Use of deprecated MD5 algorithm for password hashing
- **Unsafe JSON deserialization** - TypeNameHandling set to Auto enables RCE
- **Command injection** - Process execution with unsanitized user input
- **SQL injection** - String interpolation in SQL queries
- **Hardcoded credentials** - Database and AWS credentials exposed in code
- **Vulnerable dependencies** - Newtonsoft.Json 11.0.1, System.Net.Http 4.3.0, EntityFramework 6.1.3, log4net 2.0.5 with known CVEs

## Build & Run

```bash
dotnet build
dotnet run
```

## Purpose

This repository is designed for security testing with Snyk to validate vulnerability detection capabilities.
