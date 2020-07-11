# Набор инструментов для ФИАС

Набор инструментов для работы с Федеральной Информационной Адресной Системой (ФИАС) (https://fias.nalog.ru/)

## Состояние сборки

| Windows |  Linux |
|:-------:|:------:|
| [![Build status](https://ci.appveyor.com/api/projects/status/psgnk6vwjfdraj7l?svg=true)](https://ci.appveyor.com/project/YPermitin/yy-fias-toolset)  | [![Build Status](https://travis-ci.org/YPermitin/YY.FIAS.ToolSet.svg?branch=master)](https://travis-ci.org/YPermitin/YY.FIAS.ToolSet) |

### Code Climate

[![Maintainability](https://api.codeclimate.com/v1/badges/202f2e3847973f8b5e3b/maintainability)](https://codeclimate.com/github/YPermitin/YY.FIAS.ToolSet/maintainability)

## Состав репозитория

Библиотеки:

* **YY.FIAS.Loader** - библиотека для загрузки файлов баз данных ФИАС и их обновлений с официального сайта.
* **YY.FIAS.Exporter** - библиотека для экспорта ФИАС в альтернативные хранилища. Базовый компонент.

Приложения:

* **YY.FIAS.ConsoleApp** - консольное приложение с примерами использования библиотек.
* **YY.FIAS.Service** - сервис WebAPI для использования ФИАС.

## Библиотека YY.FIAS.Loader

Используется для загрузки информации о версиях ФИАС. Позволяет получить как информацию о последней актуальной версии с сылками для загрузки данных, так и историю последних выпусков классификатора.

Вот таким образом можно скачать все данные классификатора ФИАС последней выпущенной версии:

```csharp
// Определяем каталог, куда будут сохранены файлы базы ФИАС
string workDirectory = Path.Combine(Environment.CurrentDirectory, "FIASData");

// Получаем данные последней версии ФИАС
// В результате будет получена информация в виде:
//  - VersionId	- Идентификатор версии
//  - TextVersion - Описание версии файла в текстовом виде
//  - VersionDate - Дата версии
//  - FiasCompleteDbfUrl - URL полной версии ФИАС в формате DBF
//  - FiasCompleteXmlUrl - URL полной версии ФИАС в формате XML
//  - FiasDeltaDbfUrl - URL дельта версии ФИАС в формате DBF
//  - FiasDeltaXmlUrl - URL дельта версии ФИАС в формате XML
//  - Kladr4ArjUrl - URL версии КЛАДР 4 сжатого в формате ARJ
//  - Kladr47ZUrl - URL версии КЛАДР 4 сжатого в формате 7Z
IFIASLoader loader = new FIASLoader();
DownloadFileInfo lastInfo = await loader.GetLastDownloadFileInfo();

// Сохраняем все возможные файлы данных последней версии в указанную ранее директорию.
// Библиотека загрузит все указанные данные в каталог для дальнейшей работы
await Task.WhenAll(
    lastInfo.SaveFiasDeltaDbToDirectoryAsync(workDirectory),
    lastInfo.SaveFiasDeltaXmlToDirectoryAsync(workDirectory),
    lastInfo.SaveFiasCompleteDbfToDirectoryAsync(workDirectory),
    lastInfo.SaveFiasCompleteXmlToDirectoryAsync(workDirectory),
    lastInfo.SaveKladr47ZToDirectoryAsync(workDirectory),
    lastInfo.SaveKladr4ArjToDirectoryAsync(workDirectory)
);
```

Примерно таким же образом можно работать с выпущенными ранее версиями ФИАС, предварительно получив все доступные версии для загрузки.

```csharp
string workDirectory = Path.Combine(Environment.CurrentDirectory, "FiasHistoryData");
IFIASLoader loader = new FIASLoader();
IReadOnlyList<DownloadFileInfo> historyInfo = await loader.GetAllDownloadFileInfo();

foreach (var fileInfo in historyInfo)
{
    // Файлы данных каждой версии сохраняются в отдельный вложенный каталог
    string currentVersionPath = Path.Combine(workDirectory, fileInfo.VersionId.ToString());

    await Task.WhenAll(
        fileInfo.SaveFiasDeltaDbToDirectoryAsync(currentVersionPath),
        fileInfo.SaveFiasDeltaXmlToDirectoryAsync(currentVersionPath),
        fileInfo.SaveFiasCompleteDbfToDirectoryAsync(currentVersionPath),
        fileInfo.SaveFiasCompleteXmlToDirectoryAsync(currentVersionPath),
        fileInfo.SaveKladr47ZToDirectoryAsync(currentVersionPath),
        fileInfo.SaveKladr4ArjToDirectoryAsync(currentVersionPath)
    );
}
```

Таким образом, библиотека используется только для загрузки файлов данных классификатора ФИАС. Дальнейшая работа с полученными данными выполняется отдельно.

## Библиотека YY.FIAS.Exporter

Библиотека для экспорта данных классификатора ФИАС в альтернативные хранилища данных. Это и базы данных SQL Server / PostgreSQL, а также индексы ElasticSearch.

Находится в разработке, описание будет добавлено по готовности...

## TODO

* Реализовать библиотеки экспорта ФИАС в БД (SQL Server/ PostgreSQL)
* Реализовать библиотеки экспорта ФИАС в индексы ElasticSearch
* Создать службу работы с ФИАС на базе WebAPI

## Лицензия

MIT - делайте все, что посчитаете нужным. Никакой гарантии и никаких ограничений по использованию.