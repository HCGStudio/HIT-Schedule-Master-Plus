# 快速使用指南

## 在PC上安装HIT Schedule Master Plus

您可以从如下链接进行下载：

[Windows](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/releases/download/0.1.3/HITScheduleMasterPlus-Setup-0.1.3.exe)

[MacOS](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/releases/download/0.1.3/HITScheduleMasterPlus-0.1.3.dmg)

运行程序完成安装后，运行*HIT Schedule Master Plus*

## 从教务处网站获取xls格式的个人课表

在个人课表查询的页面，有"导出课表"按钮，单击即可导出`xls格式`。
*HIT Schedule Master Plus*中，执行**文件-下载课表**可以快速打开jwts

## 导入课表到HIT Schedule Master Plus

在*HIT Schedule Master Plus*中执行**文件-载入**，然后在弹出的文件选择框中打开刚刚获取的`xls格式`课表即可载入。

## 生成课表到iCalendar格式

在*HIT Schedule Master Plus*中执行**文件-生成**即可生成课表为`iCalendar格式(.ics)`，这是一种通用日历格式。

## iCalendar格式的使用

### Windows日历 如何导入

**请注意，Windows版“日历”应用只能将事件导入到已经存在的日历中，这可能是不安全的，因此我们建议您采用网页版Outlook，或者Google日历来完成事件导入。**

先使用您的**电子邮件账户**登录Windows日历程序，然后使用Windows日历打开生成的`ics`文件，自动显示导入。

根据提示，选择指定的日历即可完成导入。

![image1](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/raw/master/img/image-1.png)

导入后，日历将与您登录的电子邮件账户同步，在移动端登录邮箱也会同步导入的日历。

### Outlook日历如何导入

1. 首先登陆网页版[网页版Outlook日历](https://outlook.live.com/calendar/)进行导入。
2. 在左边栏中点击"添加日历"
![image2](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/raw/master/img/image-3.png)
3. 在弹出的窗口中，如图示完成新建日历。
![image3](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/raw/master/img/image-4.png)
4. 将ICS描述的事件导入到新建的日历中。
![image4](https://github.com/HCGStudio/HIT-Schedule-Master-Plus/raw/master/img/image-5.png)


### Google日历 如何导入

请参考[将活动导入到 Google 日历](https://support.google.com/calendar/answer/37118?hl=zh-Hans)进行导入。

在导入后，日历将于您的Gmail账户同步，在移动端登录Gmail账户，或者下载Google日历客户端就可以使用。

### iOS / iPadOS 如何导入

#### 方法一

在Windows下使用Windows日历，Outlook日历或者Google日历，在`邮件`应用中登录对应的电子邮件账户就可以自动导入日历。

#### 方法二

在Windows下使用电子邮件将`ics`文件通过QQ传到手机，或者作为附件发送电子邮件到`邮件`应用中登录的账户，按照提示即可完成导入。

#### 方法三

通过登录`iCloud`的macOS设备导入。

### macOS 如何导入

双击生成的`ics`文件，选择要导入的日历即可。导入的日历将会通过`iCloud`自动同步到您的iOS以及iPadOS设备中（如果登录）。

### Android 如何导入

#### 方法一

在Windows下使用Windows日历，Outlook日历或者Google日历，在您使用系统的`日历`应用中登录对应的电子邮件账户就可以导入日历到Android设备。

#### 方法二

在Windows下使用电子邮件将`ics`文件通过QQ传到手机，选择使用`日历`打开。如果您的系统无法使用日历打开`ics`文件，建议您安装`Google 日历`（无需登录即可导入）或Outlook，等等。