# Design Decisions

## 1. Database Design

### Dynamic Categories & Attributes
- Instead of creating separate tables for each product type (e.g., `Shoes`, `Watches`, `Smartphones`), I used a **Category–Attribute–Product mapping**.  
- This allows new categories and attributes to be added dynamically, without altering the schema structure.

### Normalization
- The schema follows **Third Normal Form (3NF)**:
  - **Categories** are stored independently from **Products**.
  - **Attributes** are stored in a separate table, avoiding duplicate fields across categories.
  - A **ProductAttributeValue** table links products with their attribute values.
- This avoids schema changes when new attributes or categories are introduced.

### Scalability & Future-Proofing
- New product categories (e.g., Grooming Products, Accessories) can be created simply by inserting records in the **Categories** table.
- Category-specific attributes are defined in the **Attributes** table and linked using a junction table.
- This design avoids the need for schema redesign every 6 months as new categories are added.

---

## 2. Class Design

### Entity Representation
- Each database entity has a corresponding class:
  - `Category`
  - `Product`
  - `Attribute`
  - `ProductAttributeValue`
- This ensures a clean mapping between the database schema and application code.

### Relationships
- **Category** → has many **Attributes**.
- **Product** → belongs to one **Category**, has many **AttributeValues**.
- **Attribute** → can be reused across categories.
- These relationships mirror the ERD, ensuring consistency between database and code.

### Extensibility
- Adding a new category (e.g., "Smartphones") does not require creating new tables or classes.
- Business logic is encapsulated inside service classes (`CategoryService`, `ProductService`, `AttributeService`), making the design more maintainable.

---

## 3. Why This Approach?
- **Flexibility** → Supports dynamic categories and attributes without schema change.
- **Maintainability** → Clear separation of concerns between database schema, classes, and services.
- **Future-Proofing** → New categories and attributes can be onboarded through **data entries** instead of **schema/code changes**.

---
