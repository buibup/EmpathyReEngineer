namespace Empathy.Core.DataAccess
{
    public class DbQuery
    {
        public static string GetApptConsultByEpiNo()
        {
            const string cmdQuery = @"
                SELECT APPT_AS_ParRef->AS_Date
                ,APPT_AS_ParRef->AS_SessStartTime
                ,APPT_Status
                ,APPT_Adm_DR -> PAADM_VisitStatus
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Code
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Desc
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTPCP_DR->CTPCP_Desc 
                ,APPT_RBCServ_DR -> SER_Desc
                ,APPT_Remarks
                FROM RB_Appointment
                WHERE APPT_Adm_DR -> PAADM_ADMNO = ?
                AND APPT_Adm_DR -> PAADM_ADMNO IS NOT NULL
                AND APPT_Adm_DR -> PAADM_VisitStatus = 'A'
                AND APPT_Adm_DR -> PAADM_ADMDATE = CURRENT_DATE
            ";

            return cmdQuery;
        }

        public static string GetIcd9ByEpiNo()
        {
            const string cmdQuery = @"
                SELECT RBOP_PAADM_DR->OR_Anaesthesia->OR_Anaest_Operation->ANAOP_Type_DR->OPER_Code 
                ,RBOP_PAADM_DR->OR_Anaesthesia->OR_Anaest_Operation->ANAOP_Type_DR->OPER_Desc
                FROM RB_OperatingRoom
                WHERE RBOP_PAADM_DR->PAADM_ADMNo = ?
            ";

            return cmdQuery;
        }

        public static string GetIcd10ByEpiNo()
        {
            const string cmdQuery = @"
                SELECT PAADM_MainMRADM_DR->MR_Diagnos->MRDIA_ICDCode_DR->MRCID_Code 
                ,PAADM_MainMRADM_DR->MR_Diagnos->MRDIA_ICDCode_DR->MRCID_Desc 
                FROM PA_Adm
                WHERE PAADM_ADMNo = ?
            ";

            return cmdQuery;
        }

        public static string GetPatientAlertMsg()
        {
            const string cmdQuery = @"
                SELECT ALM_AlertCategory_DR->ALERTCAT_Code
                ,ALM_AlertCategory_DR->ALERTCAT_Desc
                ,ALM_Message,ALM_Status
                FROM PA_AlertMsg
                WHERE ALM_PAPMI_ParRef->PAPMI_No = ?
                AND ALM_Status = 'A'
            ";

            return cmdQuery;
        }

        public static string GetPatientAppointments()
        {
            const string cmdQuery = @"
                SELECT APPT_AS_ParRef->AS_Date 
                ,APPT_AS_ParRef->AS_SessStartTime
                ,APPT_Status
                ,APPT_Adm_DR->PAADM_VisitStatus
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Code
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Desc
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTPCP_DR->CTPCP_Desc 
                ,APPT_RBCServ_DR->SER_Desc
                FROM RB_Appointment
                WHERE APPT_Adm_DR->PAADM_PAPMI_DR->PAPMI_No = ?
                and APPT_AS_ParRef->AS_Date >= getdate() and APPT_Adm_DR->PAADM_VisitStatus = 'P'
                and APPT_AS_ParRef->AS_Date IN
                (
            	    SELECT DISTINCT TOP 2 APPT_AS_ParRef->AS_Date
	                FROM
	                RB_Appointment
	                WHERE
	                APPT_Adm_DR -> PAADM_PAPMI_DR -> PAPMI_No = ?
	                AND APPT_Adm_DR -> PAADM_ADMNO IS  NULL
	                AND APPT_Adm_DR -> PAADM_VisitStatus <> 'A'
	                and APPT_Adm_DR -> PAADM_ADMDATE >= GetDate()
	                Order by
	                APPT_Adm_DR -> PAADM_ADMDATE ,
	                APPT_Adm_DR -> PAADM_ADMTIME 
                )
                order by APPT_AS_ParRef->AS_Date,APPT_AS_ParRef->AS_SessStartTime
            ";

            return cmdQuery;
        }

        public static string GetPatientAppointmentsPast()
        {
            const string cmdQuery = @"
                SELECT CONVERT(VARCHAR(10),APPT_AS_ParRef->AS_Date,126) AS_Date,
                APPT_AS_ParRef -> AS_Date AS_Date1,
                APPT_AS_ParRef -> AS_SessStartTime,
                APPT_Status,
                APPT_Adm_DR -> PAADM_VisitStatus,
                APPT_AS_ParRef -> AS_RES_ParRef -> RES_CTLOC_DR -> CTLOC_Code,
                APPT_AS_ParRef -> AS_RES_ParRef -> RES_CTLOC_DR -> CTLOC_Desc,
                APPT_AS_ParRef -> AS_RES_ParRef -> RES_CTPCP_DR -> CTPCP_Desc,
                APPT_RBCServ_DR -> SER_Desc
                FROM
                RB_Appointment
                WHERE
                APPT_Adm_DR -> PAADM_PAPMI_DR -> PAPMI_No = ?
                and APPT_Adm_DR -> PAADM_ADMNO in(
                SELECT
                DISTINCT TOP 2 APPT_Adm_DR -> PAADM_ADMNO
                FROM
                RB_Appointment
                WHERE
                APPT_Adm_DR -> PAADM_PAPMI_DR -> PAPMI_No = ?
                AND APPT_Adm_DR -> PAADM_ADMNO IS NOT NULL
                AND APPT_Adm_DR -> PAADM_VisitStatus <> 'A'
                Order by
                APPT_Adm_DR -> PAADM_ADMDATE DESC,
                APPT_Adm_DR -> PAADM_ADMTIME DESC
                )
                Order by
                APPT_AS_ParRef -> AS_Date DESC,
                APPT_AS_ParRef -> AS_SessStartTime DESC    
            ";

            return cmdQuery;
        }

        public static string GetPatientAppointmentsCurrent()
        {
            const string cmdQuery = @"
                SELECT CONVERT(VARCHAR(10),APPT_AS_ParRef->AS_Date,126) AS_Date
                ,APPT_AS_ParRef->AS_Date AS_Date1
                ,APPT_AS_ParRef->AS_SessStartTime
                ,APPT_Status
                ,APPT_Adm_DR->PAADM_VisitStatus
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Code
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTLOC_DR->CTLOC_Desc
                ,APPT_AS_ParRef->AS_RES_ParRef->RES_CTPCP_DR->CTPCP_Desc 
                ,APPT_RBCServ_DR->SER_Desc
                FROM RB_Appointment
                WHERE APPT_Adm_DR->PAADM_PAPMI_DR->PAPMI_No = ?
                and APPT_Adm_DR->PAADM_VisitStatus = 'A'
                and APPT_AS_ParRef->AS_Date = CURRENT_DATE
                order by APPT_AS_ParRef->AS_Date , APPT_AS_ParRef->AS_SessStartTime 
            ";

            return cmdQuery;
        }

        public static string GetPatientEpisodeInquiry()
        {
            const string cmdQuery = @"
                SELECT PAADM_ADMNo
                ,PAADM_AdmDate
                ,PAADM_AdmTime
                ,PAADM_DepCode_DR->CTLOC_Code
                ,PAADM_DepCode_DR->CTLOC_Desc
                ,PAADM_AdmDocCodeDR->CTPCP_Code
                ,PAADM_AdmDocCodeDR->CTPCP_Desc
                ,PAADM_Type
                ,PAADM_VisitStatus
                ,PAADM_CurrentWard_DR->WARD_Code
                ,PAADM_CurrentWard_DR->WARD_Desc
                ,PAADM_CurrentRoom_DR->ROOM_Code
                FROM pa_adm
                WHERE PAADM_PAPMI_DR->PAPMI_No = ?
                AND PAADM_AdmDate = CURRENT_DATE
            ";

            return cmdQuery;
        }

        public static string GetPatientImage()
        {
            const string cmdQuery = @"
                select PAPMI_RowId->PAPER_PHOTODocument->docData As ImageHN
                from PA_Patmas where PAPMI_NO = ?
            ";

            return cmdQuery;
        }

        public static string GetPatientInfo()
        {
            const string cmdQuery = @"
                SELECT PAPMI_No
                ,PAPMI_Title_DR->TTL_Desc
                ,PAPMI_Name,PAPMI_Name2
                ,PAPMI_DOB
                ,PAPMI_PAPER_DR->PAPER_AgeYr
                ,PAPMI_PAPER_DR->PAPER_AgeMth	
                ,PAPMI_PAPER_DR->PAPER_AgeDay
                ,PAPMI_Sex_DR->CTSEX_Desc
                ,PAPMI_PAPER_DR->PAPER_StName
                ,PAPMI_PAPER_DR->PAPER_CityArea_DR->CITAREA_Desc
                ,PAPMI_PAPER_DR->PAPER_CityCode_DR->CTCIT_Desc
                ,PAPMI_PAPER_DR->PAPER_CT_Province_DR->PROV_Desc
                ,PAPMI_PAPER_DR->PAPER_Zip_DR->CTZIP_Code
                ,PAPMI_PAPER_DR->PAPER_TelH 
                ,PAPMI_PatCategory_DR->PCAT_Code, PAPMI_PatCategory_DR->PCAT_Desc
                FROM pa_patmas
                WHERE PAPMI_No = ?
            ";

            return cmdQuery;
        }
    }
}
