# Task 922: File Upload Endpoint

## Status: TODO
## Sprint: 5
## Priority: HIGH
## Estimated Effort: MEDIUM

## Description
Implement an image upload endpoint for diagnostic purposes. This endpoint accepts multipart/form-data uploads, validates file size and type, stores the file to a configurable location, and returns the file path for use in AI image analysis workflows.

## Acceptance Criteria
- [ ] FileUploadController with POST endpoint accepting multipart/form-data
- [ ] File size validation with configurable maximum (e.g., 10MB default)
- [ ] File type validation restricting to allowed image formats (JPEG, PNG, WEBP, BMP)
- [ ] Files are stored in a configurable directory with unique generated filenames
- [ ] Original filename is preserved in metadata
- [ ] Endpoint returns the stored file path and metadata in the response
- [ ] Proper error responses for oversized files, invalid types, and upload failures
- [ ] Anti-virus/malware considerations documented (even if not implemented in stub)
- [ ] CORS configured for file upload if needed
- [ ] Upload directory is created automatically if it does not exist

## Files to Modify/Create
- `app/server/API/Controllers/FileUploadController.cs`
- `app/server/Application/Services/IFileStorageService.cs`
- `app/server/Infrastructure/Services/LocalFileStorageService.cs`
- `app/server/Application/DTOs/FileUpload/FileUploadResponseDto.cs`
- `app/server/API/appsettings.Development.json` (file storage configuration)

## Dependencies
- Base API project and controller patterns established
- Authentication middleware for user identification
- Static file serving configuration (if files need to be accessible via URL)

## Implementation Steps
1. Define IFileStorageService interface with upload, retrieve, and delete methods
2. Implement LocalFileStorageService for local disk storage
3. Create FileUploadResponseDto with file path, original name, size, and content type
4. Create FileUploadController with POST endpoint
5. Add file size validation middleware or attribute
6. Add file type validation (check both extension and content type/magic bytes)
7. Generate unique filenames to prevent collisions (GUID-based)
8. Configure upload directory in appsettings
9. Register file storage service in DI container
10. Test with various file sizes and types via Postman or Scalar

## Completion Checklist
- [ ] Code implemented
- [ ] Build passes
- [ ] Tested manually
- [ ] Task file updated to COMPLETED

## Progress Notes
_No progress yet_
