<div align="center">

# PowerToys Run: Input Typer
  
[![GitHub release](https://img.shields.io/github/v/release/CoreyHayward/PowerToys-Run-InputTyper?style=flat-square)](https://github.com/CoreyHayward/PowerToys-Run-InputTyper/releases/latest)
[![GitHub all releases](https://img.shields.io/github/downloads/CoreyHayward/PowerToys-Run-InputTyper/total?style=flat-square)](https://github.com/CoreyHayward/PowerToys-Run-InputTyper/releases/)
[![GitHub release (latest by date)](https://img.shields.io/github/downloads/CoreyHayward/PowerToys-Run-InputTyper/latest/total?style=flat-square)](https://github.com/CoreyHayward/PowerToys-Run-InputTyper/releases/latest)
[![Mentioned in Awesome PowerToys Run Plugins](https://awesome.re/mentioned-badge-flat.svg)](https://github.com/hlaueriksson/awesome-powertoys-run-plugins)

</div>

Simple [PowerToys Run](https://learn.microsoft.com/windows/powertoys/run) plugin for easily typing input as if from a keyboard. Ideal for remote environments and other scenarios where pasting isn't possible.

![InputTyper Demonstration](/images/InputTyper.gif)

## Requirements

- PowerToys minimum version 0.76.0

## Installation

- Download the [latest release](https://github.com/CoreyHayward/PowerToys-Run-InputTyper/releases/) by selecting the architecture that matches your machine: `x64` (more common) or `ARM64`
- Close PowerToys
- Extract the archive to `%LOCALAPPDATA%\Microsoft\PowerToys\PowerToys Run\Plugins`
- Open PowerToys

## Usage
- Select/Place cursor where text should be typed 
- Open PowerToys Run
- Input: "@@ \<text\>" or "@@" for clipboard
- Select the result (ENTER)
- \<text\> is typed into the selected location
