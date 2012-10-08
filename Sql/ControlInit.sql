use [GDK_BCM]

declare @ControlNum int;--��ѯ�ؼ������������ж��Ƿ��Ѿ����
set @ControlNum=0;
declare @AddControl varchar(10);--��ӿؼ�����

--��ӡ���������001��
set @AddControl='dlfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh01','��������','��������001');


		declare @ControlID int;
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
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
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','���ݿ��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','��·���');
		end
end
--��ӡ���������002��
set @AddControl='dlfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh02','��������','��������002');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
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
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','���ݿ��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','��·���');
		end
end

--��ӡ���������03-- �ӵ��ߡ�
set @AddControl='dlfh03'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh03','��������','�ӵ���');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');			
			--�ӵ�����ɫ
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','�ӵ�����ɫ');
			--�ӵ��߿��
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·���');
		end
end

--��ӡ���������04-- �ӵ��ߡ�
set @AddControl='dlfh04'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh04','��������','�ӵ���');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');			
			--�ӵ�����ɫ
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','�ӵ�����ɫ');
			--�ӵ��߿��
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·���');
		end
end

--��ӡ���������05-- �ӵ��ߡ�
set @AddControl='dlfh05'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh05','��������','�ӵ���');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');			
			--�ӵ�����ɫ
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','�ӵ�����ɫ');
			--�ӵ��߿��
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·���');
		end
end

--��ӡ���������06-- �ӵ��ߡ�
set @AddControl='dlfh06'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh06','��������','�ӵ���');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');			
			--�ӵ�����ɫ
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','�ӵ�����ɫ');
			--�ӵ��߿��
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·���');
		end
end


--��ӡ���������07-- �ӵ��ߡ�
set @AddControl='dlfh07'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh07','��������','�ӵ���');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');			
			--�ӵ�����ɫ
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','�ӵ�����ɫ');
			--�ӵ��߿��
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿��');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·���');
		end
end

--��ӡ���������08-- �ӵ��ߡ�
set @AddControl='dlfh08'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh08','��������','��������08');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'LineColor','#FFED1212','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'LineWidth','1','��·���');
		end
end


--��ӡ���������09��
set @AddControl='dlfh09'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh09','��������','ĸ��02');

		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			--�Ƿ�����
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'ISLT','False','�Ƿ�����');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','ĸ����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','ĸ�߿��');
		end
end

--��ӡ���������010��
set @AddControl='dlfh10'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh10','��������','ĸ��02');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','������','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			--�Ƿ�����
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'ISLT','False','�Ƿ�����');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','ĸ����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','ĸ�߿��');
		end
end

--��ӡ���������011��
set @AddControl='dlfh11'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh11','��������','�翹��1');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','�翹����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','�翹�����');
		end
end

--��ӡ���������012��
set @AddControl='dlfh12'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh12','��������','�翹��2');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','�翹����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','�翹�����');
		end
end

--��ӡ���������013��
set @AddControl='dlfh13'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh13','��������','�翹��3');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','�翹����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','�翹�����');
		end
end

--��ӡ���������014��
set @AddControl='dlfh14'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh14','��������','�翹��4');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','�翹����ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','�翹�����');
		end
end

--��ӡ���������015��
set @AddControl='Dlfh15'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.'+@AddControl ,'��������','�����1');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','�������ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��������');
		end
end
--��ӡ���������016��
set @AddControl='Dlfh16'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.'+@AddControl ,'��������','��ֵϵͳ');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','�翹��','�豸����');
			--��ѹ�ȼ�
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','��ѹ�ȼ�');
			

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','ϵͳ��ɫ');
			
		end
end

/*****************************************
�ؼ�	��������
******************************************/
--��ӿؼ�	��������01 
set @AddControl='Dldz01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz01','��������','��������01');
end
--��ӿؼ�	��������02
set @AddControl='Dldz02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz02','��������','��������02');
end

--��ӿؼ�	��������03
set @AddControl='Dldz03'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������03');
end

--��ӿؼ�	��������04
set @AddControl='Dldz04'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������04');
end

--��ӿؼ�	��������05
set @AddControl='Dldz05'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������05');
end

--��ӿؼ�	��������06
set @AddControl='Dldz06'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������06');
end

--��ӿؼ�	��������07
set @AddControl='Dldz07'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������07');
end

--��ӿؼ�	��������08
set @AddControl='Dldz08'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������08');
end

--��ӿؼ�	��������09
set @AddControl='Dldz09'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������09');
end

--��ӿؼ�	��������10
set @AddControl='Dldz10'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������10');
end

--��ӿؼ�	��������11
set @AddControl='Dldz11'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������11');
end

--��ӿؼ�	��������12
set @AddControl='Dldz12'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������12');
end

--��ӿؼ�	��������13
set @AddControl='Dldz13'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������13');
end

--��ӿؼ�	��������14
set @AddControl='Dldz14'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������14');
end

--��ӿؼ�	��������15
set @AddControl='Dldz15'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������15');
end

--��ӿؼ�	��������16
set @AddControl='Dldz16'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������16');
end

--��ӿؼ�	��������17
set @AddControl='Dldz17'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������17');
end

--��ӿؼ�	��������18
set @AddControl='Dldz18'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������18');
end

--��ӿؼ�	��������19
set @AddControl='Dldz19'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������19');
end

--��ӿؼ�	��������20
set @AddControl='Dldz20'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������20');
end

--��ӿؼ�	��������21
set @AddControl='Dldz21'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������21');
end

--��ӿؼ�	��������22
set @AddControl='Dldz22'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������22');
end

--��ӿؼ�	��������23
set @AddControl='Dldz23'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������23');
end

--��ӿؼ�	��������24
set @AddControl='Dldz24'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������24');
end

--��ӿؼ�	��������17
set @AddControl='Dldz25'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������25');
end

--��ӿؼ�	��������26
set @AddControl='Dldz26'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������26');
end
/*****************************************
��ӿؼ�	��������
******************************************/

--��ӿؼ�	��������01
set @AddControl='Dqfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh01','��������','��������01');
end
--��ӿؼ�	��������02
set @AddControl='Dqfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '��ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh02','��������','��������02');
end

--update t_control set controltypeName='��������',controlCaption='��������02' where controlname='Dqfh02';
--update t_control set controltypeName='��������',controlCaption='��������01' where controlname='Dqfh01';


--��ӡ��Ǳ�1��
set @AddControl='Meter1'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter1','�Ǳ�','�Ǳ�1');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','6','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','4','���̶�');
	end
end

--��ӡ��Ǳ�2��
set @AddControl='Meter2'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter2','�Ǳ�','�Ǳ�2');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','60','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'Scale','10','���̶�');
	end
end

--��ӡ��Ǳ�3��
set @AddControl='Meter3'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter3','�Ǳ�','ָʾ��1');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','ָʾ��','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','100','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','100','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','5','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','3','���̶�');
	end
end

--��ӡ��Ǳ�4��
set @AddControl='Meter4'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter4','�Ǳ�','�Ǳ�4');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'MainScale','6','���̶�');
	end
end

--��ӡ��Ǳ�5��
set @AddControl='Meter5'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter5','�Ǳ�','�Ǳ�5');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'MainScale','6','���̶�');
	end
end

--��ӡ��Ǳ�6��
set @AddControl='Meter6'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter6','�Ǳ�','�Ǳ�6');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','6','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','4','���̶�');
	end
end

--��ӡ��Ǳ�7��
set @AddControl='Meter7'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter7','�Ǳ�','�Ǳ�7');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'MainScale','3','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'ViceScale','4','���̶�');
	end
end

--��ӡ��Ǳ�8��
set @AddControl='Meter8'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter8','�Ǳ�','�Ǳ�8');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'MainScale','6','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'ViceScale','4','���̶�');
	end
end

--��ӡ��Ǳ�9��
set @AddControl='Meter9'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter9','�Ǳ�','�Ǳ�9');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'MainScale','6','���̶�');
	end
end

--��ӡ��Ǳ�10��
set @AddControl='Meter10'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter10','�Ǳ�','�Ǳ�10');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','Voltage','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','6','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','4','���̶�');
	end
end

--��ӡ��Ǳ�11��
set @AddControl='Meter11'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter11','�Ǳ�','�Ǳ�11');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','100','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','10','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','1','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 8,'NormalFrom','40','���������');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 9,'NormalTo','60','�������䵽');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 10,'Warring1From','20','��������1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 11,'Warring1To','40','��������1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 12,'Warring2From','60','��������2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 13,'Warring2To','80','��������2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 14,'Exception1From','0','�쳣����1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 15,'Exception1To','20','�쳣����1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 16,'Exception2From','80','�쳣����2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 17,'Exception2To','100','�쳣����2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 18,'LabelColor','#FF000000','��ǩ��ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 19,'DialPlateBackColor','#FFFFFFFF','������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 20,'CalibrationColor','#FF0000FF','�̶��ı���ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 21,'NormalColor','#FF00E700','����������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 22,'WarringColor','#FFFFFF00','����������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 23,'ExceptionColor','#FFFF0000','�쳣������ɫ');
	end
end

--��ӡ��Ǳ�12��
set @AddControl='Meter12'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter12','�Ǳ�','�Ǳ�12');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','100','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','10','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','1','���̶�');
		
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 8,'BackColor','#FFCECBC5','������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 9,'LabelColor','#FF000000','��ǩ��ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 10,'DialPlateBackColor','#FFFFFFFF','������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 11,'DialPlateBorlderColor','#FF008040','����������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 12,'CalibrationColor','#FF0000FF','�̶��ı���ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 13,'CalibrationColor','#FF000000','�̶���ɫ');
	end
end

--��ӡ��Ǳ�13��
set @AddControl='Meter13'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '��ӿؼ�'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter13','�Ǳ�','�Ǳ�13');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','�Ǳ�','��ǩ');
		--��ѹ�ȼ�
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','��ǰֵ');
		--������ɫ
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','100','���ֵ');
		--���ݿ��
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','��Сֵ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','С��λ��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','10','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','1','���̶�');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 8,'NormalFrom','40','���������');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 9,'NormalTo','60','�������䵽');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 10,'Warring1From','20','��������1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 11,'Warring1To','40','��������1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 12,'Warring2From','60','��������2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 13,'Warring2To','80','��������2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 14,'Exception1From','0','�쳣����1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 15,'Exception1To','20','�쳣����1��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 16,'Exception2From','80','�쳣����2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 17,'Exception2To','100','�쳣����2��');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 18,'LabelColor','#FF000000','��ǩ��ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 19,'DialPlateBackColor','#FFFFFFFF','������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 20,'CalibrationColor','#FF0000FF','�̶��ı���ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 21,'NormalColor','#FF00E700','����������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 22,'WarringColor','#FFFFFF00','����������ɫ');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 23,'ExceptionColor','#FFFF0000','�쳣������ɫ');
	end
end




