﻿use [master]
GO

ALTER DATABASE [{DatabaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

RESTORE DATABASE [{DatabaseName}]
FROM DATABASE_SNAPSHOT='{SnapShotName}'
GO

ALTER DATABASE [{DatabaseName}] SET MULTI_USER
GO