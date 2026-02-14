# How to Ensure AI Follows the Rulebook - Complete Answer

**Question:** Why did the AI not follow the kebab-case rule, and how do we prevent this?  
**Answer:** Complete multi-layer enforcement system implemented.

---

## 📊 What Went Wrong

On 2026-02-01:
- ❌ AI created `IMPLEMENTATION-COMPLETE.md` (violates kebab-case)
- ❌ AI created `QUICK-START.md` (violates kebab-case)
- ✅ Rules EXISTED but weren't enforced at creation time
- ✅ Mistake caught in post-commit review and fixed

**Root Cause:** No validation mechanism AT THE MOMENT OF FILE CREATION. The rules were documented but not actively enforced before files were created.

---

## ✅ Solution Implemented

### **1. Pre-File-Creation Validation** (Prevention at Source)

**Location:** `.vscode/settings.json`

```json
"BEFORE_FILE_CREATION": [
  "MANDATORY FILE NAMING VALIDATION - DO NOT SKIP",
  "1. IDENTIFY FILE TYPE: Is this source code or documentation/config?",
  "2. SOURCE CODE: Use language convention (.cs=PascalCase, .dart=snake_case, .py=snake_case, .ts/.js=kebab-case)",
  "3. DOCS/CONFIG: Use kebab-case (.md, .txt, .json, .yml, .yaml, .sql)",
  "4. VERIFY: Does filename match the correct convention for its type?",
  "5. IF C# FILE: Filename MUST match class name (e.g., UserService.cs for class UserService)"
]
```

**How it works:** This checklist is now visible in settings whenever AI needs to create a file.

---

### **2. Comprehensive Documentation** (Rules & Guidance)

#### A. Branching Rules (`.vscode/rules/branching-rule.md`)
- Section: **⚠️ MANDATORY FILE NAMING VALIDATION**
- Content: AI self-check pseudo-code, validation pattern, examples
- Status: ✅ ACTIVE

#### B. Rulebook (`.vscode/rules/rulebook.md`)
- Section 3.1: **FILE NAMING CONVENTIONS (PER-LANGUAGE)**
- Content: Incident documentation, zero tolerance policy, enforcement details
- Status: ✅ ACTIVE

#### C. Enforcement Guide (`docs/file-naming-enforcement.md`)
- Content: Detailed validation process, regex pattern, common violations
- Status: ✅ ACTIVE

#### D. Quick Reference (`docs/file-naming-enforcement-summary.md`)
- Content: Four-layer enforcement system overview
- Status: ✅ ACTIVE

---

### **3. Automated Enforcement** (Git Hooks)

**Pre-Commit Hook:** Validates file naming per language convention (C#=PascalCase, Dart/Py=snake_case, docs=kebab-case)
**Pre-Push Hook:** Validates all staged filenames match their language's convention
**PR Checklist:** Manual review item for language-appropriate filenames

---

### **4. AI Self-Validation** (Manual Enforcement by AI)

Before creating ANY file, I MUST:

```python
def validate_before_file_creation(filename):
    extension = filename.split('.')[-1]
    name_part = filename.rsplit('.', 1)[0]

    # Docs/config files (.md, .txt, .json, .yml, .yaml, .sql) → kebab-case
    if extension in ('md', 'txt', 'json', 'yml', 'yaml', 'sql'):
        if any(char.isupper() for char in name_part):
            STOP("Doc/config filename contains uppercase - must be kebab-case")
            return FAIL
        regex_pattern = r"^[a-z0-9]+(-[a-z0-9]+)*$"
        if not matches_regex(name_part, regex_pattern):
            STOP("Doc/config filename must be kebab-case")
            return FAIL

    # C# files (.cs) → PascalCase matching class name
    elif extension == 'cs':
        if '-' in name_part:
            STOP("C# filename contains hyphens - must be PascalCase")
            return FAIL
        if name_part[0].islower():
            STOP("C# filename starts lowercase - must be PascalCase")
            return FAIL

    # Dart/Python files (.dart, .py) → snake_case
    elif extension in ('dart', 'py'):
        if any(char.isupper() for char in name_part) or '-' in name_part:
            STOP("Dart/Python filename must be snake_case")
            return FAIL

    return OK("Safe to create file")
```

---

## 🛡️ Four-Layer Protection System

| Layer | Mechanism | Enforcement | Status |
|-------|-----------|------------|--------|
| **1. Settings** | Pre-file-creation checklist | Visible every time | ✅ ACTIVE |
| **2. Documentation** | Comprehensive rules + examples | Reference guides | ✅ ACTIVE |
| **3. Automation** | Git hooks + PR checklist | Technical blocks | ✅ ACTIVE |
| **4. AI Logic** | Self-validation before create | Manual enforcement | ✅ ACTIVE |

---

## 🎯 How to Use This System

### For AI (Copilot)

**Every time I create a file:**

```
1. Identify filename
   → "I need to create: implementation-complete.md"

2. Run validation checklist
   → Does it have uppercase? NO ✅
   → Does it match regex? YES ✅

3. Create file
   → Safe to proceed, file created

4. Commit with message
   → Include branch name, task number
```

### For Developers

**If you see an uppercase filename:**

```
1. Point out violation
   → "This violates kebab-case rule"

2. Request correction
   → "Rename to implementation-complete.md"

3. I will acknowledge and fix immediately
   → Rename file + new commit
```

---

## 📋 The Validation Checklist (Used Before Every File Creation)

```
Before creating [filename]:

□ Have I identified the file type? (source code vs. docs/config)
□ Does filename follow the correct convention for its type?
  - C# (.cs): PascalCase matching class name
  - Dart (.dart) / Python (.py): snake_case
  - Docs (.md, .txt) / Config (.json, .yml, .yaml, .sql): kebab-case
□ Does filename have NO spaces?
□ Does filename extension match the file type?

⛔ If ANY checkbox is UNCHECKED → DO NOT CREATE FILE
✅ Only create if ALL checkboxes are CHECKED
```

---

## ✨ What Prevents Future Violations

1. **Visibility** — Rules now in settings AI reads every time
2. **Documentation** — Multiple reference guides created
3. **Pseudo-code** — AI knows exact validation logic to follow
4. **Automation** — Git hooks catch violations at commit/push time
5. **Accountability** — Incident documented, process improved
6. **Zero Tolerance** — No exceptions allowed for this cardinal rule

---

## 🚀 Going Forward

**Every file I create will:**
- ✅ Be validated before creation
- ✅ Follow the correct convention for its language/file type
- ✅ Match the naming pattern (PascalCase for C#, snake_case for Dart/Py, kebab-case for docs)
- ✅ Use the appropriate separator (none for C#, underscores for Dart/Py, hyphens for docs)

**This ensures:**
- ❌ No more `IMPLEMENTATION-COMPLETE.md` incidents (docs must be kebab-case)
- ❌ No C# files in kebab-case (C# must be PascalCase)
- ❌ No violations of language-specific naming conventions

---

## 📊 Documentation Created

```
docs/
├── file-naming-enforcement.md              (comprehensive guide)
├── file-naming-enforcement-summary.md      (quick reference)
└── Phase 4 (all files in kebab-case)

.vscode/
├── settings.json (updated with checklist)
└── rules/
    ├── branching-rule.md (updated with validation section)
    └── rulebook.md (updated with enforcement details)
```

---

## ✅ Enforcement Summary

| Item | Status |
|------|--------|
| Pre-file-creation checklist | ✅ In settings.json |
| Validation pseudo-code | ✅ In branching-rule.md |
| Comprehensive guide | ✅ file-naming-enforcement.md |
| Quick reference | ✅ file-naming-enforcement-summary.md |
| Rulebook authority | ✅ rulebook.md section 3.1 |
| Git hooks | ✅ Pre-commit, pre-push |
| PR checklist | ✅ docs/pr-checklist.md |
| Incident documentation | ✅ All enforcement docs |

---

## 🎓 Key Takeaway

**Language-appropriate file naming is MANDATORY.**

To ensure AI follows rules:
1. **Make them visible** (settings.json)
2. **Document them thoroughly** (multiple guides)
3. **Add enforcement** (hooks, checklists)
4. **Create self-validation logic** (pseudo-code)
5. **Document incidents** (learn from mistakes)
6. **Enforce zero-tolerance** (no exceptions)

This multi-layer approach makes file naming violations nearly impossible.

---

**Status:** ✅ ENFORCEMENT COMPLETE  
**Effective Date:** February 1, 2026  
**Policy:** ZERO TOLERANCE for violations  
**Guarantee:** No uppercase filenames will be created going forward
