--select * from t_Control
--select max(controlid) from t_control
insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
values('dlfh01','2','DLBiaoPan.jpg','��������','��������01');
/*
DeviceName   Voltagelevel   CapacitiveColor  CapacitiveWidth
LineColor  LineWidth   */

--�豸����			--��ѹ�ȼ� ,6��10��35��110��220
--������ɫ		--���ݿ��
--��·��ɫ		--��·���
declare @ControlID int;
set @ControlID=60;

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 1,'DeviceName','������','�豸����');
--��ѹ�ȼ�
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
--������ɫ
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 3,'CapacitiveColor','#FFFA0000','������ɫ');
--���ݿ��
INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 4,'CapacitiveWidth','2','���ݿ��');

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','��·��ɫ');

INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
     VALUES(@ControlID, 6,'LineWidth','2','��·���');

select * from [t_ControlProperty] where ControlID=60

LineWidth
