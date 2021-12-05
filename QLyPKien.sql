use master
go
create database QLBanPkien
go
use QLBanPKien
go 
create table danhmuc 
(
	Tendanhmuc nvarchar(20) primary key,
	Mota nvarchar(200),
)

go
create table sanpham
(
	id int IDENTITY NOT NULL primary key,
	Tensp nvarchar(30) not null, 
	avatar nvarchar(255),
	price int,
	brand nvarchar(255),
	soluong int,
	Mota nvarchar(30),
	Ngaytao date default getdate(), 
	Tendanhmuc nvarchar(20),
	constraint FK_danhmuc_sanpham foreign key (Tendanhmuc) references danhmuc(Tendanhmuc)
);
select * from sanpham
go

create table taikhoan
(
	username nvarchar(255) primary key not null,
	pass nvarchar(255) not null,
	fullname nvarchar(255),
	avatar nvarchar(255),
	phone varchar(255),
	email nvarchar(255),	
);
go
drop table taikhoan	
select *from taikhoan

create table hoadon
(
	id_hoadon int identity primary key,
	fullname nvarchar(255),
	phone varchar(255),
	note nvarchar(255),
	tongtien int,
	phuongthuc nvarchar(50), 
	Ngaytao datetime default CURRENT_TIMESTAMP,

);

select * from hoadon 

drop table hoadon
delete Chitietdon
delete hoadon

go
create table bangtam
(	
	masp int primary key,
	dongia int,
	soluong int,
	thanhtien int,
)
select * from bangtam
delete bangtam


create table Chitietdon
(
	hoadon_id int not null foreign key references hoadon(id_hoadon),
	sanpham_id int not null foreign key references sanpham(id),
	soluong int,
	dongia int,
	thanhtien int,
	primary key(hoadon_id,sanpham_id)
);



go
insert into taikhoan values('nga','1234',N'Phan Tuyết Nga','nn ','0981178932','nga.p.t6868@gamil.com')
delete taikhoan

insert into danhmuc values(N'Vòng cổ',N'Vòng cổ luôn là trang sức thu hút phái nữ')
insert into danhmuc values(N'Vòng tay',N'Vòng tay luôn là trang sức thu hút phái nữ')

select *from danhmuc

insert into sanpham(Tensp,price,brand,soluong,Mota) values(N'Vòng tay bạc',100000,N'Local Brand',20,N'bạc là trang sức quý giá')
insert into sanpham(Tensp,price,brand,soluong,Mota) values(N'Vòng tay vàng',200000,N'Local Brand',20,N'vàng là trang sức quý giá')

select * from sanpham



select * from hoadon

select *from Chitietdon

--insert hoadon values(N'Phan Tuyết Nga', '0981178932', N'note 1', 100000, N'Chuyển khoản', CURRENT_TIMESTAMP) 
insert hoadon values(N'Phan Thu Hiền', '098765132', N'note 2', 150000, N'Tiền mặt', '2021-5-29') 
insert hoadon values(N'Phan Hải Anh', '0987651323', N'note 3', 200000, N'Tiền mặt', '2020-5-29') 
insert Chitietdon values(8, 3, 1, 150000, 150000)
insert Chitietdon values(9, 2, 1, 200000, 200000)

SELECT MONTH(CURRENT_TIMESTAMP)

select sum(thanhtien) as doanhthu_thang
from Chitietdon ct inner join hoadon hd on ct.hoadon_id= hd.id_hoadon where MONTH(CURRENT_TIMESTAMP) = MONTH(hd.Ngaytao) and YEAR(CURRENT_TIMESTAMP)=YEAR(hd.Ngaytao)


select sum(thanhtien) as doanhthu_ngay 
from Chitietdon ct inner join hoadon hd on ct.hoadon_id= hd.id_hoadon where Cast(CURRENT_TIMESTAMP as date) = cast(hd.Ngaytao as date)


create proc ThongKeDoanhThuNgay
as
begin 

select sum(thanhtien) as doanhthu_ngay 
from Chitietdon ct inner join hoadon hd on ct.hoadon_id= hd.id_hoadon where Cast(CURRENT_TIMESTAMP as date) = cast(hd.Ngaytao as date)
end


create proc ThongKeDoanhThuThang
as
begin 
select sum(thanhtien) as doanhthu_thang
from Chitietdon ct inner join hoadon hd on ct.hoadon_id= hd.id_hoadon where MONTH(CURRENT_TIMESTAMP) = MONTH(hd.Ngaytao) and YEAR(CURRENT_TIMESTAMP)=YEAR(hd.Ngaytao)
end



create proc ThongKeDoanhThuNam
as
begin 
select sum(thanhtien) as doanhthu_thang
from Chitietdon ct inner join hoadon hd on ct.hoadon_id= hd.id_hoadon where YEAR(CURRENT_TIMESTAMP)=YEAR(hd.Ngaytao)
end


Select id_hoadon,fullname,phone,note,tongtien,phuongthuc,Ngaytao from hoadon where cast(Ngaytao as date) = cast(CURRENT_TIMESTAMP as date)




 