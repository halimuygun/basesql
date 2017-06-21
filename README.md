## BaseSQL
Basic SQL commands for SQL Server, MySQL, Oracle, SQLite, PostgreSQL, etc..

[Usage](#usage) | [Examples](#examples) | [Options](#options) | [Author](#author) | [License](#license)

## Usage
```c#
using BaseSQLServer;

Database Sql = new Database();
```

## Examples
```c#
using BaseSQLServer;

Database Sql = new Database();
Sql.ConnectionString_ = "<sql server connection string>";

public void Read()
{
    DataTable dt = Sql.Read("select * from FinanceTable where PriceDate = '2017-05-11'");
    string id = dt.rows[0]["ID"].toString();
    ...
}
```

## Options

## Author
[Halim Uygun](https://github.com/halimuygun)

## License
[MIT](https://tldrlegal.com/license/mit-license)
