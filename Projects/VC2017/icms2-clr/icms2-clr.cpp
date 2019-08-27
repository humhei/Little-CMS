// icms2-clr.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "lcms2.h"

icms2ClrClass::icms2ClrClass(void)
{
}

icms2ClrClass::~icms2ClrClass(void)
{
}

CMSAPI cmsHPROFILE CMSEXPORT icms2ClrClass::CmsOpenProfileFromFile(const char * ICCProfile, const char * sAccess)
{
	return cmsOpenProfileFromFile(ICCProfile, sAccess);
}

CMSAPI cmsHTRANSFORM CMSEXPORT icms2ClrClass::CmsCreateTransform(cmsHPROFILE Input, cmsUInt32Number InputFormat, cmsHPROFILE Output, cmsUInt32Number OutputFormat, cmsUInt32Number Intent, cmsUInt32Number dwFlags)
{
	return cmsCreateTransform(Input, InputFormat, Output, OutputFormat, Intent, dwFlags);
}

CMSAPI cmsBool CMSEXPORT icms2ClrClass::CmsCloseProfile(cmsHPROFILE hProfile)
{
	return cmsCloseProfile(hProfile);
}

CMSAPI void CMSEXPORT icms2ClrClass::CmsDeleteTransform(cmsHTRANSFORM hTransform)
{
	return cmsDeleteTransform(hTransform);
}

CMSAPI void CMSEXPORT icms2ClrClass::CmsDoTransform(cmsHTRANSFORM Transform, void * InputBuffer, void * OutputBuffer, cmsUInt32Number Size)
{
	return cmsDoTransform(Transform, InputBuffer, OutputBuffer, Size);
}

