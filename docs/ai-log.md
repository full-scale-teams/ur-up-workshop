# AI Log

This file documents all uses of AI tools (e.g., ChatGPT, Copilot, etc.) during the project.  
Be clear about **what was asked**, **what was used**, and **what was changed**.  
This helps judges understand your workflow and reasoning.

---

## Entry Format

### 🕒 Timestamp
Record when the prompt was made (e.g., `00:45`, `13:20`).

### 💬 Prompt
Paste the **exact prompt** you gave the AI.

### ✅ Output Adopted
Summarize or copy what you kept directly from the AI’s response.

### ✏️ Edits & Rationale
- Note **what you changed** (code tweaks, wording edits, formatting, etc.).
- Explain **why you made the change** (bug fix, clarity, coding standards, project fit).

### 🤔 Reflection (optional, but encouraged)
Briefly note how helpful the AI was:
- Did it save time?
- Did it give a wrong path you had to debug?
- Did it inspire a new approach?

---

## Example Entries

### 00:45 — First Use
**💬 Prompt**
> Generate a C# validation snippet for checking email format.

**✅ Output Adopted**
- Used the `Regex` pattern provided by the AI.

**✏️ Edits & Rationale**
- Changed the regex to accept “.ph” domain.
- Wrapped in a helper method for reuse.

**🤔 Reflection**  
AI gave a starting point but regex needed customization. Still saved ~10 minutes.

---

### 01:20 — Second Use
**💬 Prompt**
> Write a sample `appsettings.Development.json` for EF Core with SQLite.

**✅ Output Adopted**
- Copied the connection string structure.

**✏️ Edits & Rationale**
- Changed database file path to `./Data/dev.db`.
- Removed logging settings (not needed for MVP).

**🤔 Reflection**  
Prompt worked well. Minor edits only. Very helpful.

---

## Tips
- Keep entries **short and clear**.
- Don’t skip documenting “failed” AI outputs — they still show your thought process.
- Use the **Reflection** section to give context (helps judges see critical thinking, not blind copy-paste).
