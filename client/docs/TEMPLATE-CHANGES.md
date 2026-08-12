# Angular Admin Template — Change Log & Porting Guide

Written 2026-08-02. Two purposes:

1. **Resume tomorrow** — see [Open items](#open-items).
2. **Replay on another project** — see [Porting to another project](#porting-to-another-project).

Baseline: Angular 19.2, Angular Material 19.2, standalone components, no NgModules.
Everything below is verified against a production build (`ng build`) unless a
line says otherwise.

---

## 1. Footer moved to the master page

The same `<footer>` was copy-pasted into every feature page, with its own
`.app-footer` CSS duplicated in each component stylesheet.

- **Added** `src/app/core/layout/footer/footer.component.ts` — standalone,
  inline template/styles, year from `new Date().getFullYear()`.
- **Changed** `main-layout.component.html` — `<app-footer>` after `<router-outlet>`.
- **Removed** the `<footer>` block and `.app-footer` rules from `view-country`,
  `view-city`, `view-test`.

---

## 2. Create/Edit as a page, with a dialog/page switch

### The dual-mode component

`country-form` and `city-form` replace the old `country-dialog` / `city-dialog`
(deleted). **One component renders both ways** — no duplicated form markup:

```ts
// Present only when opened through MatDialog; null on the routed page.
private readonly dialogRef = inject(MatDialogRef, { optional: true });
private readonly data = inject<CountryFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });
readonly isDialog = !!this.dialogRef;
```

- **Dialog**: mode + item arrive via `MAT_DIALOG_DATA`; `close()` calls `dialogRef.close(saved)`.
- **Page**: mode comes from `route.snapshot.data['mode']`, id from
  `route.snapshot.paramMap` (validated: `Number.isInteger(id) && id > 0`), the
  record is fetched with `getById`, and `close()` navigates back to the list.

The template is a **single linear flow**, not two branches. Only the header
differs (`*ngIf="!isDialog"` full banner / `*ngIf="isDialog"` plain title row).
Deliberately does **not** use `mat-dialog-title/content/actions` — a dialog can
host any component, and dropping those directives removed `MatDialogModule`
from the imports entirely. `.page-card--dialog` strips the card border/radius
inside the overlay.

Buttons live **inside** `<form>` with `type="submit"` + `(ngSubmit)="save()"`, so
Enter submits.

### The switch

`src/app/core/services/form-view-mode.service.ts` — a signal persisted to
`localStorage`, **default `'page'`**:

```ts
private readStored(): FormViewMode {
  try { return localStorage.getItem(STORAGE_KEY) === 'dialog' ? 'dialog' : 'page'; }
  catch { return 'page'; }
}
```

The `=== 'dialog' ? … : 'page'` *is* the allowlist — localStorage is
user-editable, so an unknown value can never reach the app.

UI: a labelled `mat-button-toggle-group` in the toolbar ("Add / Edit in
[Page | Dialog]"). The list components branch on it:

```ts
onNew(): void {
  if (this.viewMode.isDialog()) { this.openForm({ mode: 'create' }); return; }
  this.router.navigate(['/country/new']);
}
```

> **Gotcha:** the preference is sticky per browser. A browser that loaded the
> app while the default was `'dialog'` keeps using dialogs until the switch is
> clicked or site data is cleared.

### Routes

`country/new`, `country/:id/edit`, `city/new`, `city/:id/edit` — each with
`data: { mode }` and a `title`. Also added `title` to the list routes and a
`{ path: '**', redirectTo: 'country' }` fallback.

---

## 3. Shared styles + tokens (`src/styles.css`)

Each feature had ~120 lines of near-identical CSS differing only in accent
colour. Now the layout classes live once in the global sheet, driven by CSS
custom properties, and a feature stylesheet is ~10 lines:

```css
:host {
  --page-accent: #3a7bd5;
  --page-accent-dark: #1e50a8;
  --page-accent-soft: #e8f0fe;
  --page-accent-shadow: rgba(30, 80, 168, 0.35);
  --page-row-hover: #eef4fc;
  --page-banner: radial-gradient(…);
}
```

Global classes: `.page-card`, `.banner*`, `.field-grid`, `.filter-bar*`,
`.table-header`, `.table-actions`, `.table-toolbar*`, `.export-btn*`,
`.table-wrapper`, `.data-table*` (renamed from `.farm-table`), `.table-empty`,
`.action-btn*`, `.form-page*`, `.field-error`, `.notify--*`.

### Field grid (2 columns)

```css
.field-grid,
.filter-bar__row {
  display: grid;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  column-gap: 16px; row-gap: 4px;
  align-items: start;
}
.field-grid > *, .filter-bar__row > * { width: 100%; }
.field-grid__full { grid-column: 1 / -1; }
@media (max-width: 760px) { /* → single column */ }
```

`minmax(0, 1fr)` is what makes the columns *equal*; plain `1fr` lets a long
field widen its column. Filter bars get it for free because
`.filter-bar__row` shares the declaration block; forms opt in by wrapping
fields in `.field-grid`.

Dialogs are opened at `width: '720px'` so the two columns match the page.

### One-line table header

`.table-header` is a `space-between` flex row wrapping `.table-actions` (left)
and `.table-toolbar` (right); the padding moved from the two children to the
wrapper. Below 760px `.table-toolbar { flex: 1 1 100% }` drops it to its own row.

---

## 4. Collapsible sidebar

- Toolbar button toggles `sidebarOpen`; icon flips `menu` ⇄ `menu_open`.
- `sidebarOpen = !this.isMobile()` → **collapsed by default under 760px**.
- Under 760px the sidebar becomes `position: fixed` and overlays the content
  with a `.sidebar-backdrop`; tapping the backdrop or any nav link closes it.
- Breakpoint literal exists twice — `MOBILE_QUERY` in the TS and the media
  query in the CSS. Each has a comment pointing at the other. **Keep in sync.**

### Sidebar menu is data-driven and route-aware

The groups used to be hardcoded `<app-accordion>` blocks that **collapsed on
every refresh**, because `AccordionComponent.isOpen` always started `false`.

```ts
navGroups: NavGroup[] = [
  { title: 'Master Data', icon: 'dns', links: [{ label: 'test', path: '/test' }] },
  { title: 'Geography', icon: 'public', links: [
      { label: 'Countries', path: '/country' }, { label: 'Cities', path: '/city' }] },
];
isGroupActive(g: NavGroup) { return g.links.some(l => this.router.url.startsWith(l.path)); }
```

`AccordionComponent` gained an `expanded` input whose setter **only ever
opens**, so a manual collapse isn't undone on the next change-detection pass:

```ts
@Input() set expanded(open: boolean) { if (open) this.isOpen = true; }
```

`startsWith` keeps the group open on `/country/new` and `/country/5/edit` too.
Adding a menu entry is now one line in `navGroups`.

---

## 5. Correctness / hygiene fixes

| Fix | Why it mattered |
|---|---|
| `config.ts` + `base.service.ts` now import `environments/environment`, not `environment.development` | `fileReplacements` only swaps `environment.ts`, so **production builds shipped the dev API URL** |
| `httpErrorInterceptor` + `NotificationService` (MatSnackBar) | Save/delete failures were silently swallowed — the user saw nothing. Messages are generic per status code; server text is never shown |
| Success toasts on create/update/delete | — |
| `@Injectable()` on `BaseService` (was `providedIn: 'root'`) | An abstract base with a non-injectable constructor arg can never be resolved that way |
| Removed dead sidebar link to `/Material` | No such route existed; clicking it silently blanked the content area |
| `country-autocomplete`: clear the bound id on free text; `id == null` instead of `!id` | A stale `countryId` could be submitted after typing over a selection |
| `ViewTestComponent implements OnInit, AfterViewInit` | Lifecycle methods existed without the interface |
| Deleted dead code | `app.component.ts` commented block + unused imports, unused `MatDialog` in `view-test`, duplicated lines in `styles.css`, orphaned `.status-chip*` / `.btn-danger` / `.topbar__tab*` CSS |

---

## Open items

Nothing is half-finished — these are decisions and unverified areas.

1. **Bundle budget warning.** Production initial bundle is ~581 kB against the
   default 500 kB. Measured: it was already ~564 kB before this work, so it is
   **pre-existing**; the toolbar switch + snackbar add ~17 kB. Raising
   `maximumWarning` to ~700 kB in `angular.json` is normal for a Material app,
   but budgets shouldn't be widened silently — your call.
2. **Dialog presentation never visually verified.** Everything was checked with
   headless Chrome screenshots + a same-origin DOM probe; clicking the switch
   and then a row's Edit needs a real driver. Adding Playwright as a
   devDependency would close this.
3. **Mobile stacking of `.table-header`** not re-screenshotted after the
   one-line change (the CSS path is `flex: 1 1 100%`).
4. **Filter fields have no `appearance="outline"`** while form fields do, so
   filters render in Material's fill style. Inconsistent — worth aligning.
5. **`environment.ts` still points at `http://localhost:3000`.** It is the
   *production* file; set the real URL before deploying.
6. **No tests.** Only the default `app.component.spec.ts` exists. Business
   logic worth covering: `FormViewModeService` storage allowlist,
   `httpErrorInterceptor` status→message mapping, the form components'
   create-vs-edit branch.
7. **Deliberate duplication.** `country-form`/`city-form` and
   `view-country`/`view-city` are ~85% identical. A generic base class was
   considered and **rejected**: in a template repo you make a new module by
   copying a folder, and inheritance would make that require understanding a
   base class first. Revisit only if the module count grows a lot.

---

## Porting to another project

Ordered so each step compiles on its own.

1. **Global styles** — copy `src/styles.css`. It is self-contained (tokens +
   layout classes). Rename `.farm-table` → `.data-table` in existing templates.
2. **Per-feature stylesheets** — delete the duplicated layout CSS, keep only
   the `:host { --page-* }` token block plus genuinely local rules
   (badges/chips).
3. **Footer** — copy `core/layout/footer/`, render it once in the layout,
   delete the per-page copies.
4. **Notifications** — copy `core/services/notification.service.ts` and
   `core/interceptors/http-error.interceptor.ts`; register with
   `provideHttpClient(withInterceptors([httpErrorInterceptor]))`.
5. **View-mode switch** — copy `Shared/Model/FormViewMode.ts`,
   `Shared/Model/FormMode.ts`, `core/services/form-view-mode.service.ts`; add
   the `mat-button-toggle-group` to the toolbar.
6. **Per entity**: rename `x-dialog` → `x-form`, apply the dual-mode injection
   + single-flow template, add the two routes with `data: { mode }`, and branch
   `onNew`/`onEdit` on `viewMode.isDialog()`.
7. **Sidebar** — copy the `navGroups` / `isGroupActive` / `sidebarOpen` members,
   the accordion `expanded` setter, and the mobile media query. Keep
   `MOBILE_QUERY` and the CSS breakpoint identical.
8. **Check the environment import bug** — `grep -r "environment.development" src/`
   should only match `environment.development.ts` itself.

### Verify

```bash
ng build                 # production; must be error-free
ng serve --port 4300
```

Headless checks used here (no driver needed — Chrome only):

```bash
chrome --headless --disable-gpu --window-size=1440,900 \
  --virtual-time-budget=9000 --screenshot=out.png http://localhost:4300/country/new
```

> **Measuring caveat:** under `--virtual-time-budget`, CSS transitions freeze at
> their *start* value, so transitioned properties (the sidebar's `width`/
> `padding`) read as 0 even when open. Set `el.style.transition = 'none'` before
> measuring. Also, `--window-size` does not always drive the layout viewport —
> a "mobile" screenshot can be a desktop layout merely cropped. Check whether
> elements the media query hides are visible before trusting it.
