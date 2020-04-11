using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ElectronNET.API;
using ElectronNET.API.Entities;
using HCGStudio.HITScheduleMasterCore;
using HITScheduleMasterPlus.Models;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HITScheduleMasterPlus.Controllers
{
    public class HomeController : Controller
    {
        private static Schedule _schedule;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private void SetMenu()
        {
            var menu = new[]
            {
                //文件
                new MenuItem
                {
                    Label = "文件",
                    Submenu = new[]
                    {
                        //载入
                        new MenuItem
                        {
                            Label = "载入",
                            Accelerator = "CmdOrCtrl+O",
                            Click = async () =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                var options = new OpenDialogOptions
                                {
                                    Title = "选择要载入的XLS格式课表",
                                    Properties = new[]
                                    {
                                        OpenDialogProperty.openFile
                                    },
                                    Filters = new[] {new FileFilter {Extensions = new[] {"xls"}, Name = "XLS格式的课表"}}
                                };
                                var file = (await Electron.Dialog.ShowOpenDialogAsync(mainWindow, options)).First();
                                try
                                {
                                    var stream = System.IO.File.OpenRead(file);
                                    _schedule = Schedule.LoadFromXlsStream(stream);
                                    Electron.IpcMain.Send(mainWindow, "MoveNext");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                        },
                        new MenuItem {Type = MenuType.separator},
                        //导入
                        new MenuItem
                        {
                            Label = "导入",
                            Accelerator = "CmdOrCtrl+I",
                            Click = async () =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                var options = new OpenDialogOptions
                                {
                                    Title = "选择要导入的JSON格式课表",
                                    Properties = new[]
                                    {
                                        OpenDialogProperty.openFile
                                    },
                                    Filters = new[] {new FileFilter {Extensions = new[] {"json"}, Name = "Json格式的课表"}}
                                };
                                var file = (await Electron.Dialog.ShowOpenDialogAsync(mainWindow, options)).First();
                                try
                                {
                                    var json = await System.IO.File.ReadAllTextAsync(file);
                                    var schedule = JsonConvert.DeserializeObject<EditableSchedule>(json);
                                    Console.WriteLine(schedule.Entries.Count);
                                    Console.WriteLine(schedule.Semester);
                                    _schedule = new Schedule(schedule.Year, (Semester) schedule.Semester);
                                    foreach (var scheduleEntry in schedule.Entries)
                                        _schedule.AddScheduleEntry(scheduleEntry);
                                    Electron.IpcMain.Send(mainWindow, "MoveNext");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                        },
                        //导出
                        new MenuItem
                        {
                            Label = "导出",
                            Accelerator = "CmdOrCtrl+E",
                            Click = async () =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                var options = new SaveDialogOptions
                                {
                                    Filters = new[] {new FileFilter {Extensions = new[] {"json"}, Name = "JSON格式课表"}},
                                    Title = "选择要保存导出JSON格式课表的位置"
                                };
                                var file = await Electron.Dialog.ShowSaveDialogAsync(mainWindow, options);
                                try
                                {
                                    var json = JsonConvert.SerializeObject(_schedule);
                                    await System.IO.File.WriteAllTextAsync(file, json, Encoding.UTF8);
                                    await Electron.Dialog.ShowMessageBoxAsync(new MessageBoxOptions("导出成功")
                                    {
                                        Type = MessageBoxType.info,
                                        Title = "成功导出JSON格式课表！",
                                        Buttons = new[] {"OK"}
                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                        },
                        new MenuItem {Type = MenuType.separator},
                        //生成
                        new MenuItem
                        {
                            Label = "生成",
                            Accelerator = "CmdOrCtrl+G",
                            Click = async () =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                var options = new SaveDialogOptions
                                {
                                    Filters = new[]
                                        {new FileFilter {Extensions = new[] {"ics"}, Name = "ICalendar日历格式"}},
                                    Title = "选择保存生成的日历的位置"
                                };
                                var file = await Electron.Dialog.ShowSaveDialogAsync(mainWindow, options);
                                try
                                {
                                    var cal = _schedule.GetCalendar();
                                    var str = new CalendarSerializer().SerializeToString(cal);
                                    await System.IO.File.WriteAllTextAsync(file, str, Encoding.UTF8);
                                    await Electron.Dialog.ShowMessageBoxAsync(new MessageBoxOptions("生成成功")
                                    {
                                        Type = MessageBoxType.info,
                                        Title = "成功生成日历格式课表！",
                                        Buttons = new[] {"OK"}
                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                        }
                    }
                },
                //编辑
                new MenuItem
                {
                    Label = "编辑",
                    //添加条目
                    Submenu = new[]
                    {
                        new MenuItem
                        {
                            Label = "添加条目",
                            Accelerator = "CmdOrCtrl+A",
                            Click = () =>
                            {
                                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                                Electron.IpcMain.Send(mainWindow, "AddEntry");
                            }
                        }
                    }
                },
                //帮助
                new MenuItem
                {
                    Label = "帮助",
                    Submenu = new[]
                    {
                        new MenuItem
                        {
                            Label = "Wiki",
                            Click = () =>
                            {
                                Process.Start(
                                    new ProcessStartInfo(
                                            "https://github.com/HCGStudio/HIT-Schedule-Master-Plus/wiki")
                                        {UseShellExecute = true});
                            }
                        },
                        new MenuItem
                        {
                            Label = "项目网址",
                            Click = () =>
                            {
                                Process.Start(
                                    new ProcessStartInfo(
                                            "https://github.com/HCGStudio/HIT-Schedule-Master-Plus")
                                        {UseShellExecute = true});
                            }
                        },
                        new MenuItem
                        {
                            Label = "提交Issue",
                            Click = () =>
                            {
                                Process.Start(
                                    new ProcessStartInfo(
                                            "https://github.com/HCGStudio/HIT-Schedule-Master-Plus/issues")
                                        {UseShellExecute = true});
                            }
                        }
                    }
                }
            };
            Electron.Menu.SetApplicationMenu(menu);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetScheduleEntry(int id)
        {
            if (_schedule == null || id < 0 || id > _schedule.Count)
                return NotFound();
            return Ok(JsonConvert.SerializeObject(_schedule[id]));
        }


        private void RegisterIpc()
        {
            Electron.IpcMain.On("DeleteEntry", async args =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                var index = args switch
                {
                    int i => i,
                    long i => (int) i,
                    string s when int.TryParse(s, out var i) => i,
                    _ => -1
                };

                if (index <= _schedule.Count && index >= 0)
                {
                    var options = new MessageBoxOptions($"确定删除{_schedule[index].CourseName}？")
                    {
                        Type = MessageBoxType.info,
                        Title = "确认删除",
                        Buttons = new[] {"Yes", "No"}
                    };
                    var result = await Electron.Dialog.ShowMessageBoxAsync(options);
                    if (result.Response == 0)
                    {
                        _schedule.RemoveAt(index);
                        Electron.IpcMain.Send(mainWindow, "MoveNext");
                    }
                }
            });
            Electron.IpcMain.On("EditEntry", args =>
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<dynamic>(args as string);
                    int id = obj.Id;
                    string name = obj.Name;
                    string teacher = obj.TeacherName;
                    var courseTime = (CourseTime) int.Parse(obj.CourseTime.ToString());
                    string location = obj.Location;
                    var dayOfWeek = (DayOfWeek) int.Parse(obj.DayOfWeek.ToString());
                    string week = obj.Week;
                    bool isLong = obj.IsLongCourse;
                    if (id < 0 || id > _schedule.Count)
                        return;
                    _schedule[id].CourseName = name;
                    _schedule[id].Teacher = teacher;
                    _schedule[id].CourseTime = courseTime;
                    _schedule[id].Location = location;
                    _schedule[id].DayOfWeek = dayOfWeek;
                    _schedule[id].IsLongCourse = isLong;
                    _schedule[id].WeekExpression = week;
                }
                catch (Exception ex)
                {
                    Electron.Dialog.ShowErrorBox("错误", "出现了一个错误，很可能是周表达式出现问题！");
                    Console.WriteLine(ex);
                }
                finally
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                    Electron.IpcMain.Send(mainWindow, "MoveNext");
                }
            });
            Electron.IpcMain.On("AddEntry", args =>
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<dynamic>(args as string);
                    string name = obj.Name;
                    string teacher = obj.TeacherName;
                    var courseTime = (CourseTime) int.Parse(obj.CourseTime.ToString());
                    string location = obj.Location;
                    var dayOfWeek = (DayOfWeek) int.Parse(obj.DayOfWeek.ToString());
                    string week = obj.Week;
                    bool isLong = obj.IsLongCourse;
                    var entry = new ScheduleEntry
                    {
                        CourseName = name,
                        Teacher = teacher,
                        CourseTime = courseTime,
                        Location = location,
                        DayOfWeek = dayOfWeek,
                        IsLongCourse = isLong,
                        WeekExpression = week
                    };
                    _schedule.AddScheduleEntry(entry);
                }
                catch (Exception ex)
                {
                    Electron.Dialog.ShowErrorBox("错误", "出现了一个错误，很可能是周表达式出现问题！");
                    Console.WriteLine(ex);
                }
                finally
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                    Electron.IpcMain.Send(mainWindow, "MoveNext");
                }
            });
        }

        public IActionResult Index()
        {
            RegisterIpc();
            SetMenu();
            return View();
        }

        public IActionResult AddScheduleEntry()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EditSchedule(int? id)
        {
            if (id == null || id < 0 || id > _schedule.Count)
                return NotFound();
            return View(_schedule[(int) id]);
        }

        public IActionResult ScheduleView()
        {
            return View(new ScheduleModel {Schedule = _schedule});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}