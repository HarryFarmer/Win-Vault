# WinVault

**A personal work-capture system built on the Microsoft Power Platform — an "evidence engine" that turns everyday delivery into structured, reusable proof of skills and impact.**

WinVault solves a real problem: good work fades from memory, and we undersell ourselves when we can't recall the specifics. It captures each win as a structured **Problem → Approach → Outcome** record, classified by skill, impact and engagement — turning vague recollection into tangible, searchable evidence for CVs, interviews and progression conversations.

It is also a deliberately full-stack Power Platform solution, built to demonstrate end-to-end platform architecture: a relational Dataverse data model, C# plug-ins, a PCF control, Power Automate flows, a Power BI report, and a clean Dev → Test → Prod ALM pipeline with source control.

---

## What this project demonstrates

- **Relational data modelling in Dataverse** — a multi-table model with 1:N and N:N relationships, choice columns and global option sets, designed to scale without rework.
- **Model-driven app configuration** — forms (including quick-create for fast capture), views for different retrieval purposes, and an app tying it together.
- **Pro-code extensibility (C#)** — plug-ins enforcing business logic server-side, at the correct pipeline stages.
- **PCF (Power Apps Component Framework)** — a custom TypeScript control for data visualisation.
- **Automation** — Power Automate flows for scheduled digests and reminders.
- **Analytics** — a Power BI report with DAX measures over the captured data.
- **ALM & source control** — the solution is exported, unpacked and version-controlled here; managed builds are promoted Dev → Test → Prod.

---

## Architecture overview

WinVault is built across six layers, each mapping to a core Power Platform skill:

| Layer | Component |
|-------|-----------|
| **Data** | Dataverse: Win, Engagement, Skill Area, Weekly Snapshot tables with relationships |
| **App** | Model-driven app: forms, quick-create, views, dashboard |
| **Server logic** | C# plug-ins: integrity validation, data-shaping at the right pipeline stages |
| **UI extension** | PCF dataset control: a skill-strength visualiser over the wins |
| **Automation** | Power Automate: weekly digest, capture reminders, stale-win nudges |
| **Analytics** | Power BI: wins over time, skill coverage, impact distribution |

### The data model

```
Engagement (1) ----< (N) Win (N) >---- (N) Skill Area
                          |
                          v
                   Weekly Snapshot  (aggregate, flow-fed)
```

- **Win** — the core record: Problem, Approach, Outcome, plus impact, CV-ready flag and classification.
- **Engagement** — a curated record of client engagements and projects (1:N to Win); also a standalone history of professional experience.
- **Skill Area** — capabilities a win can demonstrate (N:N with Win), each tracking current level, target level and priority — turning the model into a growth tracker.
- **Weekly Snapshot** — an automatically-generated weekly summary for fast trend reporting.

---

## Repository structure

```
/src/WinVault     The unpacked Dataverse solution (tables, app, forms, views)
/plugins          C# plug-in source (server-side business logic)
/pcf              PCF control source (TypeScript UI component)
README.md         This file
```

The solution is source-controlled by exporting the **unmanaged** solution from the development environment and unpacking it into diff-able source files:

```bash
pac solution export --name WinVault --managed false --path out/WinVault.zip
pac solution unpack --zipfile out/WinVault.zip --folder src/WinVault --packagetype Unmanaged
```

This is the standard Power Platform ALM source-control pattern — the same mechanic that an automated CI/CD pipeline performs, done explicitly here to keep the solution's evolution visible commit by commit.

---

## Build status

This project is built in stages:

- ✅ **v1 — Data & App** — relational data model, model-driven app, forms and views; established in source control.
- 🔲 **v2 — Pro-code & automation** — C# plug-ins, PCF control, Power Automate flows, Power BI report.
- 🔲 **v3 — AI** — a Copilot Studio agent grounded in the wins data.

---

## Tech stack

Microsoft Dataverse · Model-driven Power Apps · C# (.NET) plug-ins · Power Apps Component Framework (PCF / TypeScript) · Power Automate · Power BI · Power Platform CLI · Git

---

*Built as a personal project to capture demonstrated work and to exercise end-to-end Power Platform architecture. The concept — capturing wins in Problem → Approach → Outcome form — is genuinely in daily use.*
