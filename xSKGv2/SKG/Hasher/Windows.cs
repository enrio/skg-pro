using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Hasher
{
    using System.Data;
    using System.Management;

    /// <summary>
    /// Windows OS processing
    /// </summary>
    public class Windows
    {
        #region Const Win32
        public const string Win32_1394Controller = "Win32_1394Controller";
        public const string Win32_1394ControllerDevice = "Win32_1394ControllerDevice";
        public const string Win32_Account = "Win32_Account";
        public const string Win32_AccountSID = "Win32_AccountSID";
        public const string Win32_ACE = "Win32_ACE";
        public const string Win32_ActionCheck = "Win32_ActionCheck";
        public const string Win32_AllocatedResource = "Win32_AllocatedResource";
        public const string Win32_ApplicationCommandLine = "Win32_ApplicationCommandLine";
        public const string Win32_ApplicationService = "Win32_ApplicationService";
        public const string Win32_AssociatedBattery = "Win32_AssociatedBattery";
        public const string Win32_AssociatedProcessorMemory = "Win32_AssociatedProcessorMemory";
        public const string Win32_BaseBoard = "Win32_BaseBoard";
        public const string Win32_BaseService = "Win32_BaseService";
        public const string Win32_Battery = "Win32_Battery";
        public const string Win32_Binary = "Win32_Binary";
        public const string Win32_BindImageAction = "Win32_BindImageAction";
        public const string Win32_BIOS = "Win32_BIOS";
        public const string Win32_BootConfiguration = "Win32_BootConfiguration";
        public const string Win32_Bus = "Win32_Bus";
        public const string Win32_CacheMemory = "Win32_CacheMemory";
        public const string Win32_CDROMDrive = "Win32_CDROMDrive";
        public const string Win32_CheckCheck = "Win32_CheckCheck";
        public const string Win32_CIMLogicalDeviceCIMDataFile = "Win32_CIMLogicalDeviceCIMDataFile";
        public const string Win32_ClassicCOMApplicationClasses = "Win32_ClassicCOMApplicationClasses";
        public const string Win32_ClassicCOMClass = "Win32_ClassicCOMClass";
        public const string Win32_ClassicCOMClassSetting = "Win32_ClassicCOMClassSetting";
        public const string Win32_ClassicCOMClassSettings = "Win32_ClassicCOMClassSettings";
        public const string Win32_ClassInfoAction = "Win32_ClassInfoAction";
        public const string Win32_ClientApplicationSetting = "Win32_ClientApplicationSetting";
        public const string Win32_CodecFile = "Win32_CodecFile";
        public const string Win32_COMApplication = "Win32_COMApplication";
        public const string Win32_COMApplicationClasses = "Win32_COMApplicationClasses";
        public const string Win32_COMApplicationSettings = "Win32_COMApplicationSettings";
        public const string Win32_COMClass = "Win32_COMClass";
        public const string Win32_ComClassAutoEmulator = "Win32_ComClassAutoEmulator";
        public const string Win32_ComClassEmulator = "Win32_ComClassEmulator";
        public const string Win32_CommandLineAccess = "Win32_CommandLineAccess";
        public const string Win32_ComponentCategory = "Win32_ComponentCategory";
        public const string Win32_ComputerSystem = "Win32_ComputerSystem";
        public const string Win32_ComputerSystemProcessor = "Win32_ComputerSystemProcessor";
        public const string Win32_ComputerSystemProduct = "Win32_ComputerSystemProduct";
        public const string Win32_COMSetting = "Win32_COMSetting";
        public const string Win32_Condition = "Win32_Condition";
        public const string Win32_CreateFolderAction = "Win32_CreateFolderAction";
        public const string Win32_CurrentProbe = "Win32_CurrentProbe";
        public const string Win32_DCOMApplication = "Win32_DCOMApplication";
        public const string Win32_DCOMApplicationAccessAllowedSetting = "Win32_DCOMApplicationAccessAllowedSetting";
        public const string Win32_DCOMApplicationLaunchAllowedSetting = "Win32_DCOMApplicationLaunchAllowedSetting";
        public const string Win32_DCOMApplicationSetting = "Win32_DCOMApplicationSetting";
        public const string Win32_DependentService = "Win32_DependentService";
        public const string Win32_Desktop = "Win32_Desktop";
        public const string Win32_DesktopMonitor = "Win32_DesktopMonitor";
        public const string Win32_DeviceBus = "Win32_DeviceBus";
        public const string Win32_DeviceMemoryAddress = "Win32_DeviceMemoryAddress";
        public const string Win32_DeviceSettings = "Win32_DeviceSettings";
        public const string Win32_Directory = "Win32_Directory";
        public const string Win32_DirectorySpecification = "Win32_DirectorySpecification";
        public const string Win32_DiskDrive = "Win32_DiskDrive";
        public const string Win32_DiskDriveToDiskPartition = "Win32_DiskDriveToDiskPartition";
        public const string Win32_DiskPartition = "Win32_DiskPartition";
        public const string Win32_DisplayConfiguration = "Win32_DisplayConfiguration";
        public const string Win32_DisplayControllerConfiguration = "Win32_DisplayControllerConfiguration";
        public const string Win32_DMAChannel = "Win32_DMAChannel";
        public const string Win32_DriverVXD = "Win32_DriverVXD";
        public const string Win32_DuplicateFileAction = "Win32_DuplicateFileAction";
        public const string Win32_Environment = "Win32_Environment";
        public const string Win32_EnvironmentSpecification = "Win32_EnvironmentSpecification";
        public const string Win32_ExtensionInfoAction = "Win32_ExtensionInfoAction";
        public const string Win32_Fan = "Win32_Fan";
        public const string Win32_FileSpecification = "Win32_FileSpecification";
        public const string Win32_FloppyController = "Win32_FloppyController";
        public const string Win32_FloppyDrive = "Win32_FloppyDrive";
        public const string Win32_FontInfoAction = "Win32_FontInfoAction";
        public const string Win32_Group = "Win32_Group";
        public const string Win32_GroupUser = "Win32_GroupUser";
        public const string Win32_HeatPipe = "Win32_HeatPipe";
        public const string Win32_IDEController = "Win32_IDEController";
        public const string Win32_IDEControllerDevice = "Win32_IDEControllerDevice";
        public const string Win32_ImplementedCategory = "Win32_ImplementedCategory";
        public const string Win32_InfraredDevice = "Win32_InfraredDevice";
        public const string Win32_IniFileSpecification = "Win32_IniFileSpecification";
        public const string Win32_InstalledSoftwareElement = "Win32_InstalledSoftwareElement";
        public const string Win32_IRQResource = "Win32_IRQResource";
        public const string Win32_Keyboard = "Win32_Keyboard";
        public const string Win32_LaunchCondition = "Win32_LaunchCondition";
        public const string Win32_LoadOrderGroup = "Win32_LoadOrderGroup";
        public const string Win32_LoadOrderGroupServiceDependencies = "Win32_LoadOrderGroupServiceDependencies";
        public const string Win32_LoadOrderGroupServiceMembers = "Win32_LoadOrderGroupServiceMembers";
        public const string Win32_LogicalDisk = "Win32_LogicalDisk";
        public const string Win32_LogicalDiskRootDirectory = "Win32_LogicalDiskRootDirectory";
        public const string Win32_LogicalDiskToPartition = "Win32_LogicalDiskToPartition";
        public const string Win32_LogicalFileAccess = "Win32_LogicalFileAccess";
        public const string Win32_LogicalFileAuditing = "Win32_LogicalFileAuditing";
        public const string Win32_LogicalFileGroup = "Win32_LogicalFileGroup";
        public const string Win32_LogicalFileOwner = "Win32_LogicalFileOwner";
        public const string Win32_LogicalFileSecuritySetting = "Win32_LogicalFileSecuritySetting";
        public const string Win32_LogicalMemoryConfiguration = "Win32_LogicalMemoryConfiguration";
        public const string Win32_LogicalProgramGroup = "Win32_LogicalProgramGroup";
        public const string Win32_LogicalProgramGroupDirectory = "Win32_LogicalProgramGroupDirectory";
        public const string Win32_LogicalProgramGroupItem = "Win32_LogicalProgramGroupItem";
        public const string Win32_LogicalProgramGroupItemDataFile = "Win32_LogicalProgramGroupItemDataFile";
        public const string Win32_LogicalShareAccess = "Win32_LogicalShareAccess";
        public const string Win32_LogicalShareAuditing = "Win32_LogicalShareAuditing";
        public const string Win32_LogicalShareSecuritySetting = "Win32_LogicalShareSecuritySetting";
        public const string Win32_ManagedSystemElementResource = "Win32_ManagedSystemElementResource";
        public const string Win32_MemoryArray = "Win32_MemoryArray";
        public const string Win32_MemoryArrayLocation = "Win32_MemoryArrayLocation";
        public const string Win32_MemoryDevice = "Win32_MemoryDevice";
        public const string Win32_MemoryDeviceArray = "Win32_MemoryDeviceArray";
        public const string Win32_MemoryDeviceLocation = "Win32_MemoryDeviceLocation";
        public const string Win32_MethodParameterClass = "Win32_MethodParameterClass";
        public const string Win32_MIMEInfoAction = "Win32_MIMEInfoAction";
        public const string Win32_MotherboardDevice = "Win32_MotherboardDevice";
        public const string Win32_MoveFileAction = "Win32_MoveFileAction";
        public const string Win32_MSIResource = "Win32_MSIResource";
        public const string Win32_NetworkAdapter = "Win32_NetworkAdapter";
        public const string Win32_NetworkAdapterConfiguration = "Win32_NetworkAdapterConfiguration";
        public const string Win32_NetworkAdapterSetting = "Win32_NetworkAdapterSetting";
        public const string Win32_NetworkClient = "Win32_NetworkClient";
        public const string Win32_NetworkConnection = "Win32_NetworkConnection";
        public const string Win32_NetworkLoginProfile = "Win32_NetworkLoginProfile";
        public const string Win32_NetworkProtocol = "Win32_NetworkProtocol";
        public const string Win32_NTEventlogFile = "Win32_NTEventlogFile";
        public const string Win32_NTLogEvent = "Win32_NTLogEvent";
        public const string Win32_NTLogEventComputer = "Win32_NTLogEventComputer";
        public const string Win32_NTLogEventLog = "Win32_NTLogEventLog";
        public const string Win32_NTLogEventUser = "Win32_NTLogEventUser";
        public const string Win32_ODBCAttribute = "Win32_ODBCAttribute";
        public const string Win32_ODBCDataSourceAttribute = "Win32_ODBCDataSourceAttribute";
        public const string Win32_ODBCDataSourceSpecification = "Win32_ODBCDataSourceSpecification";
        public const string Win32_ODBCDriverAttribute = "Win32_ODBCDriverAttribute";
        public const string Win32_ODBCDriverSoftwareElement = "Win32_ODBCDriverSoftwareElement";
        public const string Win32_ODBCDriverSpecification = "Win32_ODBCDriverSpecification";
        public const string Win32_ODBCSourceAttribute = "Win32_ODBCSourceAttribute";
        public const string Win32_ODBCTranslatorSpecification = "Win32_ODBCTranslatorSpecification";
        public const string Win32_OnBoardDevice = "Win32_OnBoardDevice";
        public const string Win32_OperatingSystem = "Win32_OperatingSystem";
        public const string Win32_OperatingSystemQFE = "Win32_OperatingSystemQFE";
        public const string Win32_OSRecoveryConfiguration = "Win32_OSRecoveryConfiguration";
        public const string Win32_PageFile = "Win32_PageFile";
        public const string Win32_PageFileElementSetting = "Win32_PageFileElementSetting";
        public const string Win32_PageFileSetting = "Win32_PageFileSetting";
        public const string Win32_PageFileUsage = "Win32_PageFileUsage";
        public const string Win32_ParallelPort = "Win32_ParallelPort";
        public const string Win32_Patch = "Win32_Patch";
        public const string Win32_PatchFile = "Win32_PatchFile";
        public const string Win32_PatchPackage = "Win32_PatchPackage";
        public const string Win32_PCMCIAController = "Win32_PCMCIAController";
        public const string Win32_Perf = "Win32_Perf";
        public const string Win32_PerfRawData = "Win32_PerfRawData";
        public const string Win32_PerfRawData_ASP_ActiveServerPages = "Win32_PerfRawData_ASP_ActiveServerPages";
        public const string Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322 = "Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322";
        public const string Win32_PerfRawData_ASPNET_114322_ASPNETv114322 = "Win32_PerfRawData_ASPNET_114322_ASPNETv114322";
        public const string Win32_PerfRawData_ASPNET_ASPNET = "Win32_PerfRawData_ASPNET_ASPNET";
        public const string Win32_PerfRawData_ASPNET_ASPNETApplications = "Win32_PerfRawData_ASPNET_ASPNETApplications";
        public const string Win32_PerfRawData_IAS_IASAccountingClients = "Win32_PerfRawData_IAS_IASAccountingClients";
        public const string Win32_PerfRawData_IAS_IASAccountingServer = "Win32_PerfRawData_IAS_IASAccountingServer";
        public const string Win32_PerfRawData_IAS_IASAuthenticationClients = "Win32_PerfRawData_IAS_IASAuthenticationClients";
        public const string Win32_PerfRawData_IAS_IASAuthenticationServer = "Win32_PerfRawData_IAS_IASAuthenticationServer";
        public const string Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal = "Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal";
        public const string Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator = "Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator";
        public const string Win32_PerfRawData_MSFTPSVC_FTPService = "Win32_PerfRawData_MSFTPSVC_FTPService";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods = "Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice = "Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager = "Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition = "Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager = "Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases = "Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics = "Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerLatches = "Win32_PerfRawData_MSSQLSERVER_SQLServerLatches";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerLocks = "Win32_PerfRawData_MSSQLSERVER_SQLServerLocks";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager = "Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents = "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist = "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader = "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge = "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot = "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics = "Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics";
        public const string Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable = "Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable";
        public const string Win32_PerfRawData_NETFramework_NETCLRExceptions = "Win32_PerfRawData_NETFramework_NETCLRExceptions";
        public const string Win32_PerfRawData_NETFramework_NETCLRInterop = "Win32_PerfRawData_NETFramework_NETCLRInterop";
        public const string Win32_PerfRawData_NETFramework_NETCLRJit = "Win32_PerfRawData_NETFramework_NETCLRJit";
        public const string Win32_PerfRawData_NETFramework_NETCLRLoading = "Win32_PerfRawData_NETFramework_NETCLRLoading";
        public const string Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads = "Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads";
        public const string Win32_PerfRawData_NETFramework_NETCLRMemory = "Win32_PerfRawData_NETFramework_NETCLRMemory";
        public const string Win32_PerfRawData_NETFramework_NETCLRRemoting = "Win32_PerfRawData_NETFramework_NETCLRRemoting";
        public const string Win32_PerfRawData_NETFramework_NETCLRSecurity = "Win32_PerfRawData_NETFramework_NETCLRSecurity";
        public const string Win32_PerfRawData_Outlook_Outlook = "Win32_PerfRawData_Outlook_Outlook";
        public const string Win32_PerfRawData_PerfDisk_PhysicalDisk = "Win32_PerfRawData_PerfDisk_PhysicalDisk";
        public const string Win32_PerfRawData_PerfNet_Browser = "Win32_PerfRawData_PerfNet_Browser";
        public const string Win32_PerfRawData_PerfNet_Redirector = "Win32_PerfRawData_PerfNet_Redirector";
        public const string Win32_PerfRawData_PerfNet_Server = "Win32_PerfRawData_PerfNet_Server";
        public const string Win32_PerfRawData_PerfNet_ServerWorkQueues = "Win32_PerfRawData_PerfNet_ServerWorkQueues";
        public const string Win32_PerfRawData_PerfOS_Cache = "Win32_PerfRawData_PerfOS_Cache";
        public const string Win32_PerfRawData_PerfOS_Memory = "Win32_PerfRawData_PerfOS_Memory";
        public const string Win32_PerfRawData_PerfOS_Objects = "Win32_PerfRawData_PerfOS_Objects";
        public const string Win32_PerfRawData_PerfOS_PagingFile = "Win32_PerfRawData_PerfOS_PagingFile";
        public const string Win32_PerfRawData_PerfOS_Processor = "Win32_PerfRawData_PerfOS_Processor";
        public const string Win32_PerfRawData_PerfOS_System = "Win32_PerfRawData_PerfOS_System";
        public const string Win32_PerfRawData_PerfProc_FullImage_Costly = "Win32_PerfRawData_PerfProc_FullImage_Costly";
        public const string Win32_PerfRawData_PerfProc_Image_Costly = "Win32_PerfRawData_PerfProc_Image_Costly";
        public const string Win32_PerfRawData_PerfProc_JobObject = "Win32_PerfRawData_PerfProc_JobObject";
        public const string Win32_PerfRawData_PerfProc_JobObjectDetails = "Win32_PerfRawData_PerfProc_JobObjectDetails";
        public const string Win32_PerfRawData_PerfProc_Process = "Win32_PerfRawData_PerfProc_Process";
        public const string Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly = "Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly";
        public const string Win32_PerfRawData_PerfProc_Thread = "Win32_PerfRawData_PerfProc_Thread";
        public const string Win32_PerfRawData_PerfProc_ThreadDetails_Costly = "Win32_PerfRawData_PerfProc_ThreadDetails_Costly";
        public const string Win32_PerfRawData_RemoteAccess_RASPort = "Win32_PerfRawData_RemoteAccess_RASPort";
        public const string Win32_PerfRawData_RemoteAccess_RASTotal = "Win32_PerfRawData_RemoteAccess_RASTotal";
        public const string Win32_PerfRawData_RSVP_ACSPerRSVPService = "Win32_PerfRawData_RSVP_ACSPerRSVPService";
        public const string Win32_PerfRawData_Spooler_PrintQueue = "Win32_PerfRawData_Spooler_PrintQueue";
        public const string Win32_PerfRawData_TapiSrv_Telephony = "Win32_PerfRawData_TapiSrv_Telephony";
        public const string Win32_PerfRawData_Tcpip_ICMP = "Win32_PerfRawData_Tcpip_ICMP";
        public const string Win32_PerfRawData_Tcpip_IP = "Win32_PerfRawData_Tcpip_IP";
        public const string Win32_PerfRawData_Tcpip_NBTConnection = "Win32_PerfRawData_Tcpip_NBTConnection";
        public const string Win32_PerfRawData_Tcpip_NetworkInterface = "Win32_PerfRawData_Tcpip_NetworkInterface";
        public const string Win32_PerfRawData_Tcpip_TCP = "Win32_PerfRawData_Tcpip_TCP";
        public const string Win32_PerfRawData_Tcpip_UDP = "Win32_PerfRawData_Tcpip_UDP";
        public const string Win32_PerfRawData_W3SVC_WebService = "Win32_PerfRawData_W3SVC_WebService";
        public const string Win32_PhysicalMemory = "Win32_PhysicalMemory";
        public const string Win32_PhysicalMemoryArray = "Win32_PhysicalMemoryArray";
        public const string Win32_PhysicalMemoryLocation = "Win32_PhysicalMemoryLocation";
        public const string Win32_PNPAllocatedResource = "Win32_PNPAllocatedResource";
        public const string Win32_PnPDevice = "Win32_PnPDevice";
        public const string Win32_PnPEntity = "Win32_PnPEntity";
        public const string Win32_PointingDevice = "Win32_PointingDevice";
        public const string Win32_PortableBattery = "Win32_PortableBattery";
        public const string Win32_PortConnector = "Win32_PortConnector";
        public const string Win32_PortResource = "Win32_PortResource";
        public const string Win32_POTSModem = "Win32_POTSModem";
        public const string Win32_POTSModemToSerialPort = "Win32_POTSModemToSerialPort";
        public const string Win32_PowerManagementEvent = "Win32_PowerManagementEvent";
        public const string Win32_Printer = "Win32_Printer";
        public const string Win32_PrinterConfiguration = "Win32_PrinterConfiguration";
        public const string Win32_PrinterController = "Win32_PrinterController";
        public const string Win32_PrinterDriverDll = "Win32_PrinterDriverDll";
        public const string Win32_PrinterSetting = "Win32_PrinterSetting";
        public const string Win32_PrinterShare = "Win32_PrinterShare";
        public const string Win32_PrintJob = "Win32_PrintJob";
        public const string Win32_PrivilegesStatus = "Win32_PrivilegesStatus";
        public const string Win32_Process = "Win32_Process";
        public const string Win32_Processor = "Win32_Processor";
        public const string Win32_ProcessStartup = "Win32_ProcessStartup";
        public const string Win32_Product = "Win32_Product";
        public const string Win32_ProductCheck = "Win32_ProductCheck";
        public const string Win32_ProductResource = "Win32_ProductResource";
        public const string Win32_ProductSoftwareFeatures = "Win32_ProductSoftwareFeatures";
        public const string Win32_ProgIDSpecification = "Win32_ProgIDSpecification";
        public const string Win32_ProgramGroup = "Win32_ProgramGroup";
        public const string Win32_ProgramGroupContents = "Win32_ProgramGroupContents";
        public const string Win32_ProgramGroupOrItem = "Win32_ProgramGroupOrItem";
        public const string Win32_Property = "Win32_Property";
        public const string Win32_ProtocolBinding = "Win32_ProtocolBinding";
        public const string Win32_PublishComponentAction = "Win32_PublishComponentAction";
        public const string Win32_QuickFixEngineering = "Win32_QuickFixEngineering";
        public const string Win32_Refrigeration = "Win32_Refrigeration";
        public const string Win32_Registry = "Win32_Registry";
        public const string Win32_RegistryAction = "Win32_RegistryAction";
        public const string Win32_RemoveFileAction = "Win32_RemoveFileAction";
        public const string Win32_RemoveIniAction = "Win32_RemoveIniAction";
        public const string Win32_ReserveCost = "Win32_ReserveCost";
        public const string Win32_ScheduledJob = "Win32_ScheduledJob";
        public const string Win32_SCSIController = "Win32_SCSIController";
        public const string Win32_SCSIControllerDevice = "Win32_SCSIControllerDevice";
        public const string Win32_SecurityDescriptor = "Win32_SecurityDescriptor";
        public const string Win32_SecuritySetting = "Win32_SecuritySetting";
        public const string Win32_SecuritySettingAccess = "Win32_SecuritySettingAccess";
        public const string Win32_SecuritySettingAuditing = "Win32_SecuritySettingAuditing";
        public const string Win32_SecuritySettingGroup = "Win32_SecuritySettingGroup";
        public const string Win32_SecuritySettingOfLogicalFile = "Win32_SecuritySettingOfLogicalFile";
        public const string Win32_SecuritySettingOfLogicalShare = "Win32_SecuritySettingOfLogicalShare";
        public const string Win32_SecuritySettingOfObject = "Win32_SecuritySettingOfObject";
        public const string Win32_SecuritySettingOwner = "Win32_SecuritySettingOwner";
        public const string Win32_SelfRegModuleAction = "Win32_SelfRegModuleAction";
        public const string Win32_SerialPort = "Win32_SerialPort";
        public const string Win32_SerialPortConfiguration = "Win32_SerialPortConfiguration";
        public const string Win32_SerialPortSetting = "Win32_SerialPortSetting";
        public const string Win32_Service = "Win32_Service";
        public const string Win32_ServiceControl = "Win32_ServiceControl";
        public const string Win32_ServiceSpecification = "Win32_ServiceSpecification";
        public const string Win32_ServiceSpecificationService = "Win32_ServiceSpecificationService";
        public const string Win32_SettingCheck = "Win32_SettingCheck";
        public const string Win32_Share = "Win32_Share";
        public const string Win32_ShareToDirectory = "Win32_ShareToDirectory";
        public const string Win32_ShortcutAction = "Win32_ShortcutAction";
        public const string Win32_ShortcutFile = "Win32_ShortcutFile";
        public const string Win32_ShortcutSAP = "Win32_ShortcutSAP";
        public const string Win32_SID = "Win32_SID";
        public const string Win32_SMBIOSMemory = "Win32_SMBIOSMemory";
        public const string Win32_SoftwareElement = "Win32_SoftwareElement";
        public const string Win32_SoftwareElementAction = "Win32_SoftwareElementAction";
        public const string Win32_SoftwareElementCheck = "Win32_SoftwareElementCheck";
        public const string Win32_SoftwareElementCondition = "Win32_SoftwareElementCondition";
        public const string Win32_SoftwareElementResource = "Win32_SoftwareElementResource";
        public const string Win32_SoftwareFeature = "Win32_SoftwareFeature";
        public const string Win32_SoftwareFeatureAction = "Win32_SoftwareFeatureAction";
        public const string Win32_SoftwareFeatureCheck = "Win32_SoftwareFeatureCheck";
        public const string Win32_SoftwareFeatureParent = "Win32_SoftwareFeatureParent";
        public const string Win32_SoftwareFeatureSoftwareElements = "Win32_SoftwareFeatureSoftwareElements";
        public const string Win32_SoundDevice = "Win32_SoundDevice";
        public const string Win32_StartupCommand = "Win32_StartupCommand";
        public const string Win32_SubDirectory = "Win32_SubDirectory";
        public const string Win32_SystemAccount = "Win32_SystemAccount";
        public const string Win32_SystemBIOS = "Win32_SystemBIOS";
        public const string Win32_SystemBootConfiguration = "Win32_SystemBootConfiguration";
        public const string Win32_SystemDesktop = "Win32_SystemDesktop";
        public const string Win32_SystemDevices = "Win32_SystemDevices";
        public const string Win32_SystemDriver = "Win32_SystemDriver";
        public const string Win32_SystemDriverPNPEntity = "Win32_SystemDriverPNPEntity";
        public const string Win32_SystemEnclosure = "Win32_SystemEnclosure";
        public const string Win32_SystemLoadOrderGroups = "Win32_SystemLoadOrderGroups";
        public const string Win32_SystemLogicalMemoryConfiguration = "Win32_SystemLogicalMemoryConfiguration";
        public const string Win32_SystemMemoryResource = "Win32_SystemMemoryResource";
        public const string Win32_SystemNetworkConnections = "Win32_SystemNetworkConnections";
        public const string Win32_SystemOperatingSystem = "Win32_SystemOperatingSystem";
        public const string Win32_SystemPartitions = "Win32_SystemPartitions";
        public const string Win32_SystemProcesses = "Win32_SystemProcesses";
        public const string Win32_SystemProgramGroups = "Win32_SystemProgramGroups";
        public const string Win32_SystemResources = "Win32_SystemResources";
        public const string Win32_SystemServices = "Win32_SystemServices";
        public const string Win32_SystemSetting = "Win32_SystemSetting";
        public const string Win32_SystemSlot = "Win32_SystemSlot";
        public const string Win32_SystemSystemDriver = "Win32_SystemSystemDriver";
        public const string Win32_SystemTimeZone = "Win32_SystemTimeZone";
        public const string Win32_SystemUsers = "Win32_SystemUsers";
        public const string Win32_TapeDrive = "Win32_TapeDrive";
        public const string Win32_TemperatureProbe = "Win32_TemperatureProbe";
        public const string Win32_Thread = "Win32_Thread";
        public const string Win32_TimeZone = "Win32_TimeZone";
        public const string Win32_Trustee = "Win32_Trustee";
        public const string Win32_TypeLibraryAction = "Win32_TypeLibraryAction";
        public const string Win32_UninterruptiblePowerSupply = "Win32_UninterruptiblePowerSupply";
        public const string Win32_USBController = "Win32_USBController";
        public const string Win32_USBControllerDevice = "Win32_USBControllerDevice";
        public const string Win32_UserAccount = "Win32_UserAccount";
        public const string Win32_UserDesktop = "Win32_UserDesktop";
        public const string Win32_VideoConfiguration = "Win32_VideoConfiguration";
        public const string Win32_VideoController = "Win32_VideoController";
        public const string Win32_VideoSettings = "Win32_VideoSettings";
        public const string Win32_VoltageProbe = "Win32_VoltageProbe";
        public const string Win32_WMIElementSetting = "Win32_WMIElementSetting";
        public const string Win32_WMISetting = "Win32_WMISetting";

        private const string STR_SELECT = "Select * From ";
        private const string STR_SPACE = "---~~---~~~---~~~---~~~---~~~---~~---";
        #endregion

        #region Static method
        /// <summary>
        /// List information
        /// </summary>
        /// <param name="win32">Constant Win32</param>
        /// <returns></returns>
        public static List<PropertyData> ListInfo(string win32)
        {
            var lst = new List<PropertyData>();
            using (var mbs = new ManagementObjectSearcher(STR_SELECT + win32))
            {
                foreach (ManagementObject mo in mbs.Get())
                    foreach (var p in mo.Properties)
                        lst.Add(p);
            }
            return lst;
        }

        /// <summary>
        /// Get information
        /// </summary>
        /// <param name="win32">Constant Win32</param>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static string GetInfo(string win32, string key)
        {
            string s = "";
            using (var mbs = new ManagementObjectSearcher(STR_SELECT + win32))
            {
                foreach (ManagementObject mo in mbs.Get())
                    s = mo[key].ToString().Trim();
            }
            return s;
        }

        /// <summary>
        /// Get information
        /// </summary>
        /// <param name="win32">Constant Win32</param>
        /// <returns></returns>
        public static DataTable GetInfo(string win32)
        {
            const string STR_Name = "Name";
            const string STR_Value = "Value";

            var tb = new DataTable("Tmp");
            tb.Columns.Add(STR_Name);
            tb.Columns.Add(STR_Value);

            using (var mbs = new ManagementObjectSearcher(STR_SELECT + win32))
            {
                int s = mbs.Get().Count;
                int i = 1;

                foreach (ManagementObject mo in mbs.Get())
                {
                    foreach (var p in mo.Properties)
                    {
                        var dr = tb.Rows.Add();
                        dr[STR_Name] = p.Name;
                        dr[STR_Value] = p.Value;
                    }

                    if (i != s)
                    {
                        var drs = tb.Rows.Add();
                        drs[STR_Name] = STR_SPACE;
                        drs[STR_Value] = STR_SPACE;
                    }
                    i++;
                }
            }
            return tb;
        }

        /// <summary>
        /// Get serial number
        /// </summary>
        /// <returns></returns>
        public static string SerialNumber()
        {
            return GetInfo(Win32_BaseBoard, "SerialNumber");
        }

        /// <summary>
        /// Get processor ID
        /// </summary>
        /// <returns></returns>
        public static string ProcessorID()
        {
            return GetInfo(Win32_Processor, "ProcessorID");
        }

        /// <summary>
        /// Get MAC address
        /// </summary>
        /// <returns></returns>
        public static string MACAddress()
        {
            using (var mc = new ManagementClass(Win32_NetworkAdapterConfiguration))
            {
                using (var moc = mc.GetInstances())
                {
                    string s = String.Empty;
                    foreach (ManagementObject mo in moc)
                    {
                        if (String.Compare(s, String.Empty, false) == 0)
                            if ((bool)mo["IPEnabled"] == true) // only return MAC Address from first card
                                s = mo["MacAddress"].ToString().Trim();
                        mo.Dispose();
                    }
                    s = s.Replace(":", "");
                    return s;
                }
            }
        }
        #endregion
    }
}