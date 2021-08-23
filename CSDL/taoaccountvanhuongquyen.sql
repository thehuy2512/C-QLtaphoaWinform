use master
go
sp_addlogin 'sa', '123'
go

use QLtaphoa
go
sp_changedbowner 'sa'
go