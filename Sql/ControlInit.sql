declare @ControlNum int;--��ѯ�ؼ������������ж��Ƿ��Ѿ�����
set @ControlNum=0;
declare @AddControl varchar(10);--���ӿؼ�����

--���ӡ���������001��
set @AddControl='dlfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--���ݿ���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','���ݿ���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','��·����');
		end
end
--���ӡ���������002��
set @AddControl='dlfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--���ݿ���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','���ݿ���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','��·����');
		end
end

--���ӡ���������03-- �ӵ��ߡ�
set @AddControl='dlfh03'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--�ӵ��߿���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·����');
		end
end

--���ӡ���������04-- �ӵ��ߡ�
set @AddControl='dlfh04'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--�ӵ��߿���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·����');
		end
end

--���ӡ���������05-- �ӵ��ߡ�
set @AddControl='dlfh05'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--�ӵ��߿���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·����');
		end
end

--���ӡ���������06-- �ӵ��ߡ�
set @AddControl='dlfh06'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--�ӵ��߿���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·����');
		end
end


--���ӡ���������07-- �ӵ��ߡ�
set @AddControl='dlfh07'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
			--�ӵ��߿���
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','�ӵ��߿���');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','��·��ɫ');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','��·����');
		end
end

--���ӡ���������08-- �ӵ��ߡ�
set @AddControl='dlfh08'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 3,'LineWidth','1','��·����');
		end
end


--���ӡ���������09��
set @AddControl='dlfh09'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','ĸ�߿���');
		end
end

--���ӡ���������010��
set @AddControl='dlfh10'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','ĸ�߿���');
		end
end

--���ӡ���������011��
set @AddControl='dlfh11'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','�翹������');
		end
end

--���ӡ���������012��
set @AddControl='dlfh12'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','�翹������');
		end
end

--���ӡ���������013��
set @AddControl='dlfh13'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','�翹������');
		end
end

--���ӡ���������014��
set @AddControl='dlfh14'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','�翹������');
		end
end

--���ӡ���������015��
set @AddControl='Dlfh15'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
				 VALUES(@ControlID, 5,'LineWidth','1','���������');
		end
end
--���ӡ���������016��
set @AddControl='Dlfh16'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
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
--���ӿؼ�	��������01 
set @AddControl='Dldz01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz01','��������','��������01');
end
--���ӿؼ�	��������02
set @AddControl='Dldz02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz02','��������','��������02');
end

--���ӿؼ�	��������03
set @AddControl='Dldz03'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������03');
end

--���ӿؼ�	��������04
set @AddControl='Dldz04'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������04');
end

--���ӿؼ�	��������05
set @AddControl='Dldz05'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������05');
end

--���ӿؼ�	��������06
set @AddControl='Dldz06'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������06');
end

--���ӿؼ�	��������07
set @AddControl='Dldz07'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������07');
end

--���ӿؼ�	��������08
set @AddControl='Dldz08'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.'+@AddControl,'��������','��������08');
end

/*****************************************
���ӿؼ�	��������
******************************************/

--���ӿؼ�	��������01
set @AddControl='Dqfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh01','��������','��������01');
end
--���ӿؼ�	��������02
set @AddControl='Dqfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '���ӿؼ�'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh02','��������','��������02');
end

--update t_control set controltypeName='��������',controlCaption='��������02' where controlname='Dqfh02';
--update t_control set controltypeName='��������',controlCaption='��������01' where controlname='Dqfh01';
