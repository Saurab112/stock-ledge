# stock-ledge

**A ledger-first inventory management system built with ASP.NET Core.**

> 🚧 Work in Progress — StockLedger is currently under active development. Features and documentation are being implemented incrementally.

## Overview

StockLedger is a backend-focused inventory management system designed to explore real-world inventory management concepts, with an emphasis on inventory accuracy, transaction history, and cost tracking.

The system follows a ledger-first approach, where inventory transactions are recorded as immutable ledger entries, while current stock balances are maintained as derived data.

The project is being developed to explore practical software engineering concepts, including domain modeling, layered architecture, database design, and inventory business rules.

## Planned Features

- **Product Management** — Manage products and their stockable variants.
- **Multi-Warehouse Inventory** — Track stock across multiple warehouses.
- **Unit of Measure (UOM)** — Manage unit groups, base units, and conversion multipliers.
- **Stock Ledger** — Maintain an auditable history of inventory movements.
- **FIFO Costing** — Track inventory costs using First-In, First-Out valuation.
- **Purchase Management** — Record purchases and stock receipts.
- **Sales Management** — Manage sales and inventory deductions.
- **Stock Transfers** — Transfer inventory between warehouses.
- **Stock Adjustments** — Record inventory corrections and adjustments.
- **Approval Workflows** — Support approval-based inventory operations.

## Technology Stack

- **Backend:** C#, ASP.NET Core Web API
- **ORM:** Entity Framework Core
- **Database:** MySQL 
- **Architecture:** Layered Architecture
- **API Documentation:** Swagger / OpenAPI

## Architecture

The solution follows a layered architecture to separate business logic, application services, persistence, and API concerns.

```text
StockLedge/
│
├── StockLedge.Domain/
├── StockLedge.Application/
├── StockLedge.Data/
└── StockLedge.Api/
```

- **Domain:** Entities, business rules, and domain exceptions.
- **Application:** Application services, interfaces, and DTOs.
- **Data:** Entity Framework Core configurations and persistence implementations.
- **API:** Controllers, HTTP endpoints, and exception handling.

## Status

StockLedger is a personal backend development project currently under development. The implementation is progressing incrementally, with a focus on maintainable code, explicit business rules, and reliable inventory transaction handling.

More features and documentation will be added as development progresses.
