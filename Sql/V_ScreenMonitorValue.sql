
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[V_ScreenMonitorValue]
as
select vc.*,tv.StationID,tv.ChanenlSubNo,tv.MonitorValue,tv.flag  from (
select line.id,line.ElementID,line.ScreenID,line.DeviceID,line.ChannelNo,line.ComputeStr
from t_Element_RealTimeLine line
union
select distinct newid() id, tel.ElementID,tel.ScreenID,tel.DeviceID,tel.ChannelNo,tel.ComputeStr
from t_element tel

) as vc
inner join t_Screen ts  on vc.ScreenID=ts.ScreenID
inner join MonitorDemo2.dbo.t_TmpValue tv  on ts.StationID=tv.StationID and vc.deviceid=tv.deviceid
and vc.channelNO=tv.channelNo
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

