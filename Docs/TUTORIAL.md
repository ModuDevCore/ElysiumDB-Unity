<p align="center">
  <img src="https://raw.githubusercontent.com/ModuDevCore/about/main/Images/Baner.gif" width="800" alt="Организация" />
</p>

Practical step-by-step guide for working with the library.
This section contains the most important usage scenarios with code examples and illustrations.

---

## Содержание

- [1. Установка](#1-установка)
- [2. Первоначальная настройка](#2-первоначальная-настройка)
- [3. Основные сценарии использования](#3-основные-сценарии-использования)
- [4. Полезные примеры](#4-полезные-примеры)
- [5. Лучшие практики](#5-лучшие-практики)
- [См. также](#см-также)

---

## 1. Установка

### Через NuGet Package Manager

```bash
Install-Package YourPackageName
```

### Через .NET CLI

```bash
dotnet add package YourPackageName
```

![Установка пакета](../images/install-nuget.png)

---

## 2. Первоначальная настройка

```csharp
using YourNamespace;

var config = new LibraryConfiguration
{
    ApiKey = "your-key",
    Timeout = TimeSpan.FromSeconds(30),
    // другие параметры
};

var client = new MainService(config);
```

**Описание:**  
Краткое объяснение, что происходит при инициализации...

![Схема инициализации](../images/initialization-flow.png)

---

## 3. Основные сценарии использования

### 3.1 Создание кастомного модуля/расширения для ElysiumDB

Создайте два файла в любом месте в папке проекта:

### DBCustomExtension1.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class DBCustomExtension1 : DBExtensionBase
{
    public string initializeText = "Hello world!";


    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log(initializeText);
    }

    protected override void OnDispose() {}

    public void PrintHelloFromSecondExtension() {
        GetExtension<DBCustomExtension2>().Hello();
    }
}
```

### DBCustomExtension2.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class DBCustomExtension2 : DBExtensionBase
{
    public string hello = "Hello World from second extension!";

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        
    }

    protected override void OnDispose()
    {
    }

    public void Hello() {
      Debug.Log(hello);
    }
}
```

После откройте ElysiumDB -> Settings.

![Вкладка](../images/example-scenario-1.png)

Затем нажмите на кнопку Add чтобы добавить новый Extension и из списка выберите два модуля DBCustomExtension1 и DBCustomExtension2.
В конце у Вас в спике Extensions должно появиться два модуля.

![GIF видео того как добавлять модули и то как они отобразились в инспекторе](../images/example-scenario-1.png)

**Результат выполнения:**

![Схема которая показывает функционал](../images/example-scenario-1.png)

---

### 3.2 RequireExtensionAttribute


Создайте два файла в любом месте в папке проекта:

### DBCustomExtension1.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

[RequireExtensionAttribute(typeof(DBCustomExtension2))]
public class DBCustomExtension1 : DBExtensionBase
{
    public string initializeText = "Hello world!";


    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        Debug.Log(initializeText);
    }

    protected override void OnDispose() {}

    public void PrintHelloFromSecondExtension() {
        GetExtension<DBCustomExtension2>().Hello();
    }
}
```

### DBCustomExtension2.cs
```csharp
using UnityEngine;
using ModuDevCore.ElysiumDB;
using ModuDevCore.ElysiumDB.Extension;

public class DBCustomExtension2 : DBExtensionBase
{
    public string hello = "Hello World from second extension!";

    protected override void OnInitialize(ElysiumDatabase elysium)
    {
        
    }

    protected override void OnDispose()
    {
    }

    public void Hello() {
      Debug.Log(hello);
    }
}
```

После откройте ElysiumDB -> Settings.

![Вкладка](../images/example-scenario-1.png)

Затем нажмите на кнопку Add чтобы добавить новый Extension и из списка выберите модуль DBCustomExtension1.
В конце у Вас в спике Extensions должно появиться два модуля ( Или если [RequireExtensionAttribute(typeof(DBCustomExtension2), false)] - предупреждение ).

![GIF видео того как добавлять модули и то как они отобразились в инспекторе](../images/example-scenario-1.png)

**Результат выполнения:**

![Схема которая показывает функционал](../images/example-scenario-1.png)

---

## 4. Полезные примеры

### Пример 1: Полный рабочий кейс

```csharp
// Полный пример с комментариями
```

**Ожидаемый результат:**

![Результат примера](../images/full-example-result.png)

---

### Пример 2: ...

---

## 5. Лучшие практики

- Создавайте кастомные модули в редких случаях, если Вам нужно расширить функционал модуля используйте наследование классов.
- Резделяйте модули по группам, чтобы не было путаницы.
- Не стесняйтесь добавлять несколько модулей одного и того же класса, но добавляйте им поля чтобы можно было их различить.

---

## См. также

- [Полная справочная документация](./REFERENCE.md) — подробное описание всех классов и методов
- [Техническая документация](./TECHNICAL.md) — внутренняя архитектура и расширяемость
- [README](../README.md) — общая информация о проекте

<!-- 
    =============================================
    ИНСТРУКЦИЯ ДЛЯ РАЗРАБОТЧИКОВ ДОКУМЕНТАЦИИ
    =============================================

    1. Tutorial.md предназначен для пользователей. 
       Используйте простой и понятный язык.
    
    2. Каждый важный сценарий должен содержать:
       - Описание задачи
       - Пример кода
       - Изображение (результат или процесс)
       - Краткое пояснение
    
    3. Изображения размещайте в папке ../images/
    
    4. Старайтесь показывать реальные практические примеры,
       а не только синтаксис (это для REFERENCE.md).
    
    5. При добавлении новых разделов обязательно обновляйте 
       оглавление и добавляйте якорь через <a id="..."></a>
-->