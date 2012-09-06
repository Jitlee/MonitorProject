--select * from t_Control
--select max(controlid) from t_control
insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
values('dlfh01','2','DLBiaoPan.jpg','电力符号','电力符号01');
/*
DeviceName   Voltagelevel   CapacitiveColor  CapacitiveWidth
LineColor  LineWidth   */

--设备名称			--电压等级 ,6、10、35、110、220
--电容颜色		--电容宽度
--线路颜色		--线路宽度
declare @ControlID int;
set @ControlID=60;

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');
--电压等级
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 2,'Voltagelevel','10','电压等级');
--电容颜色
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 3,'CapacitiveColor','#FFFA0000','电容颜色');
--电容宽度
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 4,'CapacitiveWidth','2','电容宽度');

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','线路颜色');

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 6,'LineWidth','2','线路宽度');

select * from [t_ControlProperty] where ControlID=60

LineWidth
