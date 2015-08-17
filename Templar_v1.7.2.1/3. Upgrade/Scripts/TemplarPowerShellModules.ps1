Function Create-TemplarDatabase
{
    <#
	.SYNOPSIS
	    Database-Setup

	.DESCRIPTION
	    Setup new database or upgrade existing Templar database.
			
	.PARAMETER DeployToDatabase
		Specifies whether to deploy update script to database.
		0 - Only generate script
		1 - Generate script & deploy it to database
		
	.PARAMETER Server
	    Specifies a database server name.
	
	.PARAMETER DatabaseName
	    Specifies a database name. 
			
	.PARAMETER Username
	    Specifies a username for SQL Authenticaion. 
		
	.PARAMETER Password
	    Specifies a password for SQL Authentication.	
				
	.EXAMPLE
		PS C:\> Create-TemplarDatabase -DeployToDatabase 1 -Server "Alpha-Sql" -DatabaseName "dTemplar" -AuthenticationMode "Windows"  -UserName "sa" -Password "test123!@#"
		
	.NOTES
		For any queries/issues contact templar@tavisca.com
		
	#>
	[CmdletBinding(
    	SupportsShouldProcess=$True,
        ConfirmImpact="Low"
    )]		
	Param
	(   
		[Parameter(Position=0,Mandatory=$true)]
		[bool]$DeployToDatabase=$true,
		
		[Parameter(Position=1,Mandatory=$true)]
		[String]$Server,
		
		[Parameter(Position=2,Mandatory=$true)]
		[String]$DatabaseName,
			
		[Parameter(Position=3,Mandatory=$false, ParameterSetName="SQLAuth")]
		[String]$Username,
		
		[Parameter(Position=4,Mandatory=$false, ParameterSetName="SQLAuth")]
		[String]$Password
	)

	Begin
	{
	}
	
	Process
	{
		switch ($PsCmdlet.ParameterSetName) 
		{ 
			"SQLAuth"  
			{ 
				Write-Host Running under SQL Authentication			
				$output =""
				.\bin\SqlPackage.exe /Action:Script /OutputPath:.\TemplarDatabase-CreateScript.sql /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=True /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;User ID=$Username;Password=$Password" /v:DeployTestData=N | Out-File ".\Install.log"
				if($LastExitCode -ne 0)
				{	
				
					return;
				}
				if($DeployToDatabase)
				{
					.\bin\SqlPackage.exe /Action:Publish /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=True /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;User ID=$Username;Password=$Password" /v:DeployTestData=N | Out-File ".\Install.log"
					if ($LastExitCode -eq 0)
					{
						Write-Host "Finished DB Deployment"
						Write-Host "Please check install.log file in case of errors"
					}
				}
				break;
			} 
			default 
			{				
				Write-Host "Running under Windows Authentication"
				.\bin\SqlPackage.exe /Action:Script /OutputPath:.\TemplarDatabase-CreateScript.sql /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=True /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;Integrated Security=True" /v:DeployTestData=N | Out-File ".\Install.log"
				if($LastExitCode -ne 0)
				{
					return;
				}
				if($DeployToDatabase)
				{
					.\bin\SqlPackage.exe /Action:Publish /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=True /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;Integrated Security=True" /v:DeployTestData=N | Out-File ".\Install.log"
					if ($LastExitCode -eq 0)
					{
						Write-Host "Finished DB Deployment"
						Write-Host "Please check install.log file in case of errors"
					}
				}
				break
			}
		} 

	

	} #End Process
	
	End{}
}

Function Upgrade-TemplarDatabase
{
    <#
	.SYNOPSIS
	    Database-Setup

	.DESCRIPTION
	    Setup new database or upgrade existing Templar database.
			
	.PARAMETER DeployToDatabase
		Specifies whether to deploy update script to database.
		0 - Only generate script
		1 - Generate script & deploy it to database
		
	.PARAMETER Server
	    Specifies a database server name.
	
	.PARAMETER DatabaseName
	    Specifies a database name. 
			
	.PARAMETER Username
	    Specifies a username for SQL Authenticaion. 
		
	.PARAMETER Password
	    Specifies a password for SQL Authentication.	
				
	.EXAMPLE
		PS C:\> Upgrade-TemplarDatabase -DeployToDatabase 1 -Server "Alpha-Sql" -DatabaseName "dTemplar" -AuthenticationMode "Windows"  -UserName "sa" -Password "test123!@#" -Verbose
		
	.NOTES
		For any queries/issues contact templar@tavisca.com
		
	#>
	[CmdletBinding(
    	SupportsShouldProcess=$True,
        ConfirmImpact="Low"
    )]		
	Param
	(   
		[Parameter(Position=0,Mandatory=$true)]
		[bool]$DeployToDatabase=$true,
		
		[Parameter(Position=1,Mandatory=$true)]
		[String]$Server,
		
		[Parameter(Position=2,Mandatory=$true)]
		[String]$DatabaseName,
			
		[Parameter(Position=3,Mandatory=$false, ParameterSetName="SQLAuth")]
		[String]$Username,
		
		[Parameter(Position=4,Mandatory=$false, ParameterSetName="SQLAuth")]
		[String]$Password
	)

	Begin
	{
	}
	
	Process
	{
		switch ($PsCmdlet.ParameterSetName) 
		{ 
			"SQLAuth"  
			{ 
				if(Test-Path $PSScriptRoot\data\PreDeployment.sql)
				{
					Write-Host Execute Pre-deployment script
					Add-PSSnapin SqlServerCmdletSnapin100
					Add-PSSnapin SqlServerProviderSnapin100
					invoke-sqlcmd -ServerInstance $Server -U $Username -P $Password -Database $DatabaseName -InputFile  $PSScriptRoot\data\PreDeployment.sql -Verbose
				}
				Write-Host Running under SQL Authentication			
				$output =""
				.\bin\SqlPackage.exe /Action:Script /OutputPath:.\TemplarDatabase-UpdateScript.sql /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=False /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;User ID=$Username;Password=$Password" /v:DeployTestData=N | Out-File ".\Install.log"
				if($LastExitCode -ne 0)
				{	
				
					return;
				}
				if($DeployToDatabase)
				{
					.\bin\SqlPackage.exe /Action:Publish /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=False /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;User ID=$Username;Password=$Password" /v:DeployTestData=N | Out-File ".\Install.log"
					if ($LastExitCode -eq 0)
					{
						Write-Host "Finished DB Deployment"
						Write-Host "Please check install.log file in case of errors"
					}
				}
				break;
			} 
			default 
			{	if(Test-Path $PSScriptRoot\data\PreDeployment.sql)
				{
					Write-Host Execute Pre-deployment script
					Add-PSSnapin SqlServerCmdletSnapin100
					Add-PSSnapin SqlServerProviderSnapin100
					invoke-sqlcmd -ServerInstance $Server -Database $DatabaseName -InputFile  $PSScriptRoot\data\PreDeployment.sql -Verbose
				}
				Write-Host "Running under Windows Authentication"
				.\bin\SqlPackage.exe /Action:Script /OutputPath:.\TemplarDatabase-UpdateScript.sql /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=False /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;Integrated Security=True" /v:DeployTestData=N | Out-File ".\Install.log"
				if($LastExitCode -ne 0)
				{
					return;
				}
				if($DeployToDatabase)
				{
					.\bin\SqlPackage.exe /Action:Publish /SourceFile:.\data\Tavisca.Templar.Database.dacpac /p:CreateNewDatabase=False /p:VerifyDeployment=True /TargetConnectionString:"Data Source=$Server;Initial Catalog=$DatabaseName;Integrated Security=True" /v:DeployTestData=N | Out-File ".\Install.log"
					if ($LastExitCode -eq 0)
					{
						Write-Host "Finished DB Deployment"
						Write-Host "Please check install.log file in case of errors"
					}
				}
				break
			}
		} 

	

	} #End Process
	
	End{}
}

