#include "lcms2.h"
#pragma once
public ref class icms2ClrClass
{
public:
	icms2ClrClass(void);
	~icms2ClrClass(void);
	//cmsUInt32Number Const_TYPE_RGB_8 = TYPE_RGB_8;
	cmsUInt32Number Const_TYPE_RGB_FLT = TYPE_RGB_FLT;
	cmsUInt32Number Const_TYPE_CMYK_FLT = TYPE_CMYK_FLT;
	//cmsUInt32Number Const_TYPE_CMYK_8 = TYPE_CMYK_8;
	//cmsUInt32Number Const_TYPE_LAB_8 = TYPE_Lab_8;
	cmsUInt32Number Const_TYPE_LAB_FLT = TYPE_Lab_FLT;
	cmsUInt32Number Const_INTNET_PERCEPTUAL = INTENT_PERCEPTUAL;
	cmsUInt32Number Const_INTNET_RELATIVE_COLORIMETRIC = INTENT_RELATIVE_COLORIMETRIC;



	CMSAPI cmsHPROFILE      CMSEXPORT CmsOpenProfileFromFile(const char *ICCProfile, const char *sAccess);
	CMSAPI cmsHTRANSFORM    CMSEXPORT CmsCreateTransform(cmsHPROFILE Input,
															cmsUInt32Number InputFormat,
															cmsHPROFILE Output,
															cmsUInt32Number OutputFormat,
															cmsUInt32Number Intent,
															cmsUInt32Number dwFlags);
	CMSAPI cmsBool          CMSEXPORT CmsCloseProfile(cmsHPROFILE hProfile);
	CMSAPI void             CMSEXPORT CmsDeleteTransform(cmsHTRANSFORM hTransform);

	CMSAPI void             CMSEXPORT CmsDoTransform(cmsHTRANSFORM Transform,
														void * InputBuffer,
														void * OutputBuffer,
														cmsUInt32Number Size);

};