# ProductCatalog
Internal Product Catalog Management Tool for eCommerce. Enables merchandisers and category managers to define product categories, custom attributes, and manage products with category-specific attributes. Designed for scalability and future category expansion.

# ProductCatalog

Internal **Product Catalog Management Tool** for an eCommerce platform.  
This tool enables merchandisers and category managers to define product categories, add custom attributes, and manage products with category-specific attributes.  
It is designed for **scalability**, **normalization**, and **future category expansion**.

---

##  Task Overview

The assignment was completed in three structured steps:

1. **Database Design**  
2. **Class Design**  
3. **Implementation**

Each step and its deliverables are described below.

---

## Step 1: Database Design

###  Goal
Design a scalable, relational database schema that supports:
- Dynamic product categories  
- Custom attributes per category  
- Product creation and updates  

###  Deliverables
- **ERD (Entity Relationship Diagram)** → [`docs/ERD.png`](./docs/ERD.png)  
- **Design Justification** → [`docs/Design_Decisions.md`](./docs/Design_Decisions.md)  

###  Justification Summary
- Database is **normalized** to avoid redundancy  
- **Category–Attribute–Product** model ensures flexibility  
- **ProductAttribute** junction table supports custom attributes dynamically  
- Future categories can be added without changing schema  

---

##  Step 2: Class Design

### Goal
Translate the database schema into a maintainable and extensible class model.

###  Deliverables
- **Class Diagram** → [`docs/ClassDiagram.png`](./docs/ClassDiagram.png)  

###  Highlights
- **Entities**: Product, Category, Attribute, ProductAttribute  
- **Relationships**:  
  - A Category defines many Attributes  
  - A Product belongs to one Category  
  - A Product has many Attribute values  
- **Key Methods** included for getters/setters and CRUD operations  

---

##  Step 3: Implementation

### Goal
Implement the internal tool with functionality to manage:
- Categories  
- Attributes  
- Products  

### Deliverables
- **Working Code** → [`src/`](./src/)  
- **Entry Point** → [`src/Program.cs`](./src/Program.cs)  

###  Implementation Details
- **Tech Stack**:  
  - C# (.NET)  
  - SQL Server (Relational Database)  
- **Structure**:  
  - `Entities/` → Domain classes  
  - `Services/` → Business logic (CategoryService, ProductService, AttributeService)  
  - `DBHelper.cs` → Database connection helper  
  - `Program.cs` → Console-based UI  


   git clone https://github.com/<your-username>/ProductCatalog.git
   cd ProductCatalog
