# 哈工大课表大师增强版 <del>（打安排御主加）</del>

![Electron.Net linux Build](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/workflows/Electron.Net%20linux%20Build/badge.svg)

![Electron.Net macOS Build](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/workflows/Electron.Net%20macOS%20Build/badge.svg)

![Electron.Net Windows Build](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/workflows/Electron.Net%20Windows%20Build/badge.svg)

本应用使用`ASP dotnet core`+`Electron.Net`编写，完全开放、开源

快捷使用指南请参见[此处](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/blob/master/QUICKSTART.md)

本应用仅适用于**哈尔滨工业大学**的课程导出，不兼容其他学校的系统

![GPL3orLater](https://www.gnu.org/graphics/gplv3-or-later.png)

如果您在使用本程序的时候遇到了BUG或者有什么好的建议，欢迎您开启新的[Issuse]()。

如果您对本程序进行了改进，欢迎PR！

[下载地址](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/releases)

## 主要功能

- 可以将从教务系统上下载的XLS格式课表导入
- 将课表储存为JSON，方便保存和打开
- 导出课表为`iCalendar (RFC 5545) `格式以便导入到日历软件中
- 可以手动增删和编辑课程，支持将课程的从JSON导入以及导出到JSON，方便共享<del>和蹭课</del>

## 为什么要使用本程序？

- 程序本体基于跨平台构建，无论你使用`Windows`、`Linux`或者`macOs`，都支持运行本程序。
- 本程序导出的`iCalendar (RFC 5545)`格式受世界上几乎所有的现代操作系统支持，实现了真正的跨平台
- 由于日历一般为系统自带应用，因此UI往往与系统原生UI相同，并且系统的日历应用往往有优化。而且若不喜欢系统的日历应用，还可以使用第三方的日历应用。
- 原生日历支持跨平台同步
- **本程序导出的课表默认在开课前进行提醒，能够有效防止忘课。**
- 可以将课表或者单个课程储存为JSON，方便**共享课程<del>蹭课</del>**
- 支持手动增加/删除课程 **(可以追加考试时间记录)**

## 一些特性

- 课表生成的日历，默认在课程开始前25分钟进行提醒

## 目前准备实现的新功能/特性

- [ ] 支持创建空白课表进行手动添加课程的操作
- [ ] 支持修改课程提醒时间
- [ ] 支持在已经导入课表的前提下再追加导入课程信息
- [ ] 课表相同项目自动合并

## 已知BUG以及修复情况

- <del>导入或载入时如不选择文件会导致渲染线程崩溃</del>

## 重要：为什么不再提供课表自动获取

自从原始项目开始拆分之后，所有的操作都建立在先从教务处下载课表的前提下，而不像以前那样自动获取。这么做的原因是本软件是开源的**自由软件**，对于本软件的一切使用都无法进行限制。也就是说，**别有用心**的人可能会利用本程序对学校的教务系统进行攻击。这样造成的不利影响，不仅是对教务系统本身的，更是对于同学们自身利益的侵害。因此从现在开始，本程序不再提供自动下载课表的功能。但还是保留了到教务系统的链接，方便同学们打开链接手动下载课表。虽然减少了自动化，但是同学们的安全得到了保障。

**本程序仍在早期开发阶段，虽然已经满足基本使用需求，但请在导出之后检查日历是否有问题，以免误课。**