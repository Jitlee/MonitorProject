declare @ControlNum int;--查询控件数量，用于判断是否已经添加
set @ControlNum=0;
declare @AddControl varchar(10);--添加控件名称

--添加“电力符号001”
set @AddControl='dlfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh01','电力符号','电力符号001');


		declare @ControlID int;
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
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
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','电容宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','线路宽度');
		end
end
--添加“电力符号002”
set @AddControl='dlfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh02','电力符号','电力符号002');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
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
				 VALUES(@ControlID, 4,'CapacitiveWidth','1','电容宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 6,'LineWidth','1','线路宽度');
		end
end

--添加“电力符号03-- 接地线”
set @AddControl='dlfh03'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh03','电力符号','接地线');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');			
			--接地线颜色
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','接地线颜色');
			--接地线宽度
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','接地线宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','线路宽度');
		end
end

--添加“电力符号04-- 接地线”
set @AddControl='dlfh04'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh04','电力符号','接地线');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');			
			--接地线颜色
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','接地线颜色');
			--接地线宽度
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','接地线宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','线路宽度');
		end
end

--添加“电力符号05-- 接地线”
set @AddControl='dlfh05'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh05','电力符号','接地线');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');			
			--接地线颜色
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','接地线颜色');
			--接地线宽度
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','接地线宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','线路宽度');
		end
end

--添加“电力符号06-- 接地线”
set @AddControl='dlfh06'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh06','电力符号','接地线');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');			
			--接地线颜色
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','接地线颜色');
			--接地线宽度
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','接地线宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','线路宽度');
		end
end


--添加“电力符号07-- 接地线”
set @AddControl='dlfh07'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh07','电力符号','接地线');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');			
			--接地线颜色
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'GroundWireColor','#FFFA0000','接地线颜色');
			--接地线宽度
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'GroundWireWidth','1','接地线宽度');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FF0B0A0A','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','线路宽度');
		end
end

--添加“电力符号08-- 接地线”
set @AddControl='dlfh08'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh08','电力符号','电力符号08');
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'LineColor','#FFED1212','线路颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'LineWidth','1','线路宽度');
		end
end


--添加“电力符号09”
set @AddControl='dlfh09'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh09','电力符号','母线02');

		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');
			--电压等级
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','电压等级');
			--是否立体
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'ISLT','False','是否立体');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','母线颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','母线宽度');
		end
end

--添加“电力符号010”
set @AddControl='dlfh10'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'5','MonitorSystem.Dlfh.Dlfh10','电力符号','母线02');
		
		set @ControlID=0;
		select @ControlID=max(controlid)  from t_control
		if @ControlID > 0
		begin
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 1,'DeviceName','电容器','设备名称');
			--电压等级
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 2,'Voltagelevel','10','电压等级');
			--是否立体
			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 3,'ISLT','False','是否立体');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 4,'LineColor','#FFED1212','母线颜色');

			INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
				 VALUES(@ControlID, 5,'LineWidth','1','母线宽度');
		end
end


/*****************************************
控件	电力电子
******************************************/
--添加控件	电力电子01 
set @AddControl='Dldz01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz01','电力电子','电力电子01');
end
--添加控件	电力电子02
set @AddControl='Dldz02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'6','MonitorSystem.Dldz.Dldz02','电力电子','电力电子02');
end

/*****************************************
添加控件	电气符号
******************************************/

--添加控件	电气符号01
set @AddControl='Dqfh01'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh01','电气符号','电气符号01');
end
--添加控件	电气符号02
set @AddControl='Dqfh02'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
		print '添加控件'
		print @AddControl
		insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
		values(@AddControl,'7','MonitorSystem.Dqfh.Dqfh02','电气符号','电气符号02');
end

--update t_control set controltypeName='电气符号',controlCaption='电气符号02' where controlname='Dqfh02';
--update t_control set controltypeName='电气符号',controlCaption='电气符号01' where controlname='Dqfh01';


--添加“仪表1”
set @AddControl='Meter1'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '添加控件'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter1','仪表','仪表1');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','仪表','标签');
		--电压等级
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','0','当前值');
		--电容颜色
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','最大值');
		--电容宽度
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','最小值');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 5,'DecimalDigits','0','小数位数');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'MainScale','6','主刻度');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 7,'ViceScale','4','副刻度');
	end
end

--添加“仪表1”
set @AddControl='Meter2'
select @ControlNum=count(*) from t_control where controlname=@AddControl
if @ControlNum = 0
begin
	print '添加控件'
	print @AddControl
	insert into t_control (controlname,controltype,imageUrl,controltypeName,controlCaption)
	values(@AddControl,'4','MonitorSystem.Gallery.Meter.Meter2','仪表','仪表2');

	set @ControlID=0;
	select @ControlID=max(controlid)  from t_control
	if @ControlID > 0
	begin
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 1,'Text','仪表','标签');
		--电压等级
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 2,'Value','60','当前值');
		--电容颜色
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 3,'Maximum','60','最大值');
		--电容宽度
		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 4,'Minimum','0','最小值');

		INSERT INTO [t_ControlProperty]([ControlID],[PropertyNo],[PropertyName],[DefaultValue],[Caption])
			 VALUES(@ControlID, 6,'Scale','10','主刻度');
	end
end

