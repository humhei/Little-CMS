// icms2-clr.cpp : Defines the exported functions for the DLL application.
//

#include "lcms2.h"
#include "icms2_clr.h"

CMSAPI cmsHPROFILE CMSEXPORT CmsOpenProfileFromFile(const char * ICCProfile, const char * sAccess)
{
	return cmsOpenProfileFromFile(ICCProfile, sAccess);
}

CMSAPI cmsHTRANSFORM CMSEXPORT CmsCreateTransform(cmsHPROFILE Input, cmsUInt32Number InputFormat, cmsHPROFILE Output, cmsUInt32Number OutputFormat, cmsUInt32Number Intent, cmsUInt32Number dwFlags)
{
	return cmsCreateTransform(Input, InputFormat, Output, OutputFormat, Intent, dwFlags);
}

CMSAPI cmsBool CMSEXPORT CmsCloseProfile(cmsHPROFILE hProfile)
{
	return cmsCloseProfile(hProfile);
}

CMSAPI void CMSEXPORT CmsDeleteTransform(cmsHTRANSFORM hTransform)
{
	return cmsDeleteTransform(hTransform);
}

CMSAPI void CMSEXPORT CmsDoTransform(cmsHTRANSFORM Transform, void * InputBuffer, void * OutputBuffer, cmsUInt32Number Size)
{
	return cmsDoTransform(Transform, InputBuffer, OutputBuffer, Size);
}
