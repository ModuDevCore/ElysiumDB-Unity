# Changelog

All notable changes to this project will be documented in this file.

# Project History

### Before 1.1.0
ElysiumDB started as a lightweight SQLite wrapper for Unity. The project focused on simplifying database access while keeping the API small and easy to use.

### 1.1.0 — Extension System
This release transformed ElysiumDB into an extensible framework.

The project introduced a modular extension architecture, dependency management, execution ordering, runtime extension management, and a custom Unity Editor for configuring databases and extensions.

### 1.2.0 — Lifecycle & Processing
The extension pipeline was redesigned around lifecycle stages.

Database initialization became event-driven with processing stages, suspend/resume support, dependency-aware execution, categorized logging, and parameterized SQL queries. These changes established the foundation for more advanced extensions and asynchronous workflows.

## [1.2.0]

### Added
- Introduced extension execution dependencies via `AfterExtensionAttribute`.
- Added `ElysiumStage` to track the database initialization and disposal lifecycle.
- Added `OnStageChanged` event for monitoring database and extension processing stages.
- Added support for suspending and resuming extension processing.
- Added queued extension execution with dependency-aware scheduling.
- Added centralized `DBLogger` with categorized logging contexts.
- Added parameterized SQL queries for all database operations (`Query`, `Execute`, `Exists`, etc.) to improve security and flexibility.
- Added per-category log settings in the editor (SQL, Core, Extensions and Default logs).

### Changed
- Refactored the extension processing pipeline to support staged, resumable and dependency-aware execution.
- Improved extension initialization and disposal ordering.
- Reworked database logging to use the new `DBLogger` instead of direct `Debug.Log` calls.
- Database connection workflow now emits lifecycle events during connection and initialization.
- Runtime extension addition now initializes newly added extensions through the processing pipeline.

### Improved
- Improved SQL command API with support for named parameters.
- Improved extension execution reliability by introducing execution queues.
- Improved logging readability with colored and categorized output.
- Improved editor usability by grouping log configuration into dedicated settings.
- Improved initialization workflow visibility through stage notifications.

### Fixed
- Fixed execution order issues between dependent extensions.
- Fixed several extension initialization edge cases when adding extensions at runtime.
- Fixed inconsistent logging behavior across database operations.

## [1.1.0]

### Added
- Introduced the ElysiumDB extension system.
- Added support for extension dependencies using `RequireExtensionAttribute`.
- Added extension execution ordering with `ExtensionProcessOrderAttribute`.
- Added default extension grouping via `DefaultExtensionGroupAttribute`.
- Added runtime extension management API (`AddExtension`, `RemoveExtension`, `GetExtension`, `HasExtension`, etc.).
- Added automatic creation of required extensions.
- Added SQLite object mapping utilities (`QueryFirst`, `QueryList`, `QueryValue`, `QueryDictionary`, `QueryColumn`).
- Added configurable database settings asset for managing databases, extensions and logging.
- Added custom Unity Editor for managing database connections and installed extensions.
- Added built-in database connection management with support for multiple SQLite databases.
- Added database creation API with configurable SQLite connection settings.
- Added the first built-in authentication extension (`AuthExtension`).

### Changed
- Reorganized the project into a modular architecture with Core, Extensions, Editor and Attributes.
- Refactored database initialization and disposal into an extension-driven lifecycle.
- Improved database access through a centralized `ElysiumDatabase` instance.
- Simplified extension development by introducing `DBExtensionBase`.

### Improved
- Improved SQL logging with caller information and configurable log filtering.
- Improved editor workflow for inspecting database state and runtime connections.
- Improved extension reliability with dependency validation and automatic processing.

### Fixed
- Fixed extension initialization and disposal order consistency.
- Fixed various runtime edge cases when managing extensions dynamically.