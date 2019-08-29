#include "lcms2.h"
#pragma once

__declspec(dllexport) CMSAPI cmsHPROFILE      CMSEXPORT CmsOpenProfileFromFile(const char *ICCProfile, const char *sAccess);
__declspec(dllexport) CMSAPI cmsHTRANSFORM    CMSEXPORT CmsCreateTransform(cmsHPROFILE Input,
														cmsUInt32Number InputFormat,
														cmsHPROFILE Output,
														cmsUInt32Number OutputFormat,
														cmsUInt32Number Intent,
														cmsUInt32Number dwFlags);

 __declspec(dllexport) CMSAPI cmsBool          CMSEXPORT CmsCloseProfile(cmsHPROFILE hProfile);
 __declspec(dllexport) CMSAPI void             CMSEXPORT CmsDeleteTransform(cmsHTRANSFORM hTransform);

 __declspec(dllexport) CMSAPI void             CMSEXPORT CmsDoTransform(cmsHTRANSFORM Transform,
													void * InputBuffer,
													void * OutputBuffer,
													cmsUInt32Number Size);

