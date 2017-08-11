
CREATE VIEW [dbo].[vwUserUserGroupRolePermissions] 
AS
	SELECT d.UserID AS UserID, RoleId, 
			cast(max(cast(a.AllowAdd as int)) as bit) AS AllowAdd, 
			cast(max(cast (a.Allowedit as int)) as bit) AS AllowEdit, 
			cast(max(cast(a.allowview as int)) as bit) AS AllowView, 
			cast(max(cast(a.allowdelete as int)) as bit) AS AllowDelete, 
			cast(max(cast (a.allowprint as int)) as bit) AS AllowPrint
	FROM UserGroupRolePermissions a
	INNER JOIN UserGroupRoles b ON a.UserGroupRolePermissionId = b.UserGroupRolePermissionId
	INNER JOIN UserUserGroups d ON d.UserGroupId = b.UserGroupId
	INNER JOIN Users u ON d.UserId = u.UserId
	GROUP BY d.UserID,Username, a.RoleID