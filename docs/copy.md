# Copy

## Overview 
The entity represents a physical copy of a book that is available in the library. While the Book entity represents the publication itself, the copy represents an individual physical resource that can be borrowed, returned, become unavailable or be removed from circulation.  

## Lifecycle
The lifecycle of a Copy starts when a physical copy is added to an existing Book. At this stage, the system creates a new Copy record and associates it with the corresponding book. A newly created copy is normally assigned the Available status, meaning that it is ready to be borrowed.

Once the copy exists, its lifecycle is independent from the lifecycle of the Book. The copy can change its status as a result of borrowing, returning, maintenance, damage, loss, or other library operations. The most common lifecycle is:

```
Copy created → Available → Borrowed → Available
```

## Availability
Book availability is derived from the current status of its physical copies. The entity should not store an independent `IsAvailable` property, because availability is determined by the `Copy` entities associated with the book. A book is considered **available for borrowing** when at least one of its copies has the `Available` status. The following `Copy` statuses are considered **not available for borrowing**:

| Copy Status     | Description                                                                                                 | Available for Borrowing |
| --------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------: |
| `Available`     | The copy is available and can be borrowed.                                                                  |                     Yes |
| `Borrowed`      | The copy is currently borrowed by a library user.                                                           |                      No |
| `Reserved`      | The copy is reserved for a specific user and is not available for general borrowing.                        |                      No |
| `Unavailable`   | The copy is temporarily unavailable for operational or other business reasons.                              |                      No |
| `Damaged`       | The copy is damaged and cannot currently be borrowed.                                                       |                      No |
| `Lost`          | The copy has been determined to be lost.                                                                    |                      No |
| `Missing`       | The copy cannot currently be located and its final status has not yet been determined.                      |                      No |
| `ToBeWithdrawn` | The copy has been marked for withdrawal and is awaiting completion of the withdrawal process.               |                      No |
| `Withdrawn`     | The copy has been permanently withdrawn from circulation.                                                   |                      No |
| `Archived`      | The copy is retained for historical or administrative purposes but is no longer part of active circulation. |                      No |

The availability rule is therefore:

```text
Book is available = at least one Copy has Status = Available
```

For example:

```text
Copy #1 — Borrowed
Copy #2 — Damaged
Copy #3 — Available
```

The book is available because `Copy #3` can be borrowed.

If all copies have a non-available status:

```text
Copy #1 — Borrowed
Copy #2 — Reserved
Copy #3 — ToBeWithdrawn
```

The book is unavailable.  
