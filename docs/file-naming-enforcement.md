# File Naming Enforcement - Documentation & Configuration Files

**Date:** February 1, 2026
**Purpose:** Prevent naming violations in documentation and configuration files
**Status:** ✅ ENFORCEMENT ACTIVE

> **SCOPE:** This document applies to documentation and configuration files (.md, .txt, .json, .yml, .yaml, .sql).
> Source code files follow their language's official convention. See `.vscode/rules/rulebook.md` Section 3.1.

---

## 🎯 The Problem

On 2026-02-01, I (the AI) violated the cardinal rule by creating:
- ❌ `IMPLEMENTATION-COMPLETE.md` (should be `implementation-complete.md`)
- ❌ `QUICK-START.md` (should be `quick-start.md`)

This happened despite:
1. ✅ Creating the kebab-case rule
2. ✅ Documenting it in rulebook
3. ✅ Enforcing it in settings.json
4. ❌ **NOT validating my own output against the rules**

---

## ✅ Solutions Implemented

### 1. **Settings-Based Enforcement** (`.vscode/settings.json`)

Added explicit "BEFORE_FILE_CREATION" checklist:

```json
"BEFORE_FILE_CREATION": [
  "⚠️ MANDATORY FILE NAMING VALIDATION - DO NOT SKIP ⚠️",
  "1. FILENAME MUST BE: lowercase-with-hyphens.ext",
  "2. FILENAME MUST NOT BE: camelCase, PascalCase, UPPERCASE",
  "3. VERIFY: Use regex: ^[a-z0-9]+(-[a-z0-9]+)*\\.[a-z0-9]+$",
  "4. IF UNSURE: Does this filename have uppercase? If YES → FIX IT FIRST"
]
```

**AI now sees this every time it needs to create a file.**

---

### 2. **Branching Rules Documentation** (`.vscode/rules/branching-rule.md`)

Added section: **⚠️ MANDATORY FILE NAMING VALIDATION**

Key components:
- **Filename check:** Does it contain uppercase? → STOP
- **Validation pattern:** Regex for correct format
- **AI self-check:** Pseudo-code to validate before creation
- **Common mistakes:** Table of violations vs. correct format
- **Zero tolerance policy:** Not a suggestion, MANDATORY

**Example from documentation:**
```
PSEUDO-CODE FOR AI:

filename = "desired-filename.ext"

if filename.contains(uppercase):
    return ERROR("Filename contains uppercase - VIOLATES kebab-case rule")

if not matches_regex(filename, "^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$"):
    return ERROR("Filename format invalid - must be kebab-case")

create_file(filename)  # Only if both checks pass
```

---

### 3. **Rulebook Enforcement** (`.vscode/rules/rulebook.md`)

Added Section 3.1: **FILE NAMING - KEBAB-CASE (MANDATORY)**

Includes:
- ❌ What's prohibited (with examples from actual violation)
- ✅ Mandatory format (with regex pattern)
- Pre-commit/pre-push hook validation references
- Documentation of 2026-02-01 incident

---

### 4. **Multi-Layer Enforcement**

**Layer 1: Pre-Commit Hook**
```
Validates filenames per language convention (docs=kebab-case, C#=PascalCase, Dart/Py=snake_case)
```

**Layer 2: Pre-Push Hook**
```
Validates all staged filenames match their language's convention
```

**Layer 3: PR Checklist** (in `docs/pr-checklist.md`)
```
□ All filenames follow language-appropriate convention?
```

**Layer 4: AI Validation**
```
Before creating ANY file:
1. Identify file type (source code vs docs/config)
2. Apply correct convention for that type
3. Only create if naming check passes
```

---

## 📋 How AI (Copilot) Should Validate

### Step 1: Identify Filename
```
I need to create: IMPLEMENTATION-COMPLETE.md
```

### Step 2: Run Self-Check
```
Does filename contain uppercase?
  "IMPLEMENTATION-COMPLETE.md" → YES (I, M, P, L, C, D)
  
Result: ❌ VIOLATION
Action: STOP. Do not create this file.
```

### Step 3: Fix Filename
```
Corrected filename: implementation-complete.md

Does filename contain uppercase?
  "implementation-complete.md" → NO
  
Does it match regex ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$ ?
  "implementation-complete.md" → YES
  
Result: ✅ VALID
Action: Safe to create file now.
```

---

## 🔍 Validation Checklist (For Documentation & Config Files)

For documentation and configuration files (.md, .txt, .json, .yml, .yaml, .sql):

Before I create a file, I MUST complete:

```
□ Does filename contain ONLY lowercase letters, numbers, and hyphens?
□ Does filename match pattern: ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$ ?
□ Does filename have NO spaces?
□ Does filename extension match the file type?
□ Have I verified: NO PascalCase, camelCase, UPPERCASE, or underscore?

If ANY checkbox is unchecked → DO NOT CREATE FILE
Fix the filename first, THEN create the file.
```

---

## 📊 Common Violations & Corrections

| ❌ WRONG | ✅ CORRECT | Reason |
|----------|-----------|--------|
| `IMPLEMENTATION-COMPLETE.md` | `implementation-complete.md` | No UPPERCASE |
| `quickStart.md` | `quick-start.md` | No camelCase |
| `MyFile.TXT` | `my-file.txt` | Extension lowercase |
| `file name.md` | `file-name.md` | Use hyphens, not spaces |
| `Constants.json` | `constants.json` | Filename lowercase |

> **Note:** C# files (.cs) use PascalCase (e.g., `UserService.cs`), Dart files (.dart) use snake_case (e.g., `user_service.dart`),
> Python files (.py) use snake_case. These follow their language conventions and are NOT violations.

---

## 🛠️ Technical Implementation

### Regex Pattern for Validation
```regex
^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$
```

**Breakdown:**
- `^` — Start of string
- `[a-z0-9]+` — Start with lowercase letter or number
- `(-[a-z0-9]+)*` — Zero or more groups of (hyphen + lowercase/number)
- `\.` — Literal dot (file extension separator)
- `[a-z0-9]+` — Extension must be lowercase
- `$` — End of string

**Examples (for documentation/config files):**
- ✅ `setup-guide.md` — Matches kebab-case
- ✅ `implementation-complete.md` — Matches kebab-case
- ✅ `my-file-v2.txt` — Matches kebab-case
- ❌ `SetupGuide.md` — Uppercase (docs must be kebab-case)
- ❌ `my_file.txt` — Contains underscore (docs must use hyphens)
- ❌ `my file.txt` — Contains space

---

## 📞 When I Violate This Rule

If I ever create a file with uppercase/incorrect naming:

1. **User catches it** → Points out violation
2. **I acknowledge it** → Accept responsibility
3. **I fix it immediately** → Rename file to kebab-case
4. **I commit the fix** → With detailed explanation
5. **I review all files** → Ensure no other violations

---

## 🚀 Going Forward

### Every File I Create Will:

✅ Pass kebab-case validation  
✅ Match the regex pattern  
✅ Have no uppercase letters  
✅ Use hyphens (not underscores or spaces)  
✅ Be validated BEFORE creation (not after)  

### This Prevents:

❌ Another `IMPLEMENTATION-COMPLETE.md` incident  
❌ Any filename with uppercase letters  
❌ Any violation of the kebab-case cardinal rule  

---

## ✅ Enforcement Status

| Mechanism | Status | Location |
|-----------|--------|----------|
| **Settings Checklist** | ✅ ACTIVE | `.vscode/settings.json` |
| **Branching Rules** | ✅ ACTIVE | `.vscode/rules/branching-rule.md` |
| **Rulebook** | ✅ ACTIVE | `.vscode/rules/rulebook.md` |
| **Pre-Commit Hook** | ✅ ACTIVE | `.git/hooks/pre-commit` |
| **Pre-Push Hook** | ✅ ACTIVE | `.git/hooks/pre-push` |
| **AI Self-Check** | ✅ ACTIVE | This document (enforced manually) |

---

## 🎓 Key Takeaway

**Kebab-case is MANDATORY for documentation and configuration files.**
**Source code files follow their language's official naming convention** (C#=PascalCase, Dart/Python=snake_case).

I (the AI) will validate the file type and apply the correct convention before creation.
Every filename will be validated before creation.
No exceptions, no shortcuts, no violations.

---

**Status:** ✅ ENFORCEMENT COMPLETE  
**Last Updated:** 2026-02-01  
**Incident Documented:** 2026-02-01 (will not be repeated)
