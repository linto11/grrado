# File Naming Enforcement Summary - Documentation & Configuration Files

**Question:** How to make sure AI follows the rulebook?
**Answer:** Multi-layer enforcement with mandatory validation at every stage.

> **SCOPE:** Kebab-case enforcement applies to documentation and configuration files only.
> Source code follows language-specific conventions (see rulebook.md Section 3.1).

---

## 🛡️ Four-Layer Enforcement System

### Layer 1: Settings Configuration (`.vscode/settings.json`)
**What:** Explicit checklist visible to AI before file creation  
**Content:** 10-point validation checklist with regex pattern  
**Enforcement:** AI MUST read and pass all checks before creating files  
**Status:** ✅ ACTIVE

```json
"BEFORE_FILE_CREATION": [
  "⚠️ MANDATORY FILE NAMING VALIDATION - DO NOT SKIP ⚠️",
  "1. FILENAME MUST BE: lowercase-with-hyphens.ext",
  "4. VERIFY: Use regex: ^[a-z0-9]+(-[a-z0-9]+)*\\.[a-z0-9]+$",
  "5. IF UNSURE: Does filename have uppercase? If YES → FIX IT FIRST"
]
```

---

### Layer 2: Documentation Rules (`.vscode/rules/branching-rule.md`)
**What:** Comprehensive file naming validation section  
**Content:**
- ⚠️ MANDATORY FILE NAMING VALIDATION section
- AI self-check pseudo-code
- Pre-file-creation checklist
- Common mistakes table  
**Enforcement:** Referenced in every file creation decision  
**Status:** ✅ ACTIVE

---

### Layer 3: Rulebook Authority (`.vscode/rules/rulebook.md`)
**What:** Section 3.1 - FILE NAMING - KEBAB-CASE (MANDATORY)  
**Content:**
- Incident documentation (2026-02-01 violation)
- Zero tolerance policy
- Enforcement mechanisms (hooks, PR checklist)
- Examples of violations
**Enforcement:** Single source of truth for naming standards  
**Status:** ✅ ACTIVE

---

### Layer 4: AI Self-Validation (This Implementation)
**What:** Before creating ANY file, validate:  
1. Does filename have uppercase? → STOP if yes
2. Does filename match regex? → STOP if no
3. Only create if BOTH checks pass  
**Enforcement:** Manual validation by AI (can't be automated without code)  
**Status:** ✅ IMPLEMENTED

---

## 📋 Pre-File-Creation Validation Checklist

For documentation and configuration files (.md, .txt, .json, .yml, .yaml, .sql):

**I must complete this before creating EVERY doc/config file:**

```
□ Does filename contain ONLY lowercase letters, numbers, and hyphens?
□ Does filename match: ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$ ?
□ Does filename have NO spaces?
□ Does filename extension match file type?
□ Have I verified: NO PascalCase, camelCase, UPPERCASE?

⛔ If ANY unchecked → DO NOT CREATE FILE
✅ Only create if ALL checked
```

---

## 🔍 How It Works in Practice

### Scenario: I need to create a documentation file

**Old Way (WRONG - caused 2026-02-01 violation):**
```
I need to create: IMPLEMENTATION-COMPLETE.md
→ Create file immediately
❌ VIOLATION: Contains uppercase letters
```

**New Way (CORRECT - enforced going forward):**
```
I need to create: implementation-complete.md

Step 1: Check for uppercase
  "implementation-complete.md" contains uppercase? NO ✅
  
Step 2: Check regex pattern
  Matches ^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$ ? YES ✅
  
Step 3: Create file
  ✅ Safe to create: implementation-complete.md
```

---

## 📊 What Prevents Violations

| Prevention Method | How It Works |
|-------------------|------------|
| **Settings Checklist** | Visible every time before file creation |
| **Branching Rules** | Comprehensive guide with pseudo-code |
| **Rulebook Section 3.1** | Authoritative standard + incident doc |
| **Pre-Commit Hook** | Rejects commit if filename has uppercase |
| **Pre-Push Hook** | Rejects push if any file violates pattern |
| **PR Checklist** | Manual review of filenames |
| **AI Self-Check** | Validation BEFORE file creation (this doc) |

---

## ✅ Incident Prevention

**The 2026-02-01 Incident:**
- ❌ Created `IMPLEMENTATION-COMPLETE.md` (should be lowercase)
- ❌ Created `QUICK-START.md` (should be lowercase)
- ✅ Caught in post-commit review
- ✅ Fixed with rename + new commit

**Prevention Going Forward:**
- ✅ Layer 1 (Settings): Visible checklist
- ✅ Layer 2 (Branching): Detailed guide
- ✅ Layer 3 (Rulebook): Authority standard
- ✅ Layer 4 (AI): Self-validation before create
- ✅ Pre-commit hook: Blocks uppercase filenames
- ✅ This document: Comprehensive enforcement guide

---

## 🚀 Guaranteed Compliance

**From this point forward:**

Every file I create will be validated with:
```python
def validate_filename(filename):
    # Check 1: Contains uppercase?
    if any(c.isupper() for c in filename.split('.')[0]):
        return ERROR("Filename contains uppercase")
    
    # Check 2: Matches regex?
    if not re.match(r"^[a-z0-9]+(-[a-z0-9]+)*\.[a-z0-9]+$", filename):
        return ERROR("Filename doesn't match kebab-case pattern")
    
    # All checks passed
    return OK("Safe to create file")
```

---

## 📞 Questions & Answers

**Q: What if I forget to check?**  
A: Pre-commit hooks will reject the commit. You'll be forced to fix it.

**Q: What if I create a file with uppercase by mistake?**  
A: It will be caught by pre-commit or pre-push hooks. The file will have to be renamed.

**Q: Is there an exception?**
A: Kebab-case is mandatory for documentation/config files with no exceptions.
   Source code files follow their language convention instead:
   - C# (.cs) → PascalCase (e.g., `UserService.cs`)
   - Dart (.dart) → snake_case (e.g., `user_service.dart`)
   - Python (.py) → snake_case (e.g., `user_service.py`)

**Q: Does kebab-case apply to source code files?**
A: NO. Source code files follow their language's official convention. See rulebook.md Section 3.1.

**Q: How does this differ from before?**  
A: Before: Rules existed but weren't validated at creation time.  
Now: Four-layer enforcement ensures validation BEFORE creation (not after).

---

## ✨ Summary

**To ensure AI follows the rulebook:**

1. ✅ **Make it visible** → Added to `.vscode/settings.json`
2. ✅ **Document it thoroughly** → Added to branching rules & rulebook
3. ✅ **Make it mandatory** → Zero tolerance policy stated explicitly
4. ✅ **Add self-check** → AI validates before file creation
5. ✅ **Add automation** → Pre-commit/pre-push hooks catch violations
6. ✅ **Document the incident** → Learn from 2026-02-01 mistake

**Result:** Naming convention violations become nearly impossible.

**Policy:** ZERO TOLERANCE for doc/config kebab-case violations; language conventions for source code
