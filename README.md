
# FullScale × University — Onsite C#/.NET Workshop (Base Repo)

Welcome to the official base repository for the onsite .NET 8 workshop.  
Every team will clone this repo, build their MVP, and submit via **team branch**.

## 🚀 Quick Start

1. **Clone this repo** (DO NOT FORK ⚠️):
   ```bash
   git clone https://github.com/your-org/dotnet-workshop-base.git
   cd dotnet-workshop-base/src/DotnetWorkshop
    ```

## 📦 Submission Rules

Each team branch must include:

- **Updated `README.md`** [View Readme template](docs/README_TEMPLATE.md)
  - Branch name: team - (e.g., team-a)
  - MVP description (problem → solution)
  - Data model sketch
  - What works (flow summary)
  - Screenshots (`/screenshots` folder)
  - Demo script (2 minutes)
  - AI usage note (which parts were assisted)
  - No pull requests during the event. Judges review branches directly

- **`docs/ai-log.md`** with prompts and edits [View template here](docs/ai-log.md)

- **Commit history** every ~20–30 minutes with meaningful messages

> For detailed instructions on branch submission, see [CONTRIBUTING.md](CONTRIBUTING.md).
---

## 🏗️ MVP Selection Guide

Each team must choose **one** MVP idea below and implement a **Create → List** flow.  
Stretch goals are optional if time allows.

### 📄 Resume Submission Board
- **Value:** A lightweight portal where students can submit their resume details and showcase their skills. Faculty and FullScale recruiters can easily browse, filter, and identify candidates per school or course.
- **MVP:** minimal Razor Pages; EF Core + SQLite  
  **Entities:**
    - Resume(Id, StudentName, Email, ResumeUrl, PortfolioUrl, SkillsCsv, SubmittedAt, SchoolId)
    - School(Id, Name)
  
  **Views:**
  - Add Resume (Name, Email, Resume URL, optional Portfolio, Skills, select School)
  - List Resumes (with School name, clickable links, ordered by latest submission)
- **Stretch:**
    - Search or filter by Name/Skill/School
    - Sort by date submitted
    - CSV export for recruiters

---

### 🚀 Capstone Project Showcase
- **Value**: Acts as a portfolio hub for students and a scouting hub for FullScale; highlights each student’s technical work and stack.
- **MVP**:
  **Entities:**
    - Project(Id, Title, Summary, RepoUrl, TechCsv, StudentContact)  
      
- **Views:**
    - Submit Project (Title, Summary, Repo URL, Tech Stack, Contact Info)
    - Browse Projects (list with tech tags and contact)
    - Filter by Technology (via TechCsv)
    - Featured Carousel (highlighted or randomly featured projects)
- **Stretch:**
    - “Invite to Interview” button (sends email to StudentContact)
    - Project Badges (e.g., “Top Design”, “Most Stars”, “Team Favorite”)
    - Search by title or student name
    - CSV export for scouting list

---

### 🏆 Peer Recognition Wall
- **Value**: Builds positivity and recognition among students while giving FullScale insight into collaboration, teamwork, and cultural fit.
- **MVP**: minimal Razor Pages; EF Core + SQLite  
  **Entities:**
  - Kudos(Id, FromStudent, ToStudent, Message, CreatedAt)  
    
  **Views**:
    - Submit Kudos
    - Wall of Kudos Messages
  
- **Stretch**:
    - Filter by recipient name
    - Leaderboard (most kudos received)
    - Export kudos messages (CSV) for simple reporting
    - *(Optional)* Sentiment analysis of messages (basic positive/neutral/negative breakdown for engagement insights)

---

### 🧩 Issue Triage Board (Internal)
- **Value:** Teaches students how to manage and prioritize issues — a crucial real-world skill in software teams. Can also be repurposed internally by FullScale for tracking small tool requests or quick-fix tasks.
- **MVP:** Minimal Razor Pages; EF Core + SQLite  
  **Entities:**
    - Issue(Id, Title, Severity, Area, Status, CreatedAt)  
      
  **Views:**
    - Add Issue (Title, Severity, Area, default Status = To Do)
    - Kanban Board (columns: To Do / Doing / Done)
    - Drag and drop to update status (using htmx or minimal JS)
- **Stretch:**
    - CSV import/export of issues
    - SLA timers (track duration since creation)
    - Assign issues to team members or roles
    - Filter by Severity or Area
    - Simple dashboard: issue counts by status or severity  

---

### 🖨️ Resource/Equipment Reservation
- **Value**: Lab gear checkout for schools; device lab booking for FullScale.
- **MVP**: minimal Razor Pages; EF Core + SQLite
    - Resource(Name, Category)
    - Reservation(ResourceId, Start, End, ReservedBy)  
      
- **Views**: 
  - Calendar grid
  - create/cancel reservation
  - conflict prevention
  
- **Stretch**: 
  - Check-in/out with late return flags; 
  - basic availability analytics

---

## 📊 Evaluation Criteria

Teams will be judged using the following rubric. The focus is on having a **working MVP flow**; other points support clarity and completeness. Each category is scored 1–5 (NI → Not bad → Okay → Good → Very good), except the MVP flow which is scored out of 10.

| Criteria | Points |
|----------|-------|
| **Working MVP flow** (Create + List) | 10 |
| **Code clarity & validation** | 5 |
| **Understanding of the system** (explain data model & handlers) | 5 |
| **README + AI log completeness** | 5 |
| **Tiebreaker**: A small, stable stretch feature (CSV, QR, iCal) | — |

> **Note:** If a team fails to deliver a working MVP flow, their score will rely more heavily on understanding and documentation. Stretch goals are only considered for breaking ties.

---

## 📚 Additional Docs

- [README Template](docs/README_TEMPLATE.md)
- [AI Log](docs/ai-log.md)
- [Configuration Guide](docs/samples/CONFIGURATION.md)
- [Validation Guide](docs/samples/VALIDATION.md)
- [Bugs and Fixes](docs/BUGS_AND_FIXES.md)
- [Common Pitfalls](docs/COMMON_PITFALLS.md)