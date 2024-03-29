﻿(function (a, b) { function b$(a) { return d.isWindow(a) ? a : a.nodeType === 9 ? a.defaultView || a.parentWindow : !1 } function bX(a) { if (!bR[a]) { var b = d("<" + a + ">").appendTo("body"), c = b.css("display"); b.remove(); if (c === "none" || c === "") c = "block"; bR[a] = c } return bR[a] } function bW(a, b) { var c = {}; d.each(bV.concat.apply([], bV.slice(0, b)), function () { c[this] = a }); return c } function bJ(a, c) { a.dataFilter && (c = a.dataFilter(c, a.dataType)); var e = a.dataTypes, f = a.converters, g, h = e.length, i, j = e[0], k, l, m, n, o; for (g = 1; g < h; g++) { k = j, j = e[g]; if (j === "*") j = k; else if (k !== "*" && k !== j) { l = k + " " + j, m = f[l] || f["* " + j]; if (!m) { o = b; for (n in f) { i = n.split(" "); if (i[0] === k || i[0] === "*") { o = f[i[1] + " " + j]; if (o) { n = f[n], n === !0 ? m = o : o === !0 && (m = n); break } } } } !m && !o && d.error("No conversion from " + l.replace(" ", " to ")), m !== !0 && (c = m ? m(c) : o(n(c))) } } return c } function bI(a, c, d) { var e = a.contents, f = a.dataTypes, g = a.responseFields, h, i, j, k; for (i in g) i in d && (c[g[i]] = d[i]); while (f[0] === "*") f.shift(), h === b && (h = c.getResponseHeader("content-type")); if (h) for (i in e) if (e[i] && e[i].test(h)) { f.unshift(i); break } if (f[0] in d) j = f[0]; else { for (i in d) { if (!f[0] || a.converters[i + " " + f[0]]) { j = i; break } k || (k = i) } j = j || k } if (j) { j !== f[0] && f.unshift(j); return d[j] } } function bH(a, b, c, e) { d.isArray(b) && b.length ? d.each(b, function (b, f) { c || bp.test(a) ? e(a, f) : bH(a + "[" + (typeof f === "object" || d.isArray(f) ? b : "") + "]", f, c, e) }) : c || b == null || typeof b !== "object" ? e(a, b) : d.isArray(b) || d.isEmptyObject(b) ? e(a, "") : d.each(b, function (b, d) { bH(a + "[" + b + "]", d, c, e) }) } function bG(a, c, d, e, f, g) { f = f || c.dataTypes[0], g = g || {}, g[f] = !0; var h = a[f], i = 0, j = h ? h.length : 0, k = a === bD, l; for (; i < j && (k || !l); i++) l = h[i](c, d, e), typeof l === "string" && (g[l] ? l = b : (c.dataTypes.unshift(l), l = bG(a, c, d, e, l, g))); (k || !l) && !g["*"] && (l = bG(a, c, d, e, "*", g)); return l } function bF(a) { return function (b, c) { typeof b !== "string" && (c = b, b = "*"); if (d.isFunction(c)) { var e = b.toLowerCase().split(bz), f = 0, g = e.length, h, i, j; for (; f < g; f++) h = e[f], j = /^\+/.test(h), j && (h = h.substr(1) || "*"), i = a[h] = a[h] || [], i[j ? "unshift" : "push"](c) } } } function bn(a, b, c) { var e = b === "width" ? bh : bi, f = b === "width" ? a.offsetWidth : a.offsetHeight; if (c === "border") return f; d.each(e, function () { c || (f -= parseFloat(d.css(a, "padding" + this)) || 0), c === "margin" ? f += parseFloat(d.css(a, "margin" + this)) || 0 : f -= parseFloat(d.css(a, "border" + this + "Width")) || 0 }); return f } function _(a, b) { b.src ? d.ajax({ url: b.src, async: !1, dataType: "script" }) : d.globalEval(b.text || b.textContent || b.innerHTML || ""), b.parentNode && b.parentNode.removeChild(b) } function $(a, b) { if (b.nodeType === 1) { var c = b.nodeName.toLowerCase(); b.clearAttributes(), b.mergeAttributes(a); if (c === "object") b.outerHTML = a.outerHTML; else if (c !== "input" || a.type !== "checkbox" && a.type !== "radio") { if (c === "option") b.selected = a.defaultSelected; else if (c === "input" || c === "textarea") b.defaultValue = a.defaultValue } else a.checked && (b.defaultChecked = b.checked = a.checked), b.value !== a.value && (b.value = a.value); b.removeAttribute(d.expando) } } function Z(a, b) { if (b.nodeType === 1 && d.hasData(a)) { var c = d.expando, e = d.data(a), f = d.data(b, e); if (e = e[c]) { var g = e.events; f = f[c] = d.extend({}, e); if (g) { delete f.handle, f.events = {}; for (var h in g) for (var i = 0, j = g[h].length; i < j; i++) d.event.add(b, h, g[h][i], g[h][i].data) } } } } function Y(a, b) { return d.nodeName(a, "table") ? a.getElementsByTagName("tbody")[0] || a.appendChild(a.ownerDocument.createElement("tbody")) : a } function O(a, b, c) { if (d.isFunction(b)) return d.grep(a, function (a, d) { var e = !!b.call(a, d, a); return e === c }); if (b.nodeType) return d.grep(a, function (a, d) { return a === b === c }); if (typeof b === "string") { var e = d.grep(a, function (a) { return a.nodeType === 1 }); if (J.test(b)) return d.filter(b, e, !c); b = d.filter(b, e) } return d.grep(a, function (a, e) { return d.inArray(a, b) >= 0 === c }) } function N(a) { return !a || !a.parentNode || a.parentNode.nodeType === 11 } function F(a, b) { return (a && a !== "*" ? a + "." : "") + b.replace(q, "`").replace(r, "&") } function E(a) { var b, c, e, f, g, h, i, j, k, l, m, n, p, q = [], r = [], s = d._data(this, u); typeof s === "function" && (s = s.events); if (a.liveFired !== this && s && s.live && !a.target.disabled && (!a.button || a.type !== "click")) { a.namespace && (n = new RegExp("(^|\\.)" + a.namespace.split(".").join("\\.(?:.*\\.)?") + "(\\.|$)")), a.liveFired = this; var t = s.live.slice(0); for (i = 0; i < t.length; i++) g = t[i], g.origType.replace(o, "") === a.type ? r.push(g.selector) : t.splice(i--, 1); f = d(a.target).closest(r, a.currentTarget); for (j = 0, k = f.length; j < k; j++) { m = f[j]; for (i = 0; i < t.length; i++) { g = t[i]; if (m.selector === g.selector && (!n || n.test(g.namespace))) { h = m.elem, e = null; if (g.preType === "mouseenter" || g.preType === "mouseleave") a.type = g.preType, e = d(a.relatedTarget).closest(g.selector)[0]; (!e || e !== h) && q.push({ elem: h, handleObj: g, level: m.level }) } } } for (j = 0, k = q.length; j < k; j++) { f = q[j]; if (c && f.level > c) break; a.currentTarget = f.elem, a.data = f.handleObj.data, a.handleObj = f.handleObj, p = f.handleObj.origHandler.apply(f.elem, arguments); if (p === !1 || a.isPropagationStopped()) { c = f.level, p === !1 && (b = !1); if (a.isImmediatePropagationStopped()) break } } return b } } function C(a, b, c) { c[0].type = a; return d.event.handle.apply(b, c) } function w() { return !0 } function v() { return !1 } function f(a, c, f) { if (f === b && a.nodeType === 1) { f = a.getAttribute("data-" + c); if (typeof f === "string") { try { f = f === "true" ? !0 : f === "false" ? !1 : f === "null" ? null : d.isNaN(f) ? e.test(f) ? d.parseJSON(f) : f : parseFloat(f) } catch (g) { } d.data(a, c, f) } else f = b } return f } var c = a.document, d = function () { function I() { if (!d.isReady) { try { c.documentElement.doScroll("left") } catch (a) { setTimeout(I, 1); return } d.ready() } } var d = function (a, b) { return new d.fn.init(a, b, g) }, e = a.jQuery, f = a.$, g, h = /^(?:[^<]*(<[\w\W]+>)[^>]*$|#([\w\-]+)$)/, i = /\S/, j = /^\s+/, k = /\s+$/, l = /\d/, m = /^<(\w+)\s*\/?>(?:<\/\1>)?$/, n = /^[\],:{}\s]*$/, o = /\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, p = /"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, q = /(?:^|:|,)(?:\s*\[)+/g, r = /(webkit)[ \/]([\w.]+)/, s = /(opera)(?:.*version)?[ \/]([\w.]+)/, t = /(msie) ([\w.]+)/, u = /(mozilla)(?:.*? rv:([\w.]+))?/, v = navigator.userAgent, w, x = !1, y, z = "then done fail isResolved isRejected promise".split(" "), A, B = Object.prototype.toString, C = Object.prototype.hasOwnProperty, D = Array.prototype.push, E = Array.prototype.slice, F = String.prototype.trim, G = Array.prototype.indexOf, H = {}; d.fn = d.prototype = { constructor: d, init: function (a, e, f) { var g, i, j, k; if (!a) return this; if (a.nodeType) { this.context = this[0] = a, this.length = 1; return this } if (a === "body" && !e && c.body) { this.context = c, this[0] = c.body, this.selector = "body", this.length = 1; return this } if (typeof a === "string") { g = h.exec(a); if (!g || !g[1] && e) return !e || e.jquery ? (e || f).find(a) : this.constructor(e).find(a); if (g[1]) { e = e instanceof d ? e[0] : e, k = e ? e.ownerDocument || e : c, j = m.exec(a), j ? d.isPlainObject(e) ? (a = [c.createElement(j[1])], d.fn.attr.call(a, e, !0)) : a = [k.createElement(j[1])] : (j = d.buildFragment([g[1]], [k]), a = (j.cacheable ? d.clone(j.fragment) : j.fragment).childNodes); return d.merge(this, a) } i = c.getElementById(g[2]); if (i && i.parentNode) { if (i.id !== g[2]) return f.find(a); this.length = 1, this[0] = i } this.context = c, this.selector = a; return this } if (d.isFunction(a)) return f.ready(a); a.selector !== b && (this.selector = a.selector, this.context = a.context); return d.makeArray(a, this) }, selector: "", jquery: "1.5", length: 0, size: function () { return this.length }, toArray: function () { return E.call(this, 0) }, get: function (a) { return a == null ? this.toArray() : a < 0 ? this[this.length + a] : this[a] }, pushStack: function (a, b, c) { var e = this.constructor(); d.isArray(a) ? D.apply(e, a) : d.merge(e, a), e.prevObject = this, e.context = this.context, b === "find" ? e.selector = this.selector + (this.selector ? " " : "") + c : b && (e.selector = this.selector + "." + b + "(" + c + ")"); return e }, each: function (a, b) { return d.each(this, a, b) }, ready: function (a) { d.bindReady(), y.done(a); return this }, eq: function (a) { return a === -1 ? this.slice(a) : this.slice(a, +a + 1) }, first: function () { return this.eq(0) }, last: function () { return this.eq(-1) }, slice: function () { return this.pushStack(E.apply(this, arguments), "slice", E.call(arguments).join(",")) }, map: function (a) { return this.pushStack(d.map(this, function (b, c) { return a.call(b, c, b) })) }, end: function () { return this.prevObject || this.constructor(null) }, push: D, sort: [].sort, splice: [].splice }, d.fn.init.prototype = d.fn, d.extend = d.fn.extend = function () { var a, c, e, f, g, h, i = arguments[0] || {}, j = 1, k = arguments.length, l = !1; typeof i === "boolean" && (l = i, i = arguments[1] || {}, j = 2), typeof i !== "object" && !d.isFunction(i) && (i = {}), k === j && (i = this, --j); for (; j < k; j++) if ((a = arguments[j]) != null) for (c in a) { e = i[c], f = a[c]; if (i === f) continue; l && f && (d.isPlainObject(f) || (g = d.isArray(f))) ? (g ? (g = !1, h = e && d.isArray(e) ? e : []) : h = e && d.isPlainObject(e) ? e : {}, i[c] = d.extend(l, h, f)) : f !== b && (i[c] = f) } return i }, d.extend({ noConflict: function (b) { a.$ = f, b && (a.jQuery = e); return d }, isReady: !1, readyWait: 1, ready: function (a) { a === !0 && d.readyWait--; if (!d.readyWait || a !== !0 && !d.isReady) { if (!c.body) return setTimeout(d.ready, 1); d.isReady = !0; if (a !== !0 && --d.readyWait > 0) return; y.resolveWith(c, [d]), d.fn.trigger && d(c).trigger("ready").unbind("ready") } }, bindReady: function () { if (!x) { x = !0; if (c.readyState === "complete") return setTimeout(d.ready, 1); if (c.addEventListener) c.addEventListener("DOMContentLoaded", A, !1), a.addEventListener("load", d.ready, !1); else if (c.attachEvent) { c.attachEvent("onreadystatechange", A), a.attachEvent("onload", d.ready); var b = !1; try { b = a.frameElement == null } catch (e) { } c.documentElement.doScroll && b && I() } } }, isFunction: function (a) { return d.type(a) === "function" }, isArray: Array.isArray || function (a) { return d.type(a) === "array" }, isWindow: function (a) { return a && typeof a === "object" && "setInterval" in a }, isNaN: function (a) { return a == null || !l.test(a) || isNaN(a) }, type: function (a) { return a == null ? String(a) : H[B.call(a)] || "object" }, isPlainObject: function (a) { if (!a || d.type(a) !== "object" || a.nodeType || d.isWindow(a)) return !1; if (a.constructor && !C.call(a, "constructor") && !C.call(a.constructor.prototype, "isPrototypeOf")) return !1; var c; for (c in a) { } return c === b || C.call(a, c) }, isEmptyObject: function (a) { for (var b in a) return !1; return !0 }, error: function (a) { throw a }, parseJSON: function (b) { if (typeof b !== "string" || !b) return null; b = d.trim(b); if (n.test(b.replace(o, "@").replace(p, "]").replace(q, ""))) return a.JSON && a.JSON.parse ? a.JSON.parse(b) : (new Function("return " + b))(); d.error("Invalid JSON: " + b) }, parseXML: function (b, c, e) { a.DOMParser ? (e = new DOMParser, c = e.parseFromString(b, "text/xml")) : (c = new ActiveXObject("Microsoft.XMLDOM"), c.async = "false", c.loadXML(b)), e = c.documentElement, (!e || !e.nodeName || e.nodeName === "parsererror") && d.error("Invalid XML: " + b); return c }, noop: function () { }, globalEval: function (a) { if (a && i.test(a)) { var b = c.getElementsByTagName("head")[0] || c.documentElement, e = c.createElement("script"); e.type = "text/javascript", d.support.scriptEval() ? e.appendChild(c.createTextNode(a)) : e.text = a, b.insertBefore(e, b.firstChild), b.removeChild(e) } }, nodeName: function (a, b) { return a.nodeName && a.nodeName.toUpperCase() === b.toUpperCase() }, each: function (a, c, e) { var f, g = 0, h = a.length, i = h === b || d.isFunction(a); if (e) { if (i) { for (f in a) if (c.apply(a[f], e) === !1) break } else for (; g < h; ) if (c.apply(a[g++], e) === !1) break } else if (i) { for (f in a) if (c.call(a[f], f, a[f]) === !1) break } else for (var j = a[0]; g < h && c.call(j, g, j) !== !1; j = a[++g]) { } return a }, trim: F ? function (a) { return a == null ? "" : F.call(a) } : function (a) { return a == null ? "" : (a + "").replace(j, "").replace(k, "") }, makeArray: function (a, b) { var c = b || []; if (a != null) { var e = d.type(a); a.length == null || e === "string" || e === "function" || e === "regexp" || d.isWindow(a) ? D.call(c, a) : d.merge(c, a) } return c }, inArray: function (a, b) { if (b.indexOf) return b.indexOf(a); for (var c = 0, d = b.length; c < d; c++) if (b[c] === a) return c; return -1 }, merge: function (a, c) { var d = a.length, e = 0; if (typeof c.length === "number") for (var f = c.length; e < f; e++) a[d++] = c[e]; else while (c[e] !== b) a[d++] = c[e++]; a.length = d; return a }, grep: function (a, b, c) { var d = [], e; c = !!c; for (var f = 0, g = a.length; f < g; f++) e = !!b(a[f], f), c !== e && d.push(a[f]); return d }, map: function (a, b, c) { var d = [], e; for (var f = 0, g = a.length; f < g; f++) e = b(a[f], f, c), e != null && (d[d.length] = e); return d.concat.apply([], d) }, guid: 1, proxy: function (a, c, e) { arguments.length === 2 && (typeof c === "string" ? (e = a, a = e[c], c = b) : c && !d.isFunction(c) && (e = c, c = b)), !c && a && (c = function () { return a.apply(e || this, arguments) }), a && (c.guid = a.guid = a.guid || c.guid || d.guid++); return c }, access: function (a, c, e, f, g, h) { var i = a.length; if (typeof c === "object") { for (var j in c) d.access(a, j, c[j], f, g, e); return a } if (e !== b) { f = !h && f && d.isFunction(e); for (var k = 0; k < i; k++) g(a[k], c, f ? e.call(a[k], k, g(a[k], c)) : e, h); return a } return i ? g(a[0], c) : b }, now: function () { return (new Date).getTime() }, _Deferred: function () { var a = [], b, c, e, f = { done: function () { if (!e) { var c = arguments, g, h, i, j, k; b && (k = b, b = 0); for (g = 0, h = c.length; g < h; g++) i = c[g], j = d.type(i), j === "array" ? f.done.apply(f, i) : j === "function" && a.push(i); k && f.resolveWith(k[0], k[1]) } return this }, resolveWith: function (d, f) { if (!e && !b && !c) { c = 1; try { while (a[0]) a.shift().apply(d, f) } finally { b = [d, f], c = 0 } } return this }, resolve: function () { f.resolveWith(d.isFunction(this.promise) ? this.promise() : this, arguments); return this }, isResolved: function () { return c || b }, cancel: function () { e = 1, a = []; return this } }; return f }, Deferred: function (a) { var b = d._Deferred(), c = d._Deferred(), e; d.extend(b, { then: function (a, c) { b.done(a).fail(c); return this }, fail: c.done, rejectWith: c.resolveWith, reject: c.resolve, isRejected: c.isResolved, promise: function (a, c) { if (a == null) { if (e) return e; e = a = {} } c = z.length; while (c--) a[z[c]] = b[z[c]]; return a } }), b.then(c.cancel, b.cancel), delete b.cancel, a && a.call(b, b); return b }, when: function (a) { var b = arguments, c = b.length, e = c <= 1 && a && d.isFunction(a.promise) ? a : d.Deferred(), f = e.promise(), g; c > 1 ? (g = Array(c), d.each(b, function (a, b) { d.when(b).then(function (b) { g[a] = arguments.length > 1 ? E.call(arguments, 0) : b, --c || e.resolveWith(f, g) }, e.reject) })) : e !== a && e.resolve(a); return f }, uaMatch: function (a) { a = a.toLowerCase(); var b = r.exec(a) || s.exec(a) || t.exec(a) || a.indexOf("compatible") < 0 && u.exec(a) || []; return { browser: b[1] || "", version: b[2] || "0"} }, sub: function () { function a(b, c) { return new a.fn.init(b, c) } d.extend(!0, a, this), a.superclass = this, a.fn = a.prototype = this(), a.fn.constructor = a, a.subclass = this.subclass, a.fn.init = function b(b, c) { c && c instanceof d && !(c instanceof a) && (c = a(c)); return d.fn.init.call(this, b, c, e) }, a.fn.init.prototype = a.fn; var e = a(c); return a }, browser: {} }), y = d._Deferred(), d.each("Boolean Number String Function Array Date RegExp Object".split(" "), function (a, b) { H["[object " + b + "]"] = b.toLowerCase() }), w = d.uaMatch(v), w.browser && (d.browser[w.browser] = !0, d.browser.version = w.version), d.browser.webkit && (d.browser.safari = !0), G && (d.inArray = function (a, b) { return G.call(b, a) }), i.test(" ") && (j = /^[\s\xA0]+/, k = /[\s\xA0]+$/), g = d(c), c.addEventListener ? A = function () { c.removeEventListener("DOMContentLoaded", A, !1), d.ready() } : c.attachEvent && (A = function () { c.readyState === "complete" && (c.detachEvent("onreadystatechange", A), d.ready()) }); return a.jQuery = a.$ = d } (); (function () { d.support = {}; var b = c.createElement("div"); b.style.display = "none", b.innerHTML = "   <link/><table></table><a href='/a' style='color:red;float:left;opacity:.55;'>a</a><input type='checkbox'/>"; var e = b.getElementsByTagName("*"), f = b.getElementsByTagName("a")[0], g = c.createElement("select"), h = g.appendChild(c.createElement("option")); if (e && e.length && f) { d.support = { leadingWhitespace: b.firstChild.nodeType === 3, tbody: !b.getElementsByTagName("tbody").length, htmlSerialize: !!b.getElementsByTagName("link").length, style: /red/.test(f.getAttribute("style")), hrefNormalized: f.getAttribute("href") === "/a", opacity: /^0.55$/.test(f.style.opacity), cssFloat: !!f.style.cssFloat, checkOn: b.getElementsByTagName("input")[0].value === "on", optSelected: h.selected, deleteExpando: !0, optDisabled: !1, checkClone: !1, _scriptEval: null, noCloneEvent: !0, boxModel: null, inlineBlockNeedsLayout: !1, shrinkWrapBlocks: !1, reliableHiddenOffsets: !0 }, g.disabled = !0, d.support.optDisabled = !h.disabled, d.support.scriptEval = function () { if (d.support._scriptEval === null) { var b = c.documentElement, e = c.createElement("script"), f = "script" + d.now(); e.type = "text/javascript"; try { e.appendChild(c.createTextNode("window." + f + "=1;")) } catch (g) { } b.insertBefore(e, b.firstChild), a[f] ? (d.support._scriptEval = !0, delete a[f]) : d.support._scriptEval = !1, b.removeChild(e), b = e = f = null } return d.support._scriptEval }; try { delete b.test } catch (i) { d.support.deleteExpando = !1 } b.attachEvent && b.fireEvent && (b.attachEvent("onclick", function j() { d.support.noCloneEvent = !1, b.detachEvent("onclick", j) }), b.cloneNode(!0).fireEvent("onclick")), b = c.createElement("div"), b.innerHTML = "<input type='radio' name='radiotest' checked='checked'/>"; var k = c.createDocumentFragment(); k.appendChild(b.firstChild), d.support.checkClone = k.cloneNode(!0).cloneNode(!0).lastChild.checked, d(function () { var a = c.createElement("div"), b = c.getElementsByTagName("body")[0]; if (b) { a.style.width = a.style.paddingLeft = "1px", b.appendChild(a), d.boxModel = d.support.boxModel = a.offsetWidth === 2, "zoom" in a.style && (a.style.display = "inline", a.style.zoom = 1, d.support.inlineBlockNeedsLayout = a.offsetWidth === 2, a.style.display = "", a.innerHTML = "<div style='width:4px;'></div>", d.support.shrinkWrapBlocks = a.offsetWidth !== 2), a.innerHTML = "<table><tr><td style='padding:0;border:0;display:none'></td><td>t</td></tr></table>"; var e = a.getElementsByTagName("td"); d.support.reliableHiddenOffsets = e[0].offsetHeight === 0, e[0].style.display = "", e[1].style.display = "none", d.support.reliableHiddenOffsets = d.support.reliableHiddenOffsets && e[0].offsetHeight === 0, a.innerHTML = "", b.removeChild(a).style.display = "none", a = e = null } }); var l = function (a) { var b = c.createElement("div"); a = "on" + a; if (!b.attachEvent) return !0; var d = a in b; d || (b.setAttribute(a, "return;"), d = typeof b[a] === "function"), b = null; return d }; d.support.submitBubbles = l("submit"), d.support.changeBubbles = l("change"), b = e = f = null } })(); var e = /^(?:\{.*\}|\[.*\])$/; d.extend({ cache: {}, uuid: 0, expando: "jQuery" + (d.fn.jquery + Math.random()).replace(/\D/g, ""), noData: { embed: !0, object: "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000", applet: !0 }, hasData: function (a) { a = a.nodeType ? d.cache[a[d.expando]] : a[d.expando]; return !!a && !d.isEmptyObject(a) }, data: function (a, c, e, f) { if (d.acceptData(a)) { var g = d.expando, h = typeof c === "string", i, j = a.nodeType, k = j ? d.cache : a, l = j ? a[d.expando] : a[d.expando] && d.expando; if ((!l || f && l && !k[l][g]) && h && e === b) return; l || (j ? a[d.expando] = l = ++d.uuid : l = d.expando), k[l] || (k[l] = {}), typeof c === "object" && (f ? k[l][g] = d.extend(k[l][g], c) : k[l] = d.extend(k[l], c)), i = k[l], f && (i[g] || (i[g] = {}), i = i[g]), e !== b && (i[c] = e); if (c === "events" && !i[c]) return i[g] && i[g].events; return h ? i[c] : i } }, removeData: function (b, c, e) { if (d.acceptData(b)) { var f = d.expando, g = b.nodeType, h = g ? d.cache : b, i = g ? b[d.expando] : d.expando; if (!h[i]) return; if (c) { var j = e ? h[i][f] : h[i]; if (j) { delete j[c]; if (!d.isEmptyObject(j)) return } } if (e) { delete h[i][f]; if (!d.isEmptyObject(h[i])) return } var k = h[i][f]; d.support.deleteExpando || h != a ? delete h[i] : h[i] = null, k ? (h[i] = {}, h[i][f] = k) : g && (d.support.deleteExpando ? delete b[d.expando] : b.removeAttribute ? b.removeAttribute(d.expando) : b[d.expando] = null) } }, _data: function (a, b, c) { return d.data(a, b, c, !0) }, acceptData: function (a) { if (a.nodeName) { var b = d.noData[a.nodeName.toLowerCase()]; if (b) return b !== !0 && a.getAttribute("classid") === b } return !0 } }), d.fn.extend({ data: function (a, c) { var e = null; if (typeof a === "undefined") { if (this.length) { e = d.data(this[0]); if (this[0].nodeType === 1) { var g = this[0].attributes, h; for (var i = 0, j = g.length; i < j; i++) h = g[i].name, h.indexOf("data-") === 0 && (h = h.substr(5), f(this[0], h, e[h])) } } return e } if (typeof a === "object") return this.each(function () { d.data(this, a) }); var k = a.split("."); k[1] = k[1] ? "." + k[1] : ""; if (c === b) { e = this.triggerHandler("getData" + k[1] + "!", [k[0]]), e === b && this.length && (e = d.data(this[0], a), e = f(this[0], a, e)); return e === b && k[1] ? this.data(k[0]) : e } return this.each(function () { var b = d(this), e = [k[0], c]; b.triggerHandler("setData" + k[1] + "!", e), d.data(this, a, c), b.triggerHandler("changeData" + k[1] + "!", e) }) }, removeData: function (a) { return this.each(function () { d.removeData(this, a) }) } }), d.extend({ queue: function (a, b, c) { if (a) { b = (b || "fx") + "queue"; var e = d._data(a, b); if (!c) return e || []; !e || d.isArray(c) ? e = d._data(a, b, d.makeArray(c)) : e.push(c); return e } }, dequeue: function (a, b) { b = b || "fx"; var c = d.queue(a, b), e = c.shift(); e === "inprogress" && (e = c.shift()), e && (b === "fx" && c.unshift("inprogress"), e.call(a, function () { d.dequeue(a, b) })), c.length || d.removeData(a, b + "queue", !0) } }), d.fn.extend({ queue: function (a, c) { typeof a !== "string" && (c = a, a = "fx"); if (c === b) return d.queue(this[0], a); return this.each(function (b) { var e = d.queue(this, a, c); a === "fx" && e[0] !== "inprogress" && d.dequeue(this, a) }) }, dequeue: function (a) { return this.each(function () { d.dequeue(this, a) }) }, delay: function (a, b) { a = d.fx ? d.fx.speeds[a] || a : a, b = b || "fx"; return this.queue(b, function () { var c = this; setTimeout(function () { d.dequeue(c, b) }, a) }) }, clearQueue: function (a) { return this.queue(a || "fx", []) } }); var g = /[\n\t\r]/g, h = /\s+/, i = /\r/g, j = /^(?:href|src|style)$/, k = /^(?:button|input)$/i, l = /^(?:button|input|object|select|textarea)$/i, m = /^a(?:rea)?$/i, n = /^(?:radio|checkbox)$/i; d.props = { "for": "htmlFor", "class": "className", readonly: "readOnly", maxlength: "maxLength", cellspacing: "cellSpacing", rowspan: "rowSpan", colspan: "colSpan", tabindex: "tabIndex", usemap: "useMap", frameborder: "frameBorder" }, d.fn.extend({ attr: function (a, b) { return d.access(this, a, b, !0, d.attr) }, removeAttr: function (a, b) { return this.each(function () { d.attr(this, a, ""), this.nodeType === 1 && this.removeAttribute(a) }) }, addClass: function (a) { if (d.isFunction(a)) return this.each(function (b) { var c = d(this); c.addClass(a.call(this, b, c.attr("class"))) }); if (a && typeof a === "string") { var b = (a || "").split(h); for (var c = 0, e = this.length; c < e; c++) { var f = this[c]; if (f.nodeType === 1) if (f.className) { var g = " " + f.className + " ", i = f.className; for (var j = 0, k = b.length; j < k; j++) g.indexOf(" " + b[j] + " ") < 0 && (i += " " + b[j]); f.className = d.trim(i) } else f.className = a } } return this }, removeClass: function (a) { if (d.isFunction(a)) return this.each(function (b) { var c = d(this); c.removeClass(a.call(this, b, c.attr("class"))) }); if (a && typeof a === "string" || a === b) { var c = (a || "").split(h); for (var e = 0, f = this.length; e < f; e++) { var i = this[e]; if (i.nodeType === 1 && i.className) if (a) { var j = (" " + i.className + " ").replace(g, " "); for (var k = 0, l = c.length; k < l; k++) j = j.replace(" " + c[k] + " ", " "); i.className = d.trim(j) } else i.className = "" } } return this }, toggleClass: function (a, b) { var c = typeof a, e = typeof b === "boolean"; if (d.isFunction(a)) return this.each(function (c) { var e = d(this); e.toggleClass(a.call(this, c, e.attr("class"), b), b) }); return this.each(function () { if (c === "string") { var f, g = 0, i = d(this), j = b, k = a.split(h); while (f = k[g++]) j = e ? j : !i.hasClass(f), i[j ? "addClass" : "removeClass"](f) } else if (c === "undefined" || c === "boolean") this.className && d._data(this, "__className__", this.className), this.className = this.className || a === !1 ? "" : d._data(this, "__className__") || "" }) }, hasClass: function (a) { var b = " " + a + " "; for (var c = 0, d = this.length; c < d; c++) if ((" " + this[c].className + " ").replace(g, " ").indexOf(b) > -1) return !0; return !1 }, val: function (a) { if (!arguments.length) { var c = this[0]; if (c) { if (d.nodeName(c, "option")) { var e = c.attributes.value; return !e || e.specified ? c.value : c.text } if (d.nodeName(c, "select")) { var f = c.selectedIndex, g = [], h = c.options, j = c.type === "select-one"; if (f < 0) return null; for (var k = j ? f : 0, l = j ? f + 1 : h.length; k < l; k++) { var m = h[k]; if (m.selected && (d.support.optDisabled ? !m.disabled : m.getAttribute("disabled") === null) && (!m.parentNode.disabled || !d.nodeName(m.parentNode, "optgroup"))) { a = d(m).val(); if (j) return a; g.push(a) } } return g } if (n.test(c.type) && !d.support.checkOn) return c.getAttribute("value") === null ? "on" : c.value; return (c.value || "").replace(i, "") } return b } var o = d.isFunction(a); return this.each(function (b) { var c = d(this), e = a; if (this.nodeType === 1) { o && (e = a.call(this, b, c.val())), e == null ? e = "" : typeof e === "number" ? e += "" : d.isArray(e) && (e = d.map(e, function (a) { return a == null ? "" : a + "" })); if (d.isArray(e) && n.test(this.type)) this.checked = d.inArray(c.val(), e) >= 0; else if (d.nodeName(this, "select")) { var f = d.makeArray(e); d("option", this).each(function () { this.selected = d.inArray(d(this).val(), f) >= 0 }), f.length || (this.selectedIndex = -1) } else this.value = e } }) } }), d.extend({ attrFn: { val: !0, css: !0, html: !0, text: !0, data: !0, width: !0, height: !0, offset: !0 }, attr: function (a, c, e, f) { if (!a || a.nodeType === 3 || a.nodeType === 8 || a.nodeType === 2) return b; if (f && c in d.attrFn) return d(a)[c](e); var g = a.nodeType !== 1 || !d.isXMLDoc(a), h = e !== b; c = g && d.props[c] || c; if (a.nodeType === 1) { var i = j.test(c); if (c === "selected" && !d.support.optSelected) { var n = a.parentNode; n && (n.selectedIndex, n.parentNode && n.parentNode.selectedIndex) } if ((c in a || a[c] !== b) && g && !i) { h && (c === "type" && k.test(a.nodeName) && a.parentNode && d.error("type property can't be changed"), e === null ? a.nodeType === 1 && a.removeAttribute(c) : a[c] = e); if (d.nodeName(a, "form") && a.getAttributeNode(c)) return a.getAttributeNode(c).nodeValue; if (c === "tabIndex") { var o = a.getAttributeNode("tabIndex"); return o && o.specified ? o.value : l.test(a.nodeName) || m.test(a.nodeName) && a.href ? 0 : b } return a[c] } if (!d.support.style && g && c === "style") { h && (a.style.cssText = "" + e); return a.style.cssText } h && a.setAttribute(c, "" + e); if (!a.attributes[c] && (a.hasAttribute && !a.hasAttribute(c))) return b; var p = !d.support.hrefNormalized && g && i ? a.getAttribute(c, 2) : a.getAttribute(c); return p === null ? b : p } h && (a[c] = e); return a[c] } }); var o = /\.(.*)$/, p = /^(?:textarea|input|select)$/i, q = /\./g, r = / /g, s = /[^\w\s.|`]/g, t = function (a) { return a.replace(s, "\\$&") }, u = "events"; d.event = { add: function (c, e, f, g) { if (c.nodeType !== 3 && c.nodeType !== 8) { d.isWindow(c) && (c !== a && !c.frameElement) && (c = a); if (f === !1) f = v; else if (!f) return; var h, i; f.handler && (h = f, f = h.handler), f.guid || (f.guid = d.guid++); var j = d._data(c); if (!j) return; var k = j[u], l = j.handle; typeof k === "function" ? (l = k.handle, k = k.events) : k || (c.nodeType || (j[u] = j = function () { }), j.events = k = {}), l || (j.handle = l = function () { return typeof d !== "undefined" && !d.event.triggered ? d.event.handle.apply(l.elem, arguments) : b }), l.elem = c, e = e.split(" "); var m, n = 0, o; while (m = e[n++]) { i = h ? d.extend({}, h) : { handler: f, data: g }, m.indexOf(".") > -1 ? (o = m.split("."), m = o.shift(), i.namespace = o.slice(0).sort().join(".")) : (o = [], i.namespace = ""), i.type = m, i.guid || (i.guid = f.guid); var p = k[m], q = d.event.special[m] || {}; if (!p) { p = k[m] = []; if (!q.setup || q.setup.call(c, g, o, l) === !1) c.addEventListener ? c.addEventListener(m, l, !1) : c.attachEvent && c.attachEvent("on" + m, l) } q.add && (q.add.call(c, i), i.handler.guid || (i.handler.guid = f.guid)), p.push(i), d.event.global[m] = !0 } c = null } }, global: {}, remove: function (a, c, e, f) { if (a.nodeType !== 3 && a.nodeType !== 8) { e === !1 && (e = v); var g, h, i, j, k = 0, l, m, n, o, p, q, r, s = d.hasData(a) && d._data(a), w = s && s[u]; if (!s || !w) return; typeof w === "function" && (s = w, w = w.events), c && c.type && (e = c.handler, c = c.type); if (!c || typeof c === "string" && c.charAt(0) === ".") { c = c || ""; for (h in w) d.event.remove(a, h + c); return } c = c.split(" "); while (h = c[k++]) { r = h, q = null, l = h.indexOf(".") < 0, m = [], l || (m = h.split("."), h = m.shift(), n = new RegExp("(^|\\.)" + d.map(m.slice(0).sort(), t).join("\\.(?:.*\\.)?") + "(\\.|$)")), p = w[h]; if (!p) continue; if (!e) { for (j = 0; j < p.length; j++) { q = p[j]; if (l || n.test(q.namespace)) d.event.remove(a, r, q.handler, j), p.splice(j--, 1) } continue } o = d.event.special[h] || {}; for (j = f || 0; j < p.length; j++) { q = p[j]; if (e.guid === q.guid) { if (l || n.test(q.namespace)) f == null && p.splice(j--, 1), o.remove && o.remove.call(a, q); if (f != null) break } } if (p.length === 0 || f != null && p.length === 1) (!o.teardown || o.teardown.call(a, m) === !1) && d.removeEvent(a, h, s.handle), g = null, delete w[h] } if (d.isEmptyObject(w)) { var x = s.handle; x && (x.elem = null), delete s.events, delete s.handle, typeof s === "function" ? d.removeData(a, u, !0) : d.isEmptyObject(s) && d.removeData(a, b, !0) } } }, trigger: function (a, c, e) { var f = a.type || a, g = arguments[3]; if (!g) { a = typeof a === "object" ? a[d.expando] ? a : d.extend(d.Event(f), a) : d.Event(f), f.indexOf("!") >= 0 && (a.type = f = f.slice(0, -1), a.exclusive = !0), e || (a.stopPropagation(), d.event.global[f] && d.each(d.cache, function () { var b = d.expando, e = this[b]; e && e.events && e.events[f] && d.event.trigger(a, c, e.handle.elem) })); if (!e || e.nodeType === 3 || e.nodeType === 8) return b; a.result = b, a.target = e, c = d.makeArray(c), c.unshift(a) } a.currentTarget = e; var h = e.nodeType ? d._data(e, "handle") : (d._data(e, u) || {}).handle; h && h.apply(e, c); var i = e.parentNode || e.ownerDocument; try { e && e.nodeName && d.noData[e.nodeName.toLowerCase()] || e["on" + f] && e["on" + f].apply(e, c) === !1 && (a.result = !1, a.preventDefault()) } catch (j) { } if (!a.isPropagationStopped() && i) d.event.trigger(a, c, i, !0); else if (!a.isDefaultPrevented()) { var k, l = a.target, m = f.replace(o, ""), n = d.nodeName(l, "a") && m === "click", p = d.event.special[m] || {}; if ((!p._default || p._default.call(e, a) === !1) && !n && !(l && l.nodeName && d.noData[l.nodeName.toLowerCase()])) { try { l[m] && (k = l["on" + m], k && (l["on" + m] = null), d.event.triggered = !0, l[m]()) } catch (q) { } k && (l["on" + m] = k), d.event.triggered = !1 } } }, handle: function (c) { var e, f, g, h, i, j = [], k = d.makeArray(arguments); c = k[0] = d.event.fix(c || a.event), c.currentTarget = this, e = c.type.indexOf(".") < 0 && !c.exclusive, e || (g = c.type.split("."), c.type = g.shift(), j = g.slice(0).sort(), h = new RegExp("(^|\\.)" + j.join("\\.(?:.*\\.)?") + "(\\.|$)")), c.namespace = c.namespace || j.join("."), i = d._data(this, u), typeof i === "function" && (i = i.events), f = (i || {})[c.type]; if (i && f) { f = f.slice(0); for (var l = 0, m = f.length; l < m; l++) { var n = f[l]; if (e || h.test(n.namespace)) { c.handler = n.handler, c.data = n.data, c.handleObj = n; var o = n.handler.apply(this, k); o !== b && (c.result = o, o === !1 && (c.preventDefault(), c.stopPropagation())); if (c.isImmediatePropagationStopped()) break } } } return c.result }, props: "altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode layerX layerY metaKey newValue offsetX offsetY pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target toElement view wheelDelta which".split(" "), fix: function (a) { if (a[d.expando]) return a; var e = a; a = d.Event(e); for (var f = this.props.length, g; f; ) g = this.props[--f], a[g] = e[g]; a.target || (a.target = a.srcElement || c), a.target.nodeType === 3 && (a.target = a.target.parentNode), !a.relatedTarget && a.fromElement && (a.relatedTarget = a.fromElement === a.target ? a.toElement : a.fromElement); if (a.pageX == null && a.clientX != null) { var h = c.documentElement, i = c.body; a.pageX = a.clientX + (h && h.scrollLeft || i && i.scrollLeft || 0) - (h && h.clientLeft || i && i.clientLeft || 0), a.pageY = a.clientY + (h && h.scrollTop || i && i.scrollTop || 0) - (h && h.clientTop || i && i.clientTop || 0) } a.which == null && (a.charCode != null || a.keyCode != null) && (a.which = a.charCode != null ? a.charCode : a.keyCode), !a.metaKey && a.ctrlKey && (a.metaKey = a.ctrlKey), !a.which && a.button !== b && (a.which = a.button & 1 ? 1 : a.button & 2 ? 3 : a.button & 4 ? 2 : 0); return a }, guid: 1e8, proxy: d.proxy, special: { ready: { setup: d.bindReady, teardown: d.noop }, live: { add: function (a) { d.event.add(this, F(a.origType, a.selector), d.extend({}, a, { handler: E, guid: a.handler.guid })) }, remove: function (a) { d.event.remove(this, F(a.origType, a.selector), a) } }, beforeunload: { setup: function (a, b, c) { d.isWindow(this) && (this.onbeforeunload = c) }, teardown: function (a, b) { this.onbeforeunload === b && (this.onbeforeunload = null) } }} }, d.removeEvent = c.removeEventListener ? function (a, b, c) { a.removeEventListener && a.removeEventListener(b, c, !1) } : function (a, b, c) { a.detachEvent && a.detachEvent("on" + b, c) }, d.Event = function (a) { if (!this.preventDefault) return new d.Event(a); a && a.type ? (this.originalEvent = a, this.type = a.type, this.isDefaultPrevented = a.defaultPrevented || a.returnValue === !1 || a.getPreventDefault && a.getPreventDefault() ? w : v) : this.type = a, this.timeStamp = d.now(), this[d.expando] = !0 }, d.Event.prototype = { preventDefault: function () { this.isDefaultPrevented = w; var a = this.originalEvent; a && (a.preventDefault ? a.preventDefault() : a.returnValue = !1) }, stopPropagation: function () { this.isPropagationStopped = w; var a = this.originalEvent; a && (a.stopPropagation && a.stopPropagation(), a.cancelBubble = !0) }, stopImmediatePropagation: function () { this.isImmediatePropagationStopped = w, this.stopPropagation() }, isDefaultPrevented: v, isPropagationStopped: v, isImmediatePropagationStopped: v }; var x = function (a) { var b = a.relatedTarget; try { while (b && b !== this) b = b.parentNode; b !== this && (a.type = a.data, d.event.handle.apply(this, arguments)) } catch (c) { } }, y = function (a) { a.type = a.data, d.event.handle.apply(this, arguments) }; d.each({ mouseenter: "mouseover", mouseleave: "mouseout" }, function (a, b) { d.event.special[a] = { setup: function (c) { d.event.add(this, b, c && c.selector ? y : x, a) }, teardown: function (a) { d.event.remove(this, b, a && a.selector ? y : x) } } }), d.support.submitBubbles || (d.event.special.submit = { setup: function (a, c) { if (this.nodeName && this.nodeName.toLowerCase() !== "form") d.event.add(this, "click.specialSubmit", function (a) { var c = a.target, e = c.type; if ((e === "submit" || e === "image") && d(c).closest("form").length) { a.liveFired = b; return C("submit", this, arguments) } }), d.event.add(this, "keypress.specialSubmit", function (a) { var c = a.target, e = c.type; if ((e === "text" || e === "password") && d(c).closest("form").length && a.keyCode === 13) { a.liveFired = b; return C("submit", this, arguments) } }); else return !1 }, teardown: function (a) { d.event.remove(this, ".specialSubmit") } }); if (!d.support.changeBubbles) { var z, A = function (a) { var b = a.type, c = a.value; b === "radio" || b === "checkbox" ? c = a.checked : b === "select-multiple" ? c = a.selectedIndex > -1 ? d.map(a.options, function (a) { return a.selected }).join("-") : "" : a.nodeName.toLowerCase() === "select" && (c = a.selectedIndex); return c }, B = function B(a) { var c = a.target, e, f; if (p.test(c.nodeName) && !c.readOnly) { e = d._data(c, "_change_data"), f = A(c), (a.type !== "focusout" || c.type !== "radio") && d._data(c, "_change_data", f); if (e === b || f === e) return; if (e != null || f) { a.type = "change", a.liveFired = b; return d.event.trigger(a, arguments[1], c) } } }; d.event.special.change = { filters: { focusout: B, beforedeactivate: B, click: function (a) { var b = a.target, c = b.type; if (c === "radio" || c === "checkbox" || b.nodeName.toLowerCase() === "select") return B.call(this, a) }, keydown: function (a) { var b = a.target, c = b.type; if (a.keyCode === 13 && b.nodeName.toLowerCase() !== "textarea" || a.keyCode === 32 && (c === "checkbox" || c === "radio") || c === "select-multiple") return B.call(this, a) }, beforeactivate: function (a) { var b = a.target; d._data(b, "_change_data", A(b)) } }, setup: function (a, b) { if (this.type === "file") return !1; for (var c in z) d.event.add(this, c + ".specialChange", z[c]); return p.test(this.nodeName) }, teardown: function (a) { d.event.remove(this, ".specialChange"); return p.test(this.nodeName) } }, z = d.event.special.change.filters, z.focus = z.beforeactivate } c.addEventListener && d.each({ focus: "focusin", blur: "focusout" }, function (a, b) { function c(a) { a = d.event.fix(a), a.type = b; return d.event.handle.call(this, a) } d.event.special[b] = { setup: function () { this.addEventListener(a, c, !0) }, teardown: function () { this.removeEventListener(a, c, !0) } } }), d.each(["bind", "one"], function (a, c) { d.fn[c] = function (a, e, f) { if (typeof a === "object") { for (var g in a) this[c](g, e, a[g], f); return this } if (d.isFunction(e) || e === !1) f = e, e = b; var h = c === "one" ? d.proxy(f, function (a) { d(this).unbind(a, h); return f.apply(this, arguments) }) : f; if (a === "unload" && c !== "one") this.one(a, e, f); else for (var i = 0, j = this.length; i < j; i++) d.event.add(this[i], a, h, e); return this } }), d.fn.extend({ unbind: function (a, b) { if (typeof a !== "object" || a.preventDefault) for (var e = 0, f = this.length; e < f; e++) d.event.remove(this[e], a, b); else for (var c in a) this.unbind(c, a[c]); return this }, delegate: function (a, b, c, d) { return this.live(b, c, d, a) }, undelegate: function (a, b, c) { return arguments.length === 0 ? this.unbind("live") : this.die(b, null, c, a) }, trigger: function (a, b) { return this.each(function () { d.event.trigger(a, b, this) }) }, triggerHandler: function (a, b) { if (this[0]) { var c = d.Event(a); c.preventDefault(), c.stopPropagation(), d.event.trigger(c, b, this[0]); return c.result } }, toggle: function (a) { var b = arguments, c = 1; while (c < b.length) d.proxy(a, b[c++]); return this.click(d.proxy(a, function (e) { var f = (d._data(this, "lastToggle" + a.guid) || 0) % c; d._data(this, "lastToggle" + a.guid, f + 1), e.preventDefault(); return b[f].apply(this, arguments) || !1 })) }, hover: function (a, b) { return this.mouseenter(a).mouseleave(b || a) } }); var D = { focus: "focusin", blur: "focusout", mouseenter: "mouseover", mouseleave: "mouseout" }; d.each(["live", "die"], function (a, c) { d.fn[c] = function (a, e, f, g) { var h, i = 0, j, k, l, m = g || this.selector, n = g ? this : d(this.context); if (typeof a === "object" && !a.preventDefault) { for (var p in a) n[c](p, e, a[p], m); return this } d.isFunction(e) && (f = e, e = b), a = (a || "").split(" "); while ((h = a[i++]) != null) { j = o.exec(h), k = "", j && (k = j[0], h = h.replace(o, "")); if (h === "hover") { a.push("mouseenter" + k, "mouseleave" + k); continue } l = h, h === "focus" || h === "blur" ? (a.push(D[h] + k), h = h + k) : h = (D[h] || h) + k; if (c === "live") for (var q = 0, r = n.length; q < r; q++) d.event.add(n[q], "live." + F(h, m), { data: e, selector: m, handler: f, origType: h, origHandler: f, preType: l }); else n.unbind("live." + F(h, m), f) } return this } }), d.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error".split(" "), function (a, b) { d.fn[b] = function (a, c) { c == null && (c = a, a = null); return arguments.length > 0 ? this.bind(b, a, c) : this.trigger(b) }, d.attrFn && (d.attrFn[b] = !0) }), function () { function s(a, b, c, d, e, f) { for (var g = 0, h = d.length; g < h; g++) { var j = d[g]; if (j) { var k = !1; j = j[a]; while (j) { if (j.sizcache === c) { k = d[j.sizset]; break } if (j.nodeType === 1) { f || (j.sizcache = c, j.sizset = g); if (typeof b !== "string") { if (j === b) { k = !0; break } } else if (i.filter(b, [j]).length > 0) { k = j; break } } j = j[a] } d[g] = k } } } function r(a, b, c, d, e, f) { for (var g = 0, h = d.length; g < h; g++) { var i = d[g]; if (i) { var j = !1; i = i[a]; while (i) { if (i.sizcache === c) { j = d[i.sizset]; break } i.nodeType === 1 && !f && (i.sizcache = c, i.sizset = g); if (i.nodeName.toLowerCase() === b) { j = i; break } i = i[a] } d[g] = j } } } var a = /((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^\[\]]*\]|['"][^'"]*['"]|[^\[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?((?:.|\r|\n)*)/g, e = 0, f = Object.prototype.toString, g = !1, h = !0; [0, 0].sort(function () { h = !1; return 0 }); var i = function (b, d, e, g) { e = e || [], d = d || c; var h = d; if (d.nodeType !== 1 && d.nodeType !== 9) return []; if (!b || typeof b !== "string") return e; var l, m, o, p, q, r, s, u, v = !0, w = i.isXML(d), x = [], y = b; do { a.exec(""), l = a.exec(y); if (l) { y = l[3], x.push(l[1]); if (l[2]) { p = l[3]; break } } } while (l); if (x.length > 1 && k.exec(b)) if (x.length === 2 && j.relative[x[0]]) m = t(x[0] + x[1], d); else { m = j.relative[x[0]] ? [d] : i(x.shift(), d); while (x.length) b = x.shift(), j.relative[b] && (b += x.shift()), m = t(b, m) } else { !g && x.length > 1 && d.nodeType === 9 && !w && j.match.ID.test(x[0]) && !j.match.ID.test(x[x.length - 1]) && (q = i.find(x.shift(), d, w), d = q.expr ? i.filter(q.expr, q.set)[0] : q.set[0]); if (d) { q = g ? { expr: x.pop(), set: n(g)} : i.find(x.pop(), x.length === 1 && (x[0] === "~" || x[0] === "+") && d.parentNode ? d.parentNode : d, w), m = q.expr ? i.filter(q.expr, q.set) : q.set, x.length > 0 ? o = n(m) : v = !1; while (x.length) r = x.pop(), s = r, j.relative[r] ? s = x.pop() : r = "", s == null && (s = d), j.relative[r](o, s, w) } else o = x = [] } o || (o = m), o || i.error(r || b); if (f.call(o) === "[object Array]") if (v) if (d && d.nodeType === 1) for (u = 0; o[u] != null; u++) o[u] && (o[u] === !0 || o[u].nodeType === 1 && i.contains(d, o[u])) && e.push(m[u]); else for (u = 0; o[u] != null; u++) o[u] && o[u].nodeType === 1 && e.push(m[u]); else e.push.apply(e, o); else n(o, e); p && (i(p, h, e, g), i.uniqueSort(e)); return e }; i.uniqueSort = function (a) { if (p) { g = h, a.sort(p); if (g) for (var b = 1; b < a.length; b++) a[b] === a[b - 1] && a.splice(b--, 1) } return a }, i.matches = function (a, b) { return i(a, null, null, b) }, i.matchesSelector = function (a, b) { return i(b, null, null, [a]).length > 0 }, i.find = function (a, b, c) { var d; if (!a) return []; for (var e = 0, f = j.order.length; e < f; e++) { var g, h = j.order[e]; if (g = j.leftMatch[h].exec(a)) { var i = g[1]; g.splice(1, 1); if (i.substr(i.length - 1) !== "\\") { g[1] = (g[1] || "").replace(/\\/g, ""), d = j.find[h](g, b, c); if (d != null) { a = a.replace(j.match[h], ""); break } } } } d || (d = typeof b.getElementsByTagName !== "undefined" ? b.getElementsByTagName("*") : []); return { set: d, expr: a} }, i.filter = function (a, c, d, e) { var f, g, h = a, k = [], l = c, m = c && c[0] && i.isXML(c[0]); while (a && c.length) { for (var n in j.filter) if ((f = j.leftMatch[n].exec(a)) != null && f[2]) { var o, p, q = j.filter[n], r = f[1]; g = !1, f.splice(1, 1); if (r.substr(r.length - 1) === "\\") continue; l === k && (k = []); if (j.preFilter[n]) { f = j.preFilter[n](f, l, d, k, e, m); if (f) { if (f === !0) continue } else g = o = !0 } if (f) for (var s = 0; (p = l[s]) != null; s++) if (p) { o = q(p, f, s, l); var t = e ^ !!o; d && o != null ? t ? g = !0 : l[s] = !1 : t && (k.push(p), g = !0) } if (o !== b) { d || (l = k), a = a.replace(j.match[n], ""); if (!g) return []; break } } if (a === h) if (g == null) i.error(a); else break; h = a } return l }, i.error = function (a) { throw "Syntax error, unrecognized expression: " + a }; var j = i.selectors = { order: ["ID", "NAME", "TAG"], match: { ID: /#((?:[\w\u00c0-\uFFFF\-]|\\.)+)/, CLASS: /\.((?:[\w\u00c0-\uFFFF\-]|\\.)+)/, NAME: /\[name=['"]*((?:[\w\u00c0-\uFFFF\-]|\\.)+)['"]*\]/, ATTR: /\[\s*((?:[\w\u00c0-\uFFFF\-]|\\.)+)\s*(?:(\S?=)\s*(?:(['"])(.*?)\3|(#?(?:[\w\u00c0-\uFFFF\-]|\\.)*)|)|)\s*\]/, TAG: /^((?:[\w\u00c0-\uFFFF\*\-]|\\.)+)/, CHILD: /:(only|nth|last|first)-child(?:\(\s*(even|odd|(?:[+\-]?\d+|(?:[+\-]?\d*)?n\s*(?:[+\-]\s*\d+)?))\s*\))?/, POS: /:(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^\-]|$)/, PSEUDO: /:((?:[\w\u00c0-\uFFFF\-]|\\.)+)(?:\((['"]?)((?:\([^\)]+\)|[^\(\)]*)+)\2\))?/ }, leftMatch: {}, attrMap: { "class": "className", "for": "htmlFor" }, attrHandle: { href: function (a) { return a.getAttribute("href") } }, relative: { "+": function (a, b) { var c = typeof b === "string", d = c && !/\W/.test(b), e = c && !d; d && (b = b.toLowerCase()); for (var f = 0, g = a.length, h; f < g; f++) if (h = a[f]) { while ((h = h.previousSibling) && h.nodeType !== 1) { } a[f] = e || h && h.nodeName.toLowerCase() === b ? h || !1 : h === b } e && i.filter(b, a, !0) }, ">": function (a, b) { var c, d = typeof b === "string", e = 0, f = a.length; if (d && !/\W/.test(b)) { b = b.toLowerCase(); for (; e < f; e++) { c = a[e]; if (c) { var g = c.parentNode; a[e] = g.nodeName.toLowerCase() === b ? g : !1 } } } else { for (; e < f; e++) c = a[e], c && (a[e] = d ? c.parentNode : c.parentNode === b); d && i.filter(b, a, !0) } }, "": function (a, b, c) { var d, f = e++, g = s; typeof b === "string" && !/\W/.test(b) && (b = b.toLowerCase(), d = b, g = r), g("parentNode", b, f, a, d, c) }, "~": function (a, b, c) { var d, f = e++, g = s; typeof b === "string" && !/\W/.test(b) && (b = b.toLowerCase(), d = b, g = r), g("previousSibling", b, f, a, d, c) } }, find: { ID: function (a, b, c) { if (typeof b.getElementById !== "undefined" && !c) { var d = b.getElementById(a[1]); return d && d.parentNode ? [d] : [] } }, NAME: function (a, b) { if (typeof b.getElementsByName !== "undefined") { var c = [], d = b.getElementsByName(a[1]); for (var e = 0, f = d.length; e < f; e++) d[e].getAttribute("name") === a[1] && c.push(d[e]); return c.length === 0 ? null : c } }, TAG: function (a, b) { if (typeof b.getElementsByTagName !== "undefined") return b.getElementsByTagName(a[1]) } }, preFilter: { CLASS: function (a, b, c, d, e, f) { a = " " + a[1].replace(/\\/g, "") + " "; if (f) return a; for (var g = 0, h; (h = b[g]) != null; g++) h && (e ^ (h.className && (" " + h.className + " ").replace(/[\t\n\r]/g, " ").indexOf(a) >= 0) ? c || d.push(h) : c && (b[g] = !1)); return !1 }, ID: function (a) { return a[1].replace(/\\/g, "") }, TAG: function (a, b) { return a[1].toLowerCase() }, CHILD: function (a) { if (a[1] === "nth") { a[2] || i.error(a[0]), a[2] = a[2].replace(/^\+|\s*/g, ""); var b = /(-?)(\d*)(?:n([+\-]?\d*))?/.exec(a[2] === "even" && "2n" || a[2] === "odd" && "2n+1" || !/\D/.test(a[2]) && "0n+" + a[2] || a[2]); a[2] = b[1] + (b[2] || 1) - 0, a[3] = b[3] - 0 } else a[2] && i.error(a[0]); a[0] = e++; return a }, ATTR: function (a, b, c, d, e, f) { var g = a[1] = a[1].replace(/\\/g, ""); !f && j.attrMap[g] && (a[1] = j.attrMap[g]), a[4] = (a[4] || a[5] || "").replace(/\\/g, ""), a[2] === "~=" && (a[4] = " " + a[4] + " "); return a }, PSEUDO: function (b, c, d, e, f) { if (b[1] === "not") if ((a.exec(b[3]) || "").length > 1 || /^\w/.test(b[3])) b[3] = i(b[3], null, null, c); else { var g = i.filter(b[3], c, d, !0 ^ f); d || e.push.apply(e, g); return !1 } else if (j.match.POS.test(b[0]) || j.match.CHILD.test(b[0])) return !0; return b }, POS: function (a) { a.unshift(!0); return a } }, filters: { enabled: function (a) { return a.disabled === !1 && a.type !== "hidden" }, disabled: function (a) { return a.disabled === !0 }, checked: function (a) { return a.checked === !0 }, selected: function (a) { a.parentNode.selectedIndex; return a.selected === !0 }, parent: function (a) { return !!a.firstChild }, empty: function (a) { return !a.firstChild }, has: function (a, b, c) { return !!i(c[3], a).length }, header: function (a) { return /h\d/i.test(a.nodeName) }, text: function (a) { return "text" === a.type }, radio: function (a) { return "radio" === a.type }, checkbox: function (a) { return "checkbox" === a.type }, file: function (a) { return "file" === a.type }, password: function (a) { return "password" === a.type }, submit: function (a) { return "submit" === a.type }, image: function (a) { return "image" === a.type }, reset: function (a) { return "reset" === a.type }, button: function (a) { return "button" === a.type || a.nodeName.toLowerCase() === "button" }, input: function (a) { return /input|select|textarea|button/i.test(a.nodeName) } }, setFilters: { first: function (a, b) { return b === 0 }, last: function (a, b, c, d) { return b === d.length - 1 }, even: function (a, b) { return b % 2 === 0 }, odd: function (a, b) { return b % 2 === 1 }, lt: function (a, b, c) { return b < c[3] - 0 }, gt: function (a, b, c) { return b > c[3] - 0 }, nth: function (a, b, c) { return c[3] - 0 === b }, eq: function (a, b, c) { return c[3] - 0 === b } }, filter: { PSEUDO: function (a, b, c, d) { var e = b[1], f = j.filters[e]; if (f) return f(a, c, b, d); if (e === "contains") return (a.textContent || a.innerText || i.getText([a]) || "").indexOf(b[3]) >= 0; if (e === "not") { var g = b[3]; for (var h = 0, k = g.length; h < k; h++) if (g[h] === a) return !1; return !0 } i.error(e) }, CHILD: function (a, b) { var c = b[1], d = a; switch (c) { case "only": case "first": while (d = d.previousSibling) if (d.nodeType === 1) return !1; if (c === "first") return !0; d = a; case "last": while (d = d.nextSibling) if (d.nodeType === 1) return !1; return !0; case "nth": var e = b[2], f = b[3]; if (e === 1 && f === 0) return !0; var g = b[0], h = a.parentNode; if (h && (h.sizcache !== g || !a.nodeIndex)) { var i = 0; for (d = h.firstChild; d; d = d.nextSibling) d.nodeType === 1 && (d.nodeIndex = ++i); h.sizcache = g } var j = a.nodeIndex - f; return e === 0 ? j === 0 : j % e === 0 && j / e >= 0 } }, ID: function (a, b) { return a.nodeType === 1 && a.getAttribute("id") === b }, TAG: function (a, b) { return b === "*" && a.nodeType === 1 || a.nodeName.toLowerCase() === b }, CLASS: function (a, b) { return (" " + (a.className || a.getAttribute("class")) + " ").indexOf(b) > -1 }, ATTR: function (a, b) { var c = b[1], d = j.attrHandle[c] ? j.attrHandle[c](a) : a[c] != null ? a[c] : a.getAttribute(c), e = d + "", f = b[2], g = b[4]; return d == null ? f === "!=" : f === "=" ? e === g : f === "*=" ? e.indexOf(g) >= 0 : f === "~=" ? (" " + e + " ").indexOf(g) >= 0 : g ? f === "!=" ? e !== g : f === "^=" ? e.indexOf(g) === 0 : f === "$=" ? e.substr(e.length - g.length) === g : f === "|=" ? e === g || e.substr(0, g.length + 1) === g + "-" : !1 : e && d !== !1 }, POS: function (a, b, c, d) { var e = b[2], f = j.setFilters[e]; if (f) return f(a, c, b, d) } } }, k = j.match.POS, l = function (a, b) { return "\\" + (b - 0 + 1) }; for (var m in j.match) j.match[m] = new RegExp(j.match[m].source + /(?![^\[]*\])(?![^\(]*\))/.source), j.leftMatch[m] = new RegExp(/(^(?:.|\r|\n)*?)/.source + j.match[m].source.replace(/\\(\d+)/g, l)); var n = function (a, b) { a = Array.prototype.slice.call(a, 0); if (b) { b.push.apply(b, a); return b } return a }; try { Array.prototype.slice.call(c.documentElement.childNodes, 0)[0].nodeType } catch (o) { n = function (a, b) { var c = 0, d = b || []; if (f.call(a) === "[object Array]") Array.prototype.push.apply(d, a); else if (typeof a.length === "number") for (var e = a.length; c < e; c++) d.push(a[c]); else for (; a[c]; c++) d.push(a[c]); return d } } var p, q; c.documentElement.compareDocumentPosition ? p = function (a, b) { if (a === b) { g = !0; return 0 } if (!a.compareDocumentPosition || !b.compareDocumentPosition) return a.compareDocumentPosition ? -1 : 1; return a.compareDocumentPosition(b) & 4 ? -1 : 1 } : (p = function (a, b) { var c, d, e = [], f = [], h = a.parentNode, i = b.parentNode, j = h; if (a === b) { g = !0; return 0 } if (h === i) return q(a, b); if (!h) return -1; if (!i) return 1; while (j) e.unshift(j), j = j.parentNode; j = i; while (j) f.unshift(j), j = j.parentNode; c = e.length, d = f.length; for (var k = 0; k < c && k < d; k++) if (e[k] !== f[k]) return q(e[k], f[k]); return k === c ? q(a, f[k], -1) : q(e[k], b, 1) }, q = function (a, b, c) { if (a === b) return c; var d = a.nextSibling; while (d) { if (d === b) return -1; d = d.nextSibling } return 1 }), i.getText = function (a) { var b = "", c; for (var d = 0; a[d]; d++) c = a[d], c.nodeType === 3 || c.nodeType === 4 ? b += c.nodeValue : c.nodeType !== 8 && (b += i.getText(c.childNodes)); return b }, function () { var a = c.createElement("div"), d = "script" + (new Date).getTime(), e = c.documentElement; a.innerHTML = "<a name='" + d + "'/>", e.insertBefore(a, e.firstChild), c.getElementById(d) && (j.find.ID = function (a, c, d) { if (typeof c.getElementById !== "undefined" && !d) { var e = c.getElementById(a[1]); return e ? e.id === a[1] || typeof e.getAttributeNode !== "undefined" && e.getAttributeNode("id").nodeValue === a[1] ? [e] : b : [] } }, j.filter.ID = function (a, b) { var c = typeof a.getAttributeNode !== "undefined" && a.getAttributeNode("id"); return a.nodeType === 1 && c && c.nodeValue === b }), e.removeChild(a), e = a = null } (), function () { var a = c.createElement("div"); a.appendChild(c.createComment("")), a.getElementsByTagName("*").length > 0 && (j.find.TAG = function (a, b) { var c = b.getElementsByTagName(a[1]); if (a[1] === "*") { var d = []; for (var e = 0; c[e]; e++) c[e].nodeType === 1 && d.push(c[e]); c = d } return c }), a.innerHTML = "<a href='#'></a>", a.firstChild && typeof a.firstChild.getAttribute !== "undefined" && a.firstChild.getAttribute("href") !== "#" && (j.attrHandle.href = function (a) { return a.getAttribute("href", 2) }), a = null } (), c.querySelectorAll && function () { var a = i, b = c.createElement("div"), d = "__sizzle__"; b.innerHTML = "<p class='TEST'></p>"; if (!b.querySelectorAll || b.querySelectorAll(".TEST").length !== 0) { i = function (b, e, f, g) { e = e || c; if (!g && !i.isXML(e)) { var h = /^(\w+$)|^\.([\w\-]+$)|^#([\w\-]+$)/.exec(b); if (h && (e.nodeType === 1 || e.nodeType === 9)) { if (h[1]) return n(e.getElementsByTagName(b), f); if (h[2] && j.find.CLASS && e.getElementsByClassName) return n(e.getElementsByClassName(h[2]), f) } if (e.nodeType === 9) { if (b === "body" && e.body) return n([e.body], f); if (h && h[3]) { var k = e.getElementById(h[3]); if (!k || !k.parentNode) return n([], f); if (k.id === h[3]) return n([k], f) } try { return n(e.querySelectorAll(b), f) } catch (l) { } } else if (e.nodeType === 1 && e.nodeName.toLowerCase() !== "object") { var m = e.getAttribute("id"), o = m || d, p = e.parentNode, q = /^\s*[+~]/.test(b); m ? o = o.replace(/'/g, "\\$&") : e.setAttribute("id", o), q && p && (e = e.parentNode); try { if (!q || p) return n(e.querySelectorAll("[id='" + o + "'] " + b), f) } catch (r) { } finally { m || e.removeAttribute("id") } } } return a(b, e, f, g) }; for (var e in a) i[e] = a[e]; b = null } } (), function () { var a = c.documentElement, b = a.matchesSelector || a.mozMatchesSelector || a.webkitMatchesSelector || a.msMatchesSelector, d = !1; try { b.call(c.documentElement, "[test!='']:sizzle") } catch (e) { d = !0 } b && (i.matchesSelector = function (a, c) { c = c.replace(/\=\s*([^'"\]]*)\s*\]/g, "='$1']"); if (!i.isXML(a)) try { if (d || !j.match.PSEUDO.test(c) && !/!=/.test(c)) return b.call(a, c) } catch (e) { } return i(c, null, null, [a]).length > 0 }) } (), function () { var a = c.createElement("div"); a.innerHTML = "<div class='test e'></div><div class='test'></div>"; if (a.getElementsByClassName && a.getElementsByClassName("e").length !== 0) { a.lastChild.className = "e"; if (a.getElementsByClassName("e").length === 1) return; j.order.splice(1, 0, "CLASS"), j.find.CLASS = function (a, b, c) { if (typeof b.getElementsByClassName !== "undefined" && !c) return b.getElementsByClassName(a[1]) }, a = null } } (), c.documentElement.contains ? i.contains = function (a, b) { return a !== b && (a.contains ? a.contains(b) : !0) } : c.documentElement.compareDocumentPosition ? i.contains = function (a, b) { return !!(a.compareDocumentPosition(b) & 16) } : i.contains = function () { return !1 }, i.isXML = function (a) { var b = (a ? a.ownerDocument || a : 0).documentElement; return b ? b.nodeName !== "HTML" : !1 }; var t = function (a, b) { var c, d = [], e = "", f = b.nodeType ? [b] : b; while (c = j.match.PSEUDO.exec(a)) e += c[0], a = a.replace(j.match.PSEUDO, ""); a = j.relative[a] ? a + "*" : a; for (var g = 0, h = f.length; g < h; g++) i(a, f[g], d); return i.filter(e, d) }; d.find = i, d.expr = i.selectors, d.expr[":"] = d.expr.filters, d.unique = i.uniqueSort, d.text = i.getText, d.isXMLDoc = i.isXML, d.contains = i.contains } (); var G = /Until$/, H = /^(?:parents|prevUntil|prevAll)/, I = /,/, J = /^.[^:#\[\.,]*$/, K = Array.prototype.slice, L = d.expr.match.POS, M = { children: !0, contents: !0, next: !0, prev: !0 }; d.fn.extend({ find: function (a) { var b = this.pushStack("", "find", a), c = 0; for (var e = 0, f = this.length; e < f; e++) { c = b.length, d.find(a, this[e], b); if (e > 0) for (var g = c; g < b.length; g++) for (var h = 0; h < c; h++) if (b[h] === b[g]) { b.splice(g--, 1); break } } return b }, has: function (a) { var b = d(a); return this.filter(function () { for (var a = 0, c = b.length; a < c; a++) if (d.contains(this, b[a])) return !0 }) }, not: function (a) { return this.pushStack(O(this, a, !1), "not", a) }, filter: function (a) { return this.pushStack(O(this, a, !0), "filter", a) }, is: function (a) { return !!a && d.filter(a, this).length > 0 }, closest: function (a, b) { var c = [], e, f, g = this[0]; if (d.isArray(a)) { var h, i, j = {}, k = 1; if (g && a.length) { for (e = 0, f = a.length; e < f; e++) i = a[e], j[i] || (j[i] = d.expr.match.POS.test(i) ? d(i, b || this.context) : i); while (g && g.ownerDocument && g !== b) { for (i in j) h = j[i], (h.jquery ? h.index(g) > -1 : d(g).is(h)) && c.push({ selector: i, elem: g, level: k }); g = g.parentNode, k++ } } return c } var l = L.test(a) ? d(a, b || this.context) : null; for (e = 0, f = this.length; e < f; e++) { g = this[e]; while (g) { if (l ? l.index(g) > -1 : d.find.matchesSelector(g, a)) { c.push(g); break } g = g.parentNode; if (!g || !g.ownerDocument || g === b) break } } c = c.length > 1 ? d.unique(c) : c; return this.pushStack(c, "closest", a) }, index: function (a) { if (!a || typeof a === "string") return d.inArray(this[0], a ? d(a) : this.parent().children()); return d.inArray(a.jquery ? a[0] : a, this) }, add: function (a, b) { var c = typeof a === "string" ? d(a, b) : d.makeArray(a), e = d.merge(this.get(), c); return this.pushStack(N(c[0]) || N(e[0]) ? e : d.unique(e)) }, andSelf: function () { return this.add(this.prevObject) } }), d.each({ parent: function (a) { var b = a.parentNode; return b && b.nodeType !== 11 ? b : null }, parents: function (a) { return d.dir(a, "parentNode") }, parentsUntil: function (a, b, c) { return d.dir(a, "parentNode", c) }, next: function (a) { return d.nth(a, 2, "nextSibling") }, prev: function (a) { return d.nth(a, 2, "previousSibling") }, nextAll: function (a) { return d.dir(a, "nextSibling") }, prevAll: function (a) { return d.dir(a, "previousSibling") }, nextUntil: function (a, b, c) { return d.dir(a, "nextSibling", c) }, prevUntil: function (a, b, c) { return d.dir(a, "previousSibling", c) }, siblings: function (a) { return d.sibling(a.parentNode.firstChild, a) }, children: function (a) { return d.sibling(a.firstChild) }, contents: function (a) { return d.nodeName(a, "iframe") ? a.contentDocument || a.contentWindow.document : d.makeArray(a.childNodes) } }, function (a, b) { d.fn[a] = function (c, e) { var f = d.map(this, b, c), g = K.call(arguments); G.test(a) || (e = c), e && typeof e === "string" && (f = d.filter(e, f)), f = this.length > 1 && !M[a] ? d.unique(f) : f, (this.length > 1 || I.test(e)) && H.test(a) && (f = f.reverse()); return this.pushStack(f, a, g.join(",")) } }), d.extend({ filter: function (a, b, c) { c && (a = ":not(" + a + ")"); return b.length === 1 ? d.find.matchesSelector(b[0], a) ? [b[0]] : [] : d.find.matches(a, b) }, dir: function (a, c, e) { var f = [], g = a[c]; while (g && g.nodeType !== 9 && (e === b || g.nodeType !== 1 || !d(g).is(e))) g.nodeType === 1 && f.push(g), g = g[c]; return f }, nth: function (a, b, c, d) { b = b || 1; var e = 0; for (; a; a = a[c]) if (a.nodeType === 1 && ++e === b) break; return a }, sibling: function (a, b) { var c = []; for (; a; a = a.nextSibling) a.nodeType === 1 && a !== b && c.push(a); return c } }); var P = / jQuery\d+="(?:\d+|null)"/g, Q = /^\s+/, R = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/ig, S = /<([\w:]+)/, T = /<tbody/i, U = /<|&#?\w+;/, V = /<(?:script|object|embed|option|style)/i, W = /checked\s*(?:[^=]|=\s*.checked.)/i, X = { option: [1, "<select multiple='multiple'>", "</select>"], legend: [1, "<fieldset>", "</fieldset>"], thead: [1, "<table>", "</table>"], tr: [2, "<table><tbody>", "</tbody></table>"], td: [3, "<table><tbody><tr>", "</tr></tbody></table>"], col: [2, "<table><tbody></tbody><colgroup>", "</colgroup></table>"], area: [1, "<map>", "</map>"], _default: [0, "", ""] }; X.optgroup = X.option, X.tbody = X.tfoot = X.colgroup = X.caption = X.thead, X.th = X.td, d.support.htmlSerialize || (X._default = [1, "div<div>", "</div>"]), d.fn.extend({ text: function (a) { if (d.isFunction(a)) return this.each(function (b) { var c = d(this); c.text(a.call(this, b, c.text())) }); if (typeof a !== "object" && a !== b) return this.empty().append((this[0] && this[0].ownerDocument || c).createTextNode(a)); return d.text(this) }, wrapAll: function (a) { if (d.isFunction(a)) return this.each(function (b) { d(this).wrapAll(a.call(this, b)) }); if (this[0]) { var b = d(a, this[0].ownerDocument).eq(0).clone(!0); this[0].parentNode && b.insertBefore(this[0]), b.map(function () { var a = this; while (a.firstChild && a.firstChild.nodeType === 1) a = a.firstChild; return a }).append(this) } return this }, wrapInner: function (a) { if (d.isFunction(a)) return this.each(function (b) { d(this).wrapInner(a.call(this, b)) }); return this.each(function () { var b = d(this), c = b.contents(); c.length ? c.wrapAll(a) : b.append(a) }) }, wrap: function (a) { return this.each(function () { d(this).wrapAll(a) }) }, unwrap: function () { return this.parent().each(function () { d.nodeName(this, "body") || d(this).replaceWith(this.childNodes) }).end() }, append: function () { return this.domManip(arguments, !0, function (a) { this.nodeType === 1 && this.appendChild(a) }) }, prepend: function () { return this.domManip(arguments, !0, function (a) { this.nodeType === 1 && this.insertBefore(a, this.firstChild) }) }, before: function () { if (this[0] && this[0].parentNode) return this.domManip(arguments, !1, function (a) { this.parentNode.insertBefore(a, this) }); if (arguments.length) { var a = d(arguments[0]); a.push.apply(a, this.toArray()); return this.pushStack(a, "before", arguments) } }, after: function () { if (this[0] && this[0].parentNode) return this.domManip(arguments, !1, function (a) { this.parentNode.insertBefore(a, this.nextSibling) }); if (arguments.length) { var a = this.pushStack(this, "after", arguments); a.push.apply(a, d(arguments[0]).toArray()); return a } }, remove: function (a, b) { for (var c = 0, e; (e = this[c]) != null; c++) if (!a || d.filter(a, [e]).length) !b && e.nodeType === 1 && (d.cleanData(e.getElementsByTagName("*")), d.cleanData([e])), e.parentNode && e.parentNode.removeChild(e); return this }, empty: function () { for (var a = 0, b; (b = this[a]) != null; a++) { b.nodeType === 1 && d.cleanData(b.getElementsByTagName("*")); while (b.firstChild) b.removeChild(b.firstChild) } return this }, clone: function (a, b) { a = a == null ? !0 : a, b = b == null ? a : b; return this.map(function () { return d.clone(this, a, b) }) }, html: function (a) { if (a === b) return this[0] && this[0].nodeType === 1 ? this[0].innerHTML.replace(P, "") : null; if (typeof a !== "string" || V.test(a) || !d.support.leadingWhitespace && Q.test(a) || X[(S.exec(a) || ["", ""])[1].toLowerCase()]) d.isFunction(a) ? this.each(function (b) { var c = d(this); c.html(a.call(this, b, c.html())) }) : this.empty().append(a); else { a = a.replace(R, "<$1></$2>"); try { for (var c = 0, e = this.length; c < e; c++) this[c].nodeType === 1 && (d.cleanData(this[c].getElementsByTagName("*")), this[c].innerHTML = a) } catch (f) { this.empty().append(a) } } return this }, replaceWith: function (a) { if (this[0] && this[0].parentNode) { if (d.isFunction(a)) return this.each(function (b) { var c = d(this), e = c.html(); c.replaceWith(a.call(this, b, e)) }); typeof a !== "string" && (a = d(a).detach()); return this.each(function () { var b = this.nextSibling, c = this.parentNode; d(this).remove(), b ? d(b).before(a) : d(c).append(a) }) } return this.pushStack(d(d.isFunction(a) ? a() : a), "replaceWith", a) }, detach: function (a) { return this.remove(a, !0) }, domManip: function (a, c, e) { var f, g, h, i, j = a[0], k = []; if (!d.support.checkClone && arguments.length === 3 && typeof j === "string" && W.test(j)) return this.each(function () { d(this).domManip(a, c, e, !0) }); if (d.isFunction(j)) return this.each(function (f) { var g = d(this); a[0] = j.call(this, f, c ? g.html() : b), g.domManip(a, c, e) }); if (this[0]) { i = j && j.parentNode, d.support.parentNode && i && i.nodeType === 11 && i.childNodes.length === this.length ? f = { fragment: i} : f = d.buildFragment(a, this, k), h = f.fragment, h.childNodes.length === 1 ? g = h = h.firstChild : g = h.firstChild; if (g) { c = c && d.nodeName(g, "tr"); for (var l = 0, m = this.length, n = m - 1; l < m; l++) e.call(c ? Y(this[l], g) : this[l], f.cacheable || m > 1 && l < n ? d.clone(h, !0, !0) : h) } k.length && d.each(k, _) } return this } }), d.buildFragment = function (a, b, e) { var f, g, h, i = b && b[0] ? b[0].ownerDocument || b[0] : c; a.length === 1 && typeof a[0] === "string" && a[0].length < 512 && i === c && a[0].charAt(0) === "<" && !V.test(a[0]) && (d.support.checkClone || !W.test(a[0])) && (g = !0, h = d.fragments[a[0]], h && (h !== 1 && (f = h))), f || (f = i.createDocumentFragment(), d.clean(a, i, f, e)), g && (d.fragments[a[0]] = h ? f : 1); return { fragment: f, cacheable: g} }, d.fragments = {}, d.each({ appendTo: "append", prependTo: "prepend", insertBefore: "before", insertAfter: "after", replaceAll: "replaceWith" }, function (a, b) { d.fn[a] = function (c) { var e = [], f = d(c), g = this.length === 1 && this[0].parentNode; if (g && g.nodeType === 11 && g.childNodes.length === 1 && f.length === 1) { f[b](this[0]); return this } for (var h = 0, i = f.length; h < i; h++) { var j = (h > 0 ? this.clone(!0) : this).get(); d(f[h])[b](j), e = e.concat(j) } return this.pushStack(e, a, f.selector) } }), d.extend({ clone: function (a, b, c) { var e = a.cloneNode(!0), f, g, h; if (!d.support.noCloneEvent && (a.nodeType === 1 || a.nodeType === 11) && !d.isXMLDoc(a)) { f = a.getElementsByTagName("*"), g = e.getElementsByTagName("*"); for (h = 0; f[h]; ++h) $(f[h], g[h]); $(a, e) } if (b) { Z(a, e); if (c && "getElementsByTagName" in a) { f = a.getElementsByTagName("*"), g = e.getElementsByTagName("*"); if (f.length) for (h = 0; f[h]; ++h) Z(f[h], g[h]) } } return e }, clean: function (a, b, e, f) { b = b || c, typeof b.createElement === "undefined" && (b = b.ownerDocument || b[0] && b[0].ownerDocument || c); var g = []; for (var h = 0, i; (i = a[h]) != null; h++) { typeof i === "number" && (i += ""); if (!i) continue; if (typeof i !== "string" || U.test(i)) { if (typeof i === "string") { i = i.replace(R, "<$1></$2>"); var j = (S.exec(i) || ["", ""])[1].toLowerCase(), k = X[j] || X._default, l = k[0], m = b.createElement("div"); m.innerHTML = k[1] + i + k[2]; while (l--) m = m.lastChild; if (!d.support.tbody) { var n = T.test(i), o = j === "table" && !n ? m.firstChild && m.firstChild.childNodes : k[1] === "<table>" && !n ? m.childNodes : []; for (var p = o.length - 1; p >= 0; --p) d.nodeName(o[p], "tbody") && !o[p].childNodes.length && o[p].parentNode.removeChild(o[p]) } !d.support.leadingWhitespace && Q.test(i) && m.insertBefore(b.createTextNode(Q.exec(i)[0]), m.firstChild), i = m.childNodes } } else i = b.createTextNode(i); i.nodeType ? g.push(i) : g = d.merge(g, i) } if (e) for (h = 0; g[h]; h++) !f || !d.nodeName(g[h], "script") || g[h].type && g[h].type.toLowerCase() !== "text/javascript" ? (g[h].nodeType === 1 && g.splice.apply(g, [h + 1, 0].concat(d.makeArray(g[h].getElementsByTagName("script")))), e.appendChild(g[h])) : f.push(g[h].parentNode ? g[h].parentNode.removeChild(g[h]) : g[h]); return g }, cleanData: function (a) { var b, c, e = d.cache, f = d.expando, g = d.event.special, h = d.support.deleteExpando; for (var i = 0, j; (j = a[i]) != null; i++) { if (j.nodeName && d.noData[j.nodeName.toLowerCase()]) continue; c = j[d.expando]; if (c) { b = e[c] && e[c][f]; if (b && b.events) { for (var k in b.events) g[k] ? d.event.remove(j, k) : d.removeEvent(j, k, b.handle); b.handle && (b.handle.elem = null) } h ? delete j[d.expando] : j.removeAttribute && j.removeAttribute(d.expando), delete e[c] } } } }); var ba = /alpha\([^)]*\)/i, bb = /opacity=([^)]*)/, bc = /-([a-z])/ig, bd = /([A-Z])/g, be = /^-?\d+(?:px)?$/i, bf = /^-?\d/, bg = { position: "absolute", visibility: "hidden", display: "block" }, bh = ["Left", "Right"], bi = ["Top", "Bottom"], bj, bk, bl, bm = function (a, b) { return b.toUpperCase() }; d.fn.css = function (a, c) { if (arguments.length === 2 && c === b) return this; return d.access(this, a, c, !0, function (a, c, e) { return e !== b ? d.style(a, c, e) : d.css(a, c) }) }, d.extend({ cssHooks: { opacity: { get: function (a, b) { if (b) { var c = bj(a, "opacity", "opacity"); return c === "" ? "1" : c } return a.style.opacity } } }, cssNumber: { zIndex: !0, fontWeight: !0, opacity: !0, zoom: !0, lineHeight: !0 }, cssProps: { "float": d.support.cssFloat ? "cssFloat" : "styleFloat" }, style: function (a, c, e, f) { if (a && a.nodeType !== 3 && a.nodeType !== 8 && a.style) { var g, h = d.camelCase(c), i = a.style, j = d.cssHooks[h]; c = d.cssProps[h] || h; if (e === b) { if (j && "get" in j && (g = j.get(a, !1, f)) !== b) return g; return i[c] } if (typeof e === "number" && isNaN(e) || e == null) return; typeof e === "number" && !d.cssNumber[h] && (e += "px"); if (!j || !("set" in j) || (e = j.set(a, e)) !== b) try { i[c] = e } catch (k) { } } }, css: function (a, c, e) { var f, g = d.camelCase(c), h = d.cssHooks[g]; c = d.cssProps[g] || g; if (h && "get" in h && (f = h.get(a, !0, e)) !== b) return f; if (bj) return bj(a, c, g) }, swap: function (a, b, c) { var d = {}; for (var e in b) d[e] = a.style[e], a.style[e] = b[e]; c.call(a); for (e in b) a.style[e] = d[e] }, camelCase: function (a) { return a.replace(bc, bm) } }), d.curCSS = d.css, d.each(["height", "width"], function (a, b) { d.cssHooks[b] = { get: function (a, c, e) { var f; if (c) { a.offsetWidth !== 0 ? f = bn(a, b, e) : d.swap(a, bg, function () { f = bn(a, b, e) }); if (f <= 0) { f = bj(a, b, b), f === "0px" && bl && (f = bl(a, b, b)); if (f != null) return f === "" || f === "auto" ? "0px" : f } if (f < 0 || f == null) { f = a.style[b]; return f === "" || f === "auto" ? "0px" : f } return typeof f === "string" ? f : f + "px" } }, set: function (a, b) { if (!be.test(b)) return b; b = parseFloat(b); if (b >= 0) return b + "px" } } }), d.support.opacity || (d.cssHooks.opacity = { get: function (a, b) { return bb.test((b && a.currentStyle ? a.currentStyle.filter : a.style.filter) || "") ? parseFloat(RegExp.$1) / 100 + "" : b ? "1" : "" }, set: function (a, b) { var c = a.style; c.zoom = 1; var e = d.isNaN(b) ? "" : "alpha(opacity=" + b * 100 + ")", f = c.filter || ""; c.filter = ba.test(f) ? f.replace(ba, e) : c.filter + " " + e } }), c.defaultView && c.defaultView.getComputedStyle && (bk = function (a, c, e) { var f, g, h; e = e.replace(bd, "-$1").toLowerCase(); if (!(g = a.ownerDocument.defaultView)) return b; if (h = g.getComputedStyle(a, null)) f = h.getPropertyValue(e), f === "" && !d.contains(a.ownerDocument.documentElement, a) && (f = d.style(a, e)); return f }), c.documentElement.currentStyle && (bl = function (a, b) { var c, d = a.currentStyle && a.currentStyle[b], e = a.runtimeStyle && a.runtimeStyle[b], f = a.style; !be.test(d) && bf.test(d) && (c = f.left, e && (a.runtimeStyle.left = a.currentStyle.left), f.left = b === "fontSize" ? "1em" : d || 0, d = f.pixelLeft + "px", f.left = c, e && (a.runtimeStyle.left = e)); return d === "" ? "auto" : d }), bj = bk || bl, d.expr && d.expr.filters && (d.expr.filters.hidden = function (a) { var b = a.offsetWidth, c = a.offsetHeight; return b === 0 && c === 0 || !d.support.reliableHiddenOffsets && (a.style.display || d.css(a, "display")) === "none" }, d.expr.filters.visible = function (a) { return !d.expr.filters.hidden(a) }); var bo = /%20/g, bp = /\[\]$/, bq = /\r?\n/g, br = /#.*$/, bs = /^(.*?):\s*(.*?)\r?$/mg, bt = /^(?:color|date|datetime|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i, bu = /^(?:GET|HEAD)$/, bv = /^\/\//, bw = /\?/, bx = /<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi, by = /^(?:select|textarea)/i, bz = /\s+/, bA = /([?&])_=[^&]*/, bB = /^(\w+:)\/\/([^\/?#:]+)(?::(\d+))?/, bC = d.fn.load, bD = {}, bE = {}; d.fn.extend({ load: function (a, b, c) { if (typeof a !== "string" && bC) return bC.apply(this, arguments); if (!this.length) return this; var e = a.indexOf(" "); if (e >= 0) { var f = a.slice(e, a.length); a = a.slice(0, e) } var g = "GET"; b && (d.isFunction(b) ? (c = b, b = null) : typeof b === "object" && (b = d.param(b, d.ajaxSettings.traditional), g = "POST")); var h = this; d.ajax({ url: a, type: g, dataType: "html", data: b, complete: function (a, b, e) { e = a.responseText, a.isResolved() && (a.done(function (a) { e = a }), h.html(f ? d("<div>").append(e.replace(bx, "")).find(f) : e)), c && h.each(c, [e, b, a]) } }); return this }, serialize: function () { return d.param(this.serializeArray()) }, serializeArray: function () { return this.map(function () { return this.elements ? d.makeArray(this.elements) : this }).filter(function () { return this.name && !this.disabled && (this.checked || by.test(this.nodeName) || bt.test(this.type)) }).map(function (a, b) { var c = d(this).val(); return c == null ? null : d.isArray(c) ? d.map(c, function (a, c) { return { name: b.name, value: a.replace(bq, "\r\n")} }) : { name: b.name, value: c.replace(bq, "\r\n")} }).get() } }), d.each("ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend".split(" "), function (a, b) { d.fn[b] = function (a) { return this.bind(b, a) } }), d.each(["get", "post"], function (a, b) { d[b] = function (a, c, e, f) { d.isFunction(c) && (f = f || e, e = c, c = null); return d.ajax({ type: b, url: a, data: c, success: e, dataType: f }) } }), d.extend({ getScript: function (a, b) { return d.get(a, null, b, "script") }, getJSON: function (a, b, c) { return d.get(a, b, c, "json") }, ajaxSetup: function (a) { d.extend(!0, d.ajaxSettings, a), a.context && (d.ajaxSettings.context = a.context) }, ajaxSettings: { url: location.href, global: !0, type: "GET", contentType: "application/x-www-form-urlencoded", processData: !0, async: !0, accepts: { xml: "application/xml, text/xml", html: "text/html", text: "text/plain", json: "application/json, text/javascript", "*": "*/*" }, contents: { xml: /xml/, html: /html/, json: /json/ }, responseFields: { xml: "responseXML", text: "responseText" }, converters: { "* text": a.String, "text html": !0, "text json": d.parseJSON, "text xml": d.parseXML} }, ajaxPrefilter: bF(bD), ajaxTransport: bF(bE), ajax: function (a, e) { function w(a, c, e, l) { if (t !== 2) { t = 2, p && clearTimeout(p), o = b, m = l || "", v.readyState = a ? 4 : 0; var n, q, r, s = e ? bI(f, v, e) : b, u, w; if (a >= 200 && a < 300 || a === 304) { if (f.ifModified) { if (u = v.getResponseHeader("Last-Modified")) d.lastModified[f.url] = u; if (w = v.getResponseHeader("Etag")) d.etag[f.url] = w } if (a === 304) c = "notmodified", n = !0; else try { q = bJ(f, s), c = "success", n = !0 } catch (x) { c = "parsererror", r = x } } else r = c, a && (c = "error", a < 0 && (a = 0)); v.status = a, v.statusText = c, n ? i.resolveWith(g, [q, c, v]) : i.rejectWith(g, [v, c, r]), v.statusCode(k), k = b, f.global && h.trigger("ajax" + (n ? "Success" : "Error"), [v, f, n ? q : r]), j.resolveWith(g, [v, c]), f.global && (h.trigger("ajaxComplete", [v, f]), --d.active || d.event.trigger("ajaxStop")) } } typeof e !== "object" && (e = a, a = b), e = e || {}; var f = d.extend(!0, {}, d.ajaxSettings, e), g = (f.context = ("context" in e ? e : d.ajaxSettings).context) || f, h = g === f ? d.event : d(g), i = d.Deferred(), j = d._Deferred(), k = f.statusCode || {}, l = {}, m, n, o, p, q = c.location, r = q.protocol || "http:", s, t = 0, u, v = { readyState: 0, setRequestHeader: function (a, b) { t === 0 && (l[a.toLowerCase()] = b); return this }, getAllResponseHeaders: function () { return t === 2 ? m : null }, getResponseHeader: function (a) { var b; if (t === 2) { if (!n) { n = {}; while (b = bs.exec(m)) n[b[1].toLowerCase()] = b[2] } b = n[a.toLowerCase()] } return b || null }, abort: function (a) { a = a || "abort", o && o.abort(a), w(0, a); return this } }; i.promise(v), v.success = v.done, v.error = v.fail, v.complete = j.done, v.statusCode = function (a) { if (a) { var b; if (t < 2) for (b in a) k[b] = [k[b], a[b]]; else b = a[v.status], v.then(b, b) } return this }, f.url = ("" + (a || f.url)).replace(br, "").replace(bv, r + "//"), f.dataTypes = d.trim(f.dataType || "*").toLowerCase().split(bz), f.crossDomain || (s = bB.exec(f.url.toLowerCase()), f.crossDomain = s && (s[1] != r || s[2] != q.hostname || (s[3] || (s[1] === "http:" ? 80 : 443)) != (q.port || (r === "http:" ? 80 : 443)))), f.data && f.processData && typeof f.data !== "string" && (f.data = d.param(f.data, f.traditional)), bG(bD, f, e, v), f.type = f.type.toUpperCase(), f.hasContent = !bu.test(f.type), f.global && d.active++ === 0 && d.event.trigger("ajaxStart"); if (!f.hasContent) { f.data && (f.url += (bw.test(f.url) ? "&" : "?") + f.data); if (f.cache === !1) { var x = d.now(), y = f.url.replace(bA, "$1_=" + x); f.url = y + (y === f.url ? (bw.test(f.url) ? "&" : "?") + "_=" + x : "") } } if (f.data && f.hasContent && f.contentType !== !1 || e.contentType) l["content-type"] = f.contentType; f.ifModified && (d.lastModified[f.url] && (l["if-modified-since"] = d.lastModified[f.url]), d.etag[f.url] && (l["if-none-match"] = d.etag[f.url])), l.accept = f.dataTypes[0] && f.accepts[f.dataTypes[0]] ? f.accepts[f.dataTypes[0]] + (f.dataTypes[0] !== "*" ? ", */*; q=0.01" : "") : f.accepts["*"]; for (u in f.headers) l[u.toLowerCase()] = f.headers[u]; if (!f.beforeSend || f.beforeSend.call(g, v, f) !== !1 && t !== 2) { for (u in { success: 1, error: 1, complete: 1 }) v[u](f[u]); o = bG(bE, f, e, v); if (o) { t = v.readyState = 1, f.global && h.trigger("ajaxSend", [v, f]), f.async && f.timeout > 0 && (p = setTimeout(function () { v.abort("timeout") }, f.timeout)); try { o.send(l, w) } catch (z) { status < 2 ? w(-1, z) : d.error(z) } } else w(-1, "No Transport") } else w(0, "abort"), v = !1; return v }, param: function (a, c) { var e = [], f = function (a, b) { b = d.isFunction(b) ? b() : b, e[e.length] = encodeURIComponent(a) + "=" + encodeURIComponent(b) }; c === b && (c = d.ajaxSettings.traditional); if (d.isArray(a) || a.jquery) d.each(a, function () { f(this.name, this.value) }); else for (var g in a) bH(g, a[g], c, f); return e.join("&").replace(bo, "+") } }), d.extend({ active: 0, lastModified: {}, etag: {} }); var bK = d.now(), bL = /(\=)\?(&|$)|()\?\?()/i; d.ajaxSetup({ jsonp: "callback", jsonpCallback: function () { return d.expando + "_" + bK++ } }), d.ajaxPrefilter("json jsonp", function (b, c, e) { e = typeof b.data === "string"; if (b.dataTypes[0] === "jsonp" || c.jsonpCallback || c.jsonp != null || b.jsonp !== !1 && (bL.test(b.url) || e && bL.test(b.data))) { var f, g = b.jsonpCallback = d.isFunction(b.jsonpCallback) ? b.jsonpCallback() : b.jsonpCallback, h = a[g], i = b.url, j = b.data, k = "$1" + g + "$2"; b.jsonp !== !1 && (i = i.replace(bL, k), b.url === i && (e && (j = j.replace(bL, k)), b.data === j && (i += (/\?/.test(i) ? "&" : "?") + b.jsonp + "=" + g))), b.url = i, b.data = j, a[g] = function (a) { f = [a] }, b.complete = [function () { a[g] = h; if (h) f && d.isFunction(h) && a[g](f[0]); else try { delete a[g] } catch (b) { } }, b.complete], b.converters["script json"] = function () { f || d.error(g + " was not called"); return f[0] }, b.dataTypes[0] = "json"; return "script" } }), d.ajaxSetup({ accepts: { script: "text/javascript, application/javascript" }, contents: { script: /javascript/ }, converters: { "text script": function (a) { d.globalEval(a); return a } } }), d.ajaxPrefilter("script", function (a) { a.cache === b && (a.cache = !1), a.crossDomain && (a.type = "GET", a.global = !1) }), d.ajaxTransport("script", function (a) { if (a.crossDomain) { var d, e = c.getElementsByTagName("head")[0] || c.documentElement; return { send: function (f, g) { d = c.createElement("script"), d.async = "async", a.scriptCharset && (d.charset = a.scriptCharset), d.src = a.url, d.onload = d.onreadystatechange = function (a, c) { if (!d.readyState || /loaded|complete/.test(d.readyState)) d.onload = d.onreadystatechange = null, e && d.parentNode && e.removeChild(d), d = b, c || g(200, "success") }, e.insertBefore(d, e.firstChild) }, abort: function () { d && d.onload(0, 1) } } } }); var bM = d.now(), bN = {}, bO, bP; d.ajaxSettings.xhr = a.ActiveXObject ? function () { if (a.location.protocol !== "file:") try { return new a.XMLHttpRequest } catch (b) { } try { return new a.ActiveXObject("Microsoft.XMLHTTP") } catch (c) { } } : function () { return new a.XMLHttpRequest }; try { bP = d.ajaxSettings.xhr() } catch (bQ) { } d.support.ajax = !!bP, d.support.cors = bP && "withCredentials" in bP, bP = b, d.support.ajax && d.ajaxTransport(function (b) { if (!b.crossDomain || d.support.cors) { var c; return { send: function (e, f) { bO || (bO = 1, d(a).bind("unload", function () { d.each(bN, function (a, b) { b.onreadystatechange && b.onreadystatechange(1) }) })); var g = b.xhr(), h; b.username ? g.open(b.type, b.url, b.async, b.username, b.password) : g.open(b.type, b.url, b.async), (!b.crossDomain || b.hasContent) && !e["x-requested-with"] && (e["x-requested-with"] = "XMLHttpRequest"); try { d.each(e, function (a, b) { g.setRequestHeader(a, b) }) } catch (i) { } g.send(b.hasContent && b.data || null), c = function (a, e) { if (c && (e || g.readyState === 4)) { c = 0, h && (g.onreadystatechange = d.noop, delete bN[h]); if (e) g.readyState !== 4 && g.abort(); else { var i = g.status, j, k = g.getAllResponseHeaders(), l = {}, m = g.responseXML; m && m.documentElement && (l.xml = m), l.text = g.responseText; try { j = g.statusText } catch (n) { j = "" } i = i === 0 ? !b.crossDomain || j ? k ? 304 : 0 : 302 : i == 1223 ? 204 : i, f(i, j, l, k) } } }, b.async && g.readyState !== 4 ? (h = bM++, bN[h] = g, g.onreadystatechange = c) : c() }, abort: function () { c && c(0, 1) } } } }); var bR = {}, bS = /^(?:toggle|show|hide)$/, bT = /^([+\-]=)?([\d+.\-]+)([a-z%]*)$/i, bU, bV = [["height", "marginTop", "marginBottom", "paddingTop", "paddingBottom"], ["width", "marginLeft", "marginRight", "paddingLeft", "paddingRight"], ["opacity"]]; d.fn.extend({ show: function (a, b, c) { var e, f; if (a || a === 0) return this.animate(bW("show", 3), a, b, c); for (var g = 0, h = this.length; g < h; g++) e = this[g], f = e.style.display, !d._data(e, "olddisplay") && f === "none" && (f = e.style.display = ""), f === "" && d.css(e, "display") === "none" && d._data(e, "olddisplay", bX(e.nodeName)); for (g = 0; g < h; g++) { e = this[g], f = e.style.display; if (f === "" || f === "none") e.style.display = d._data(e, "olddisplay") || "" } return this }, hide: function (a, b, c) { if (a || a === 0) return this.animate(bW("hide", 3), a, b, c); for (var e = 0, f = this.length; e < f; e++) { var g = d.css(this[e], "display"); g !== "none" && !d._data(this[e], "olddisplay") && d._data(this[e], "olddisplay", g) } for (e = 0; e < f; e++) this[e].style.display = "none"; return this }, _toggle: d.fn.toggle, toggle: function (a, b, c) { var e = typeof a === "boolean"; d.isFunction(a) && d.isFunction(b) ? this._toggle.apply(this, arguments) : a == null || e ? this.each(function () { var b = e ? a : d(this).is(":hidden"); d(this)[b ? "show" : "hide"]() }) : this.animate(bW("toggle", 3), a, b, c); return this }, fadeTo: function (a, b, c, d) { return this.filter(":hidden").css("opacity", 0).show().end().animate({ opacity: b }, a, c, d) }, animate: function (a, b, c, e) { var f = d.speed(b, c, e); if (d.isEmptyObject(a)) return this.each(f.complete); return this[f.queue === !1 ? "each" : "queue"](function () { var b = d.extend({}, f), c, e = this.nodeType === 1, g = e && d(this).is(":hidden"), h = this; for (c in a) { var i = d.camelCase(c); c !== i && (a[i] = a[c], delete a[c], c = i); if (a[c] === "hide" && g || a[c] === "show" && !g) return b.complete.call(this); if (e && (c === "height" || c === "width")) { b.overflow = [this.style.overflow, this.style.overflowX, this.style.overflowY]; if (d.css(this, "display") === "inline" && d.css(this, "float") === "none") if (d.support.inlineBlockNeedsLayout) { var j = bX(this.nodeName); j === "inline" ? this.style.display = "inline-block" : (this.style.display = "inline", this.style.zoom = 1) } else this.style.display = "inline-block" } d.isArray(a[c]) && ((b.specialEasing = b.specialEasing || {})[c] = a[c][1], a[c] = a[c][0]) } b.overflow != null && (this.style.overflow = "hidden"), b.curAnim = d.extend({}, a), d.each(a, function (c, e) { var f = new d.fx(h, b, c); if (bS.test(e)) f[e === "toggle" ? g ? "show" : "hide" : e](a); else { var i = bT.exec(e), j = f.cur() || 0; if (i) { var k = parseFloat(i[2]), l = i[3] || "px"; l !== "px" && (d.style(h, c, (k || 1) + l), j = (k || 1) / f.cur() * j, d.style(h, c, j + l)), i[1] && (k = (i[1] === "-=" ? -1 : 1) * k + j), f.custom(j, k, l) } else f.custom(j, e, "") } }); return !0 }) }, stop: function (a, b) { var c = d.timers; a && this.queue([]), this.each(function () { for (var a = c.length - 1; a >= 0; a--) c[a].elem === this && (b && c[a](!0), c.splice(a, 1)) }), b || this.dequeue(); return this } }), d.each({ slideDown: bW("show", 1), slideUp: bW("hide", 1), slideToggle: bW("toggle", 1), fadeIn: { opacity: "show" }, fadeOut: { opacity: "hide" }, fadeToggle: { opacity: "toggle"} }, function (a, b) { d.fn[a] = function (a, c, d) { return this.animate(b, a, c, d) } }), d.extend({ speed: function (a, b, c) { var e = a && typeof a === "object" ? d.extend({}, a) : { complete: c || !c && b || d.isFunction(a) && a, duration: a, easing: c && b || b && !d.isFunction(b) && b }; e.duration = d.fx.off ? 0 : typeof e.duration === "number" ? e.duration : e.duration in d.fx.speeds ? d.fx.speeds[e.duration] : d.fx.speeds._default, e.old = e.complete, e.complete = function () { e.queue !== !1 && d(this).dequeue(), d.isFunction(e.old) && e.old.call(this) }; return e }, easing: { linear: function (a, b, c, d) { return c + d * a }, swing: function (a, b, c, d) { return (-Math.cos(a * Math.PI) / 2 + .5) * d + c } }, timers: [], fx: function (a, b, c) { this.options = b, this.elem = a, this.prop = c, b.orig || (b.orig = {}) } }), d.fx.prototype = { update: function () { this.options.step && this.options.step.call(this.elem, this.now, this), (d.fx.step[this.prop] || d.fx.step._default)(this) }, cur: function () { if (this.elem[this.prop] != null && (!this.elem.style || this.elem.style[this.prop] == null)) return this.elem[this.prop]; var a = parseFloat(d.css(this.elem, this.prop)); return a || 0 }, custom: function (a, b, c) { function g(a) { return e.step(a) } var e = this, f = d.fx; this.startTime = d.now(), this.start = a, this.end = b, this.unit = c || this.unit || "px", this.now = this.start, this.pos = this.state = 0, g.elem = this.elem, g() && d.timers.push(g) && !bU && (bU = setInterval(f.tick, f.interval)) }, show: function () { this.options.orig[this.prop] = d.style(this.elem, this.prop), this.options.show = !0, this.custom(this.prop === "width" || this.prop === "height" ? 1 : 0, this.cur()), d(this.elem).show() }, hide: function () { this.options.orig[this.prop] = d.style(this.elem, this.prop), this.options.hide = !0, this.custom(this.cur(), 0) }, step: function (a) { var b = d.now(), c = !0; if (a || b >= this.options.duration + this.startTime) { this.now = this.end, this.pos = this.state = 1, this.update(), this.options.curAnim[this.prop] = !0; for (var e in this.options.curAnim) this.options.curAnim[e] !== !0 && (c = !1); if (c) { if (this.options.overflow != null && !d.support.shrinkWrapBlocks) { var f = this.elem, g = this.options; d.each(["", "X", "Y"], function (a, b) { f.style["overflow" + b] = g.overflow[a] }) } this.options.hide && d(this.elem).hide(); if (this.options.hide || this.options.show) for (var h in this.options.curAnim) d.style(this.elem, h, this.options.orig[h]); this.options.complete.call(this.elem) } return !1 } var i = b - this.startTime; this.state = i / this.options.duration; var j = this.options.specialEasing && this.options.specialEasing[this.prop], k = this.options.easing || (d.easing.swing ? "swing" : "linear"); this.pos = d.easing[j || k](this.state, i, 0, 1, this.options.duration), this.now = this.start + (this.end - this.start) * this.pos, this.update(); return !0 } }, d.extend(d.fx, { tick: function () { var a = d.timers; for (var b = 0; b < a.length; b++) a[b]() || a.splice(b--, 1); a.length || d.fx.stop() }, interval: 13, stop: function () { clearInterval(bU), bU = null }, speeds: { slow: 600, fast: 200, _default: 400 }, step: { opacity: function (a) { d.style(a.elem, "opacity", a.now) }, _default: function (a) { a.elem.style && a.elem.style[a.prop] != null ? a.elem.style[a.prop] = (a.prop === "width" || a.prop === "height" ? Math.max(0, a.now) : a.now) + a.unit : a.elem[a.prop] = a.now } } }), d.expr && d.expr.filters && (d.expr.filters.animated = function (a) { return d.grep(d.timers, function (b) { return a === b.elem }).length }); var bY = /^t(?:able|d|h)$/i, bZ = /^(?:body|html)$/i; "getBoundingClientRect" in c.documentElement ? d.fn.offset = function (a) { var b = this[0], c; if (a) return this.each(function (b) { d.offset.setOffset(this, a, b) }); if (!b || !b.ownerDocument) return null; if (b === b.ownerDocument.body) return d.offset.bodyOffset(b); try { c = b.getBoundingClientRect() } catch (e) { } var f = b.ownerDocument, g = f.documentElement; if (!c || !d.contains(g, b)) return c ? { top: c.top, left: c.left} : { top: 0, left: 0 }; var h = f.body, i = b$(f), j = g.clientTop || h.clientTop || 0, k = g.clientLeft || h.clientLeft || 0, l = i.pageYOffset || d.support.boxModel && g.scrollTop || h.scrollTop, m = i.pageXOffset || d.support.boxModel && g.scrollLeft || h.scrollLeft, n = c.top + l - j, o = c.left + m - k; return { top: n, left: o} } : d.fn.offset = function (a) { var b = this[0]; if (a) return this.each(function (b) { d.offset.setOffset(this, a, b) }); if (!b || !b.ownerDocument) return null; if (b === b.ownerDocument.body) return d.offset.bodyOffset(b); d.offset.initialize(); var c, e = b.offsetParent, f = b, g = b.ownerDocument, h = g.documentElement, i = g.body, j = g.defaultView, k = j ? j.getComputedStyle(b, null) : b.currentStyle, l = b.offsetTop, m = b.offsetLeft; while ((b = b.parentNode) && b !== i && b !== h) { if (d.offset.supportsFixedPosition && k.position === "fixed") break; c = j ? j.getComputedStyle(b, null) : b.currentStyle, l -= b.scrollTop, m -= b.scrollLeft, b === e && (l += b.offsetTop, m += b.offsetLeft, d.offset.doesNotAddBorder && (!d.offset.doesAddBorderForTableAndCells || !bY.test(b.nodeName)) && (l += parseFloat(c.borderTopWidth) || 0, m += parseFloat(c.borderLeftWidth) || 0), f = e, e = b.offsetParent), d.offset.subtractsBorderForOverflowNotVisible && c.overflow !== "visible" && (l += parseFloat(c.borderTopWidth) || 0, m += parseFloat(c.borderLeftWidth) || 0), k = c } if (k.position === "relative" || k.position === "static") l += i.offsetTop, m += i.offsetLeft; d.offset.supportsFixedPosition && k.position === "fixed" && (l += Math.max(h.scrollTop, i.scrollTop), m += Math.max(h.scrollLeft, i.scrollLeft)); return { top: l, left: m} }, d.offset = { initialize: function () { var a = c.body, b = c.createElement("div"), e, f, g, h, i = parseFloat(d.css(a, "marginTop")) || 0, j = "<div style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;'><div></div></div><table style='position:absolute;top:0;left:0;margin:0;border:5px solid #000;padding:0;width:1px;height:1px;' cellpadding='0' cellspacing='0'><tr><td></td></tr></table>"; d.extend(b.style, { position: "absolute", top: 0, left: 0, margin: 0, border: 0, width: "1px", height: "1px", visibility: "hidden" }), b.innerHTML = j, a.insertBefore(b, a.firstChild), e = b.firstChild, f = e.firstChild, h = e.nextSibling.firstChild.firstChild, this.doesNotAddBorder = f.offsetTop !== 5, this.doesAddBorderForTableAndCells = h.offsetTop === 5, f.style.position = "fixed", f.style.top = "20px", this.supportsFixedPosition = f.offsetTop === 20 || f.offsetTop === 15, f.style.position = f.style.top = "", e.style.overflow = "hidden", e.style.position = "relative", this.subtractsBorderForOverflowNotVisible = f.offsetTop === -5, this.doesNotIncludeMarginInBodyOffset = a.offsetTop !== i, a.removeChild(b), a = b = e = f = g = h = null, d.offset.initialize = d.noop }, bodyOffset: function (a) { var b = a.offsetTop, c = a.offsetLeft; d.offset.initialize(), d.offset.doesNotIncludeMarginInBodyOffset && (b += parseFloat(d.css(a, "marginTop")) || 0, c += parseFloat(d.css(a, "marginLeft")) || 0); return { top: b, left: c} }, setOffset: function (a, b, c) { var e = d.css(a, "position"); e === "static" && (a.style.position = "relative"); var f = d(a), g = f.offset(), h = d.css(a, "top"), i = d.css(a, "left"), j = e === "absolute" && d.inArray("auto", [h, i]) > -1, k = {}, l = {}, m, n; j && (l = f.position()), m = j ? l.top : parseInt(h, 10) || 0, n = j ? l.left : parseInt(i, 10) || 0, d.isFunction(b) && (b = b.call(a, c, g)), b.top != null && (k.top = b.top - g.top + m), b.left != null && (k.left = b.left - g.left + n), "using" in b ? b.using.call(a, k) : f.css(k) } }, d.fn.extend({ position: function () { if (!this[0]) return null; var a = this[0], b = this.offsetParent(), c = this.offset(), e = bZ.test(b[0].nodeName) ? { top: 0, left: 0} : b.offset(); c.top -= parseFloat(d.css(a, "marginTop")) || 0, c.left -= parseFloat(d.css(a, "marginLeft")) || 0, e.top += parseFloat(d.css(b[0], "borderTopWidth")) || 0, e.left += parseFloat(d.css(b[0], "borderLeftWidth")) || 0; return { top: c.top - e.top, left: c.left - e.left} }, offsetParent: function () { return this.map(function () { var a = this.offsetParent || c.body; while (a && (!bZ.test(a.nodeName) && d.css(a, "position") === "static")) a = a.offsetParent; return a }) } }), d.each(["Left", "Top"], function (a, c) { var e = "scroll" + c; d.fn[e] = function (c) { var f = this[0], g; if (!f) return null; if (c !== b) return this.each(function () { g = b$(this), g ? g.scrollTo(a ? d(g).scrollLeft() : c, a ? c : d(g).scrollTop()) : this[e] = c }); g = b$(f); return g ? "pageXOffset" in g ? g[a ? "pageYOffset" : "pageXOffset"] : d.support.boxModel && g.document.documentElement[e] || g.document.body[e] : f[e] } }), d.each(["Height", "Width"], function (a, c) { var e = c.toLowerCase(); d.fn["inner" + c] = function () { return this[0] ? parseFloat(d.css(this[0], e, "padding")) : null }, d.fn["outer" + c] = function (a) { return this[0] ? parseFloat(d.css(this[0], e, a ? "margin" : "border")) : null }, d.fn[e] = function (a) { var f = this[0]; if (!f) return a == null ? null : this; if (d.isFunction(a)) return this.each(function (b) { var c = d(this); c[e](a.call(this, b, c[e]())) }); if (d.isWindow(f)) { var g = f.document.documentElement["client" + c]; return f.document.compatMode === "CSS1Compat" && g || f.document.body["client" + c] || g } if (f.nodeType === 9) return Math.max(f.documentElement["client" + c], f.body["scroll" + c], f.documentElement["scroll" + c], f.body["offset" + c], f.documentElement["offset" + c]); if (a === b) { var h = d.css(f, e), i = parseFloat(h); return d.isNaN(i) ? h : i } return this.css(e, typeof a === "string" ? a : a + "px") } }) })(window);
/*!
* jQuery UI 1.8.7
*
* Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
* Dual licensed under the MIT or GPL Version 2 licenses.
* http://jquery.org/license
*
* http://docs.jquery.com/UI
*/
(function (c, j) {
    function k(a) { return !c(a).parents().andSelf().filter(function () { return c.curCSS(this, "visibility") === "hidden" || c.expr.filters.hidden(this) }).length } c.ui = c.ui || {}; if (!c.ui.version) {
        c.extend(c.ui, { version: "1.8.7", keyCode: { ALT: 18, BACKSPACE: 8, CAPS_LOCK: 20, COMMA: 188, COMMAND: 91, COMMAND_LEFT: 91, COMMAND_RIGHT: 93, CONTROL: 17, DELETE: 46, DOWN: 40, END: 35, ENTER: 13, ESCAPE: 27, HOME: 36, INSERT: 45, LEFT: 37, MENU: 93, NUMPAD_ADD: 107, NUMPAD_DECIMAL: 110, NUMPAD_DIVIDE: 111, NUMPAD_ENTER: 108, NUMPAD_MULTIPLY: 106,
            NUMPAD_SUBTRACT: 109, PAGE_DOWN: 34, PAGE_UP: 33, PERIOD: 190, RIGHT: 39, SHIFT: 16, SPACE: 32, TAB: 9, UP: 38, WINDOWS: 91
        }
        }); c.fn.extend({ _focus: c.fn.focus, focus: function (a, b) { return typeof a === "number" ? this.each(function () { var d = this; setTimeout(function () { c(d).focus(); b && b.call(d) }, a) }) : this._focus.apply(this, arguments) }, scrollParent: function () {
            var a; a = c.browser.msie && /(static|relative)/.test(this.css("position")) || /absolute/.test(this.css("position")) ? this.parents().filter(function () {
                return /(relative|absolute|fixed)/.test(c.curCSS(this,
"position", 1)) && /(auto|scroll)/.test(c.curCSS(this, "overflow", 1) + c.curCSS(this, "overflow-y", 1) + c.curCSS(this, "overflow-x", 1))
            }).eq(0) : this.parents().filter(function () { return /(auto|scroll)/.test(c.curCSS(this, "overflow", 1) + c.curCSS(this, "overflow-y", 1) + c.curCSS(this, "overflow-x", 1)) }).eq(0); return /fixed/.test(this.css("position")) || !a.length ? c(document) : a
        }, zIndex: function (a) {
            if (a !== j) return this.css("zIndex", a); if (this.length) {
                a = c(this[0]); for (var b; a.length && a[0] !== document; ) {
                    b = a.css("position");
                    if (b === "absolute" || b === "relative" || b === "fixed") { b = parseInt(a.css("zIndex"), 10); if (!isNaN(b) && b !== 0) return b } a = a.parent()
                } 
            } return 0
        }, disableSelection: function () { return this.bind((c.support.selectstart ? "selectstart" : "mousedown") + ".ui-disableSelection", function (a) { a.preventDefault() }) }, enableSelection: function () { return this.unbind(".ui-disableSelection") } 
        }); c.each(["Width", "Height"], function (a, b) {
            function d(f, g, l, m) {
                c.each(e, function () {
                    g -= parseFloat(c.curCSS(f, "padding" + this, true)) || 0; if (l) g -= parseFloat(c.curCSS(f,
"border" + this + "Width", true)) || 0; if (m) g -= parseFloat(c.curCSS(f, "margin" + this, true)) || 0
                }); return g
            } var e = b === "Width" ? ["Left", "Right"] : ["Top", "Bottom"], h = b.toLowerCase(), i = { innerWidth: c.fn.innerWidth, innerHeight: c.fn.innerHeight, outerWidth: c.fn.outerWidth, outerHeight: c.fn.outerHeight }; c.fn["inner" + b] = function (f) { if (f === j) return i["inner" + b].call(this); return this.each(function () { c(this).css(h, d(this, f) + "px") }) }; c.fn["outer" + b] = function (f, g) {
                if (typeof f !== "number") return i["outer" + b].call(this, f); return this.each(function () {
                    c(this).css(h,
d(this, f, true, g) + "px")
                })
            } 
        }); c.extend(c.expr[":"], { data: function (a, b, d) { return !!c.data(a, d[3]) }, focusable: function (a) { var b = a.nodeName.toLowerCase(), d = c.attr(a, "tabindex"); if ("area" === b) { b = a.parentNode; d = b.name; if (!a.href || !d || b.nodeName.toLowerCase() !== "map") return false; a = c("img[usemap=#" + d + "]")[0]; return !!a && k(a) } return (/input|select|textarea|button|object/.test(b) ? !a.disabled : "a" == b ? a.href || !isNaN(d) : !isNaN(d)) && k(a) }, tabbable: function (a) { var b = c.attr(a, "tabindex"); return (isNaN(b) || b >= 0) && c(a).is(":focusable") } });
        c(function () { var a = document.body, b = a.appendChild(b = document.createElement("div")); c.extend(b.style, { minHeight: "100px", height: "auto", padding: 0, borderWidth: 0 }); c.support.minHeight = b.offsetHeight === 100; c.support.selectstart = "onselectstart" in b; a.removeChild(b).style.display = "none" }); c.extend(c.ui, { plugin: { add: function (a, b, d) { a = c.ui[a].prototype; for (var e in d) { a.plugins[e] = a.plugins[e] || []; a.plugins[e].push([b, d[e]]) } }, call: function (a, b, d) {
            if ((b = a.plugins[b]) && a.element[0].parentNode) for (var e = 0; e < b.length; e++) a.options[b[e][0]] &&
b[e][1].apply(a.element, d)
        } 
        }, contains: function (a, b) { return document.compareDocumentPosition ? a.compareDocumentPosition(b) & 16 : a !== b && a.contains(b) }, hasScroll: function (a, b) { if (c(a).css("overflow") === "hidden") return false; b = b && b === "left" ? "scrollLeft" : "scrollTop"; var d = false; if (a[b] > 0) return true; a[b] = 1; d = a[b] > 0; a[b] = 0; return d }, isOverAxis: function (a, b, d) { return a > b && a < b + d }, isOver: function (a, b, d, e, h, i) { return c.ui.isOverAxis(a, d, h) && c.ui.isOverAxis(b, e, i) } 
        })
    } 
})(jQuery);
; /*!
 * jQuery UI Widget 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Widget
 */
(function (b, j) {
    if (b.cleanData) { var k = b.cleanData; b.cleanData = function (a) { for (var c = 0, d; (d = a[c]) != null; c++) b(d).triggerHandler("remove"); k(a) } } else { var l = b.fn.remove; b.fn.remove = function (a, c) { return this.each(function () { if (!c) if (!a || b.filter(a, [this]).length) b("*", this).add([this]).each(function () { b(this).triggerHandler("remove") }); return l.call(b(this), a, c) }) } } b.widget = function (a, c, d) {
        var e = a.split(".")[0], f; a = a.split(".")[1]; f = e + "-" + a; if (!d) { d = c; c = b.Widget } b.expr[":"][f] = function (h) {
            return !!b.data(h,
a)
        }; b[e] = b[e] || {}; b[e][a] = function (h, g) { arguments.length && this._createWidget(h, g) }; c = new c; c.options = b.extend(true, {}, c.options); b[e][a].prototype = b.extend(true, c, { namespace: e, widgetName: a, widgetEventPrefix: b[e][a].prototype.widgetEventPrefix || a, widgetBaseClass: f }, d); b.widget.bridge(a, b[e][a])
    }; b.widget.bridge = function (a, c) {
        b.fn[a] = function (d) {
            var e = typeof d === "string", f = Array.prototype.slice.call(arguments, 1), h = this; d = !e && f.length ? b.extend.apply(null, [true, d].concat(f)) : d; if (e && d.charAt(0) === "_") return h;
            e ? this.each(function () { var g = b.data(this, a), i = g && b.isFunction(g[d]) ? g[d].apply(g, f) : g; if (i !== g && i !== j) { h = i; return false } }) : this.each(function () { var g = b.data(this, a); g ? g.option(d || {})._init() : b.data(this, a, new c(d, this)) }); return h
        } 
    }; b.Widget = function (a, c) { arguments.length && this._createWidget(a, c) }; b.Widget.prototype = { widgetName: "widget", widgetEventPrefix: "", options: { disabled: false }, _createWidget: function (a, c) {
        b.data(c, this.widgetName, this); this.element = b(c); this.options = b.extend(true, {}, this.options,
this._getCreateOptions(), a); var d = this; this.element.bind("remove." + this.widgetName, function () { d.destroy() }); this._create(); this._trigger("create"); this._init()
    }, _getCreateOptions: function () { return b.metadata && b.metadata.get(this.element[0])[this.widgetName] }, _create: function () { }, _init: function () { }, destroy: function () { this.element.unbind("." + this.widgetName).removeData(this.widgetName); this.widget().unbind("." + this.widgetName).removeAttr("aria-disabled").removeClass(this.widgetBaseClass + "-disabled ui-state-disabled") },
        widget: function () { return this.element }, option: function (a, c) { var d = a; if (arguments.length === 0) return b.extend({}, this.options); if (typeof a === "string") { if (c === j) return this.options[a]; d = {}; d[a] = c } this._setOptions(d); return this }, _setOptions: function (a) { var c = this; b.each(a, function (d, e) { c._setOption(d, e) }); return this }, _setOption: function (a, c) { this.options[a] = c; if (a === "disabled") this.widget()[c ? "addClass" : "removeClass"](this.widgetBaseClass + "-disabled ui-state-disabled").attr("aria-disabled", c); return this },
        enable: function () { return this._setOption("disabled", false) }, disable: function () { return this._setOption("disabled", true) }, _trigger: function (a, c, d) { var e = this.options[a]; c = b.Event(c); c.type = (a === this.widgetEventPrefix ? a : this.widgetEventPrefix + a).toLowerCase(); d = d || {}; if (c.originalEvent) { a = b.event.props.length; for (var f; a; ) { f = b.event.props[--a]; c[f] = c.originalEvent[f] } } this.element.trigger(c, d); return !(b.isFunction(e) && e.call(this.element[0], c, d) === false || c.isDefaultPrevented()) } 
    }
})(jQuery);
; /*!
 * jQuery UI Mouse 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Mouse
 *
 * Depends:
 *	jquery.ui.widget.js
 */
(function (c) {
    c.widget("ui.mouse", { options: { cancel: ":input,option", distance: 1, delay: 0 }, _mouseInit: function () { var a = this; this.element.bind("mousedown." + this.widgetName, function (b) { return a._mouseDown(b) }).bind("click." + this.widgetName, function (b) { if (true === c.data(b.target, a.widgetName + ".preventClickEvent")) { c.removeData(b.target, a.widgetName + ".preventClickEvent"); b.stopImmediatePropagation(); return false } }); this.started = false }, _mouseDestroy: function () { this.element.unbind("." + this.widgetName) }, _mouseDown: function (a) {
        a.originalEvent =
a.originalEvent || {}; if (!a.originalEvent.mouseHandled) {
            this._mouseStarted && this._mouseUp(a); this._mouseDownEvent = a; var b = this, e = a.which == 1, f = typeof this.options.cancel == "string" ? c(a.target).parents().add(a.target).filter(this.options.cancel).length : false; if (!e || f || !this._mouseCapture(a)) return true; this.mouseDelayMet = !this.options.delay; if (!this.mouseDelayMet) this._mouseDelayTimer = setTimeout(function () { b.mouseDelayMet = true }, this.options.delay); if (this._mouseDistanceMet(a) && this._mouseDelayMet(a)) {
                this._mouseStarted =
this._mouseStart(a) !== false; if (!this._mouseStarted) { a.preventDefault(); return true } 
            } this._mouseMoveDelegate = function (d) { return b._mouseMove(d) }; this._mouseUpDelegate = function (d) { return b._mouseUp(d) }; c(document).bind("mousemove." + this.widgetName, this._mouseMoveDelegate).bind("mouseup." + this.widgetName, this._mouseUpDelegate); a.preventDefault(); return a.originalEvent.mouseHandled = true
        } 
    }, _mouseMove: function (a) {
        if (c.browser.msie && !(document.documentMode >= 9) && !a.button) return this._mouseUp(a); if (this._mouseStarted) {
            this._mouseDrag(a);
            return a.preventDefault()
        } if (this._mouseDistanceMet(a) && this._mouseDelayMet(a)) (this._mouseStarted = this._mouseStart(this._mouseDownEvent, a) !== false) ? this._mouseDrag(a) : this._mouseUp(a); return !this._mouseStarted
    }, _mouseUp: function (a) {
        c(document).unbind("mousemove." + this.widgetName, this._mouseMoveDelegate).unbind("mouseup." + this.widgetName, this._mouseUpDelegate); if (this._mouseStarted) {
            this._mouseStarted = false; a.target == this._mouseDownEvent.target && c.data(a.target, this.widgetName + ".preventClickEvent",
true); this._mouseStop(a)
        } return false
    }, _mouseDistanceMet: function (a) { return Math.max(Math.abs(this._mouseDownEvent.pageX - a.pageX), Math.abs(this._mouseDownEvent.pageY - a.pageY)) >= this.options.distance }, _mouseDelayMet: function () { return this.mouseDelayMet }, _mouseStart: function () { }, _mouseDrag: function () { }, _mouseStop: function () { }, _mouseCapture: function () { return true } 
    })
})(jQuery);
; /*
 * jQuery UI Position 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Position
 */
(function (c) {
    c.ui = c.ui || {}; var n = /left|center|right/, o = /top|center|bottom/, t = c.fn.position, u = c.fn.offset; c.fn.position = function (b) {
        if (!b || !b.of) return t.apply(this, arguments); b = c.extend({}, b); var a = c(b.of), d = a[0], g = (b.collision || "flip").split(" "), e = b.offset ? b.offset.split(" ") : [0, 0], h, k, j; if (d.nodeType === 9) { h = a.width(); k = a.height(); j = { top: 0, left: 0} } else if (d.setTimeout) { h = a.width(); k = a.height(); j = { top: a.scrollTop(), left: a.scrollLeft()} } else if (d.preventDefault) {
            b.at = "left top"; h = k = 0; j = { top: b.of.pageY,
                left: b.of.pageX
            }
        } else { h = a.outerWidth(); k = a.outerHeight(); j = a.offset() } c.each(["my", "at"], function () { var f = (b[this] || "").split(" "); if (f.length === 1) f = n.test(f[0]) ? f.concat(["center"]) : o.test(f[0]) ? ["center"].concat(f) : ["center", "center"]; f[0] = n.test(f[0]) ? f[0] : "center"; f[1] = o.test(f[1]) ? f[1] : "center"; b[this] = f }); if (g.length === 1) g[1] = g[0]; e[0] = parseInt(e[0], 10) || 0; if (e.length === 1) e[1] = e[0]; e[1] = parseInt(e[1], 10) || 0; if (b.at[0] === "right") j.left += h; else if (b.at[0] === "center") j.left += h / 2; if (b.at[1] === "bottom") j.top +=
k; else if (b.at[1] === "center") j.top += k / 2; j.left += e[0]; j.top += e[1]; return this.each(function () {
    var f = c(this), l = f.outerWidth(), m = f.outerHeight(), p = parseInt(c.curCSS(this, "marginLeft", true)) || 0, q = parseInt(c.curCSS(this, "marginTop", true)) || 0, v = l + p + parseInt(c.curCSS(this, "marginRight", true)) || 0, w = m + q + parseInt(c.curCSS(this, "marginBottom", true)) || 0, i = c.extend({}, j), r; if (b.my[0] === "right") i.left -= l; else if (b.my[0] === "center") i.left -= l / 2; if (b.my[1] === "bottom") i.top -= m; else if (b.my[1] === "center") i.top -= m / 2;
    i.left = Math.round(i.left); i.top = Math.round(i.top); r = { left: i.left - p, top: i.top - q }; c.each(["left", "top"], function (s, x) { c.ui.position[g[s]] && c.ui.position[g[s]][x](i, { targetWidth: h, targetHeight: k, elemWidth: l, elemHeight: m, collisionPosition: r, collisionWidth: v, collisionHeight: w, offset: e, my: b.my, at: b.at }) }); c.fn.bgiframe && f.bgiframe(); f.offset(c.extend(i, { using: b.using }))
})
    }; c.ui.position = { fit: { left: function (b, a) {
        var d = c(window); d = a.collisionPosition.left + a.collisionWidth - d.width() - d.scrollLeft(); b.left =
d > 0 ? b.left - d : Math.max(b.left - a.collisionPosition.left, b.left)
    }, top: function (b, a) { var d = c(window); d = a.collisionPosition.top + a.collisionHeight - d.height() - d.scrollTop(); b.top = d > 0 ? b.top - d : Math.max(b.top - a.collisionPosition.top, b.top) } 
    }, flip: { left: function (b, a) {
        if (a.at[0] !== "center") {
            var d = c(window); d = a.collisionPosition.left + a.collisionWidth - d.width() - d.scrollLeft(); var g = a.my[0] === "left" ? -a.elemWidth : a.my[0] === "right" ? a.elemWidth : 0, e = a.at[0] === "left" ? a.targetWidth : -a.targetWidth, h = -2 * a.offset[0]; b.left +=
a.collisionPosition.left < 0 ? g + e + h : d > 0 ? g + e + h : 0
        } 
    }, top: function (b, a) { if (a.at[1] !== "center") { var d = c(window); d = a.collisionPosition.top + a.collisionHeight - d.height() - d.scrollTop(); var g = a.my[1] === "top" ? -a.elemHeight : a.my[1] === "bottom" ? a.elemHeight : 0, e = a.at[1] === "top" ? a.targetHeight : -a.targetHeight, h = -2 * a.offset[1]; b.top += a.collisionPosition.top < 0 ? g + e + h : d > 0 ? g + e + h : 0 } } 
    }
    }; if (!c.offset.setOffset) {
        c.offset.setOffset = function (b, a) {
            if (/static/.test(c.curCSS(b, "position"))) b.style.position = "relative"; var d = c(b),
g = d.offset(), e = parseInt(c.curCSS(b, "top", true), 10) || 0, h = parseInt(c.curCSS(b, "left", true), 10) || 0; g = { top: a.top - g.top + e, left: a.left - g.left + h }; "using" in a ? a.using.call(b, g) : d.css(g)
        }; c.fn.offset = function (b) { var a = this[0]; if (!a || !a.ownerDocument) return null; if (b) return this.each(function () { c.offset.setOffset(this, b) }); return u.call(this) } 
    } 
})(jQuery);
; /*
 * jQuery UI Draggable 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Draggables
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.mouse.js
 *	jquery.ui.widget.js
 */
(function (d) {
    d.widget("ui.draggable", d.ui.mouse, { widgetEventPrefix: "drag", options: { addClasses: true, appendTo: "parent", axis: false, connectToSortable: false, containment: false, cursor: "auto", cursorAt: false, grid: false, handle: false, helper: "original", iframeFix: false, opacity: false, refreshPositions: false, revert: false, revertDuration: 500, scope: "default", scroll: true, scrollSensitivity: 20, scrollSpeed: 20, snap: false, snapMode: "both", snapTolerance: 20, stack: false, zIndex: false }, _create: function () {
        if (this.options.helper ==
"original" && !/^(?:r|a|f)/.test(this.element.css("position"))) this.element[0].style.position = "relative"; this.options.addClasses && this.element.addClass("ui-draggable"); this.options.disabled && this.element.addClass("ui-draggable-disabled"); this._mouseInit()
    }, destroy: function () { if (this.element.data("draggable")) { this.element.removeData("draggable").unbind(".draggable").removeClass("ui-draggable ui-draggable-dragging ui-draggable-disabled"); this._mouseDestroy(); return this } }, _mouseCapture: function (a) {
        var b =
this.options; if (this.helper || b.disabled || d(a.target).is(".ui-resizable-handle")) return false; this.handle = this._getHandle(a); if (!this.handle) return false; return true
    }, _mouseStart: function (a) {
        var b = this.options; this.helper = this._createHelper(a); this._cacheHelperProportions(); if (d.ui.ddmanager) d.ui.ddmanager.current = this; this._cacheMargins(); this.cssPosition = this.helper.css("position"); this.scrollParent = this.helper.scrollParent(); this.offset = this.positionAbs = this.element.offset(); this.offset = { top: this.offset.top -
this.margins.top, left: this.offset.left - this.margins.left
        }; d.extend(this.offset, { click: { left: a.pageX - this.offset.left, top: a.pageY - this.offset.top }, parent: this._getParentOffset(), relative: this._getRelativeOffset() }); this.originalPosition = this.position = this._generatePosition(a); this.originalPageX = a.pageX; this.originalPageY = a.pageY; b.cursorAt && this._adjustOffsetFromHelper(b.cursorAt); b.containment && this._setContainment(); if (this._trigger("start", a) === false) { this._clear(); return false } this._cacheHelperProportions();
        d.ui.ddmanager && !b.dropBehaviour && d.ui.ddmanager.prepareOffsets(this, a); this.helper.addClass("ui-draggable-dragging"); this._mouseDrag(a, true); return true
    }, _mouseDrag: function (a, b) {
        this.position = this._generatePosition(a); this.positionAbs = this._convertPositionTo("absolute"); if (!b) { b = this._uiHash(); if (this._trigger("drag", a, b) === false) { this._mouseUp({}); return false } this.position = b.position } if (!this.options.axis || this.options.axis != "y") this.helper[0].style.left = this.position.left + "px"; if (!this.options.axis ||
this.options.axis != "x") this.helper[0].style.top = this.position.top + "px"; d.ui.ddmanager && d.ui.ddmanager.drag(this, a); return false
    }, _mouseStop: function (a) {
        var b = false; if (d.ui.ddmanager && !this.options.dropBehaviour) b = d.ui.ddmanager.drop(this, a); if (this.dropped) { b = this.dropped; this.dropped = false } if (!this.element[0] || !this.element[0].parentNode) return false; if (this.options.revert == "invalid" && !b || this.options.revert == "valid" && b || this.options.revert === true || d.isFunction(this.options.revert) && this.options.revert.call(this.element,
b)) { var c = this; d(this.helper).animate(this.originalPosition, parseInt(this.options.revertDuration, 10), function () { c._trigger("stop", a) !== false && c._clear() }) } else this._trigger("stop", a) !== false && this._clear(); return false
    }, cancel: function () { this.helper.is(".ui-draggable-dragging") ? this._mouseUp({}) : this._clear(); return this }, _getHandle: function (a) {
        var b = !this.options.handle || !d(this.options.handle, this.element).length ? true : false; d(this.options.handle, this.element).find("*").andSelf().each(function () {
            if (this ==
a.target) b = true
        }); return b
    }, _createHelper: function (a) { var b = this.options; a = d.isFunction(b.helper) ? d(b.helper.apply(this.element[0], [a])) : b.helper == "clone" ? this.element.clone() : this.element; a.parents("body").length || a.appendTo(b.appendTo == "parent" ? this.element[0].parentNode : b.appendTo); a[0] != this.element[0] && !/(fixed|absolute)/.test(a.css("position")) && a.css("position", "absolute"); return a }, _adjustOffsetFromHelper: function (a) {
        if (typeof a == "string") a = a.split(" "); if (d.isArray(a)) a = { left: +a[0], top: +a[1] ||
0
        }; if ("left" in a) this.offset.click.left = a.left + this.margins.left; if ("right" in a) this.offset.click.left = this.helperProportions.width - a.right + this.margins.left; if ("top" in a) this.offset.click.top = a.top + this.margins.top; if ("bottom" in a) this.offset.click.top = this.helperProportions.height - a.bottom + this.margins.top
    }, _getParentOffset: function () {
        this.offsetParent = this.helper.offsetParent(); var a = this.offsetParent.offset(); if (this.cssPosition == "absolute" && this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0],
this.offsetParent[0])) { a.left += this.scrollParent.scrollLeft(); a.top += this.scrollParent.scrollTop() } if (this.offsetParent[0] == document.body || this.offsetParent[0].tagName && this.offsetParent[0].tagName.toLowerCase() == "html" && d.browser.msie) a = { top: 0, left: 0 }; return { top: a.top + (parseInt(this.offsetParent.css("borderTopWidth"), 10) || 0), left: a.left + (parseInt(this.offsetParent.css("borderLeftWidth"), 10) || 0)}
    }, _getRelativeOffset: function () {
        if (this.cssPosition == "relative") {
            var a = this.element.position(); return { top: a.top -
(parseInt(this.helper.css("top"), 10) || 0) + this.scrollParent.scrollTop(), left: a.left - (parseInt(this.helper.css("left"), 10) || 0) + this.scrollParent.scrollLeft()
            }
        } else return { top: 0, left: 0}
    }, _cacheMargins: function () { this.margins = { left: parseInt(this.element.css("marginLeft"), 10) || 0, top: parseInt(this.element.css("marginTop"), 10) || 0} }, _cacheHelperProportions: function () { this.helperProportions = { width: this.helper.outerWidth(), height: this.helper.outerHeight()} }, _setContainment: function () {
        var a = this.options; if (a.containment ==
"parent") a.containment = this.helper[0].parentNode; if (a.containment == "document" || a.containment == "window") this.containment = [(a.containment == "document" ? 0 : d(window).scrollLeft()) - this.offset.relative.left - this.offset.parent.left, (a.containment == "document" ? 0 : d(window).scrollTop()) - this.offset.relative.top - this.offset.parent.top, (a.containment == "document" ? 0 : d(window).scrollLeft()) + d(a.containment == "document" ? document : window).width() - this.helperProportions.width - this.margins.left, (a.containment == "document" ?
0 : d(window).scrollTop()) + (d(a.containment == "document" ? document : window).height() || document.body.parentNode.scrollHeight) - this.helperProportions.height - this.margins.top]; if (!/^(document|window|parent)$/.test(a.containment) && a.containment.constructor != Array) {
            var b = d(a.containment)[0]; if (b) {
                a = d(a.containment).offset(); var c = d(b).css("overflow") != "hidden"; this.containment = [a.left + (parseInt(d(b).css("borderLeftWidth"), 10) || 0) + (parseInt(d(b).css("paddingLeft"), 10) || 0) - this.margins.left, a.top + (parseInt(d(b).css("borderTopWidth"),
10) || 0) + (parseInt(d(b).css("paddingTop"), 10) || 0) - this.margins.top, a.left + (c ? Math.max(b.scrollWidth, b.offsetWidth) : b.offsetWidth) - (parseInt(d(b).css("borderLeftWidth"), 10) || 0) - (parseInt(d(b).css("paddingRight"), 10) || 0) - this.helperProportions.width - this.margins.left, a.top + (c ? Math.max(b.scrollHeight, b.offsetHeight) : b.offsetHeight) - (parseInt(d(b).css("borderTopWidth"), 10) || 0) - (parseInt(d(b).css("paddingBottom"), 10) || 0) - this.helperProportions.height - this.margins.top]
            } 
        } else if (a.containment.constructor ==
Array) this.containment = a.containment
    }, _convertPositionTo: function (a, b) {
        if (!b) b = this.position; a = a == "absolute" ? 1 : -1; var c = this.cssPosition == "absolute" && !(this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0], this.offsetParent[0])) ? this.offsetParent : this.scrollParent, f = /(html|body)/i.test(c[0].tagName); return { top: b.top + this.offset.relative.top * a + this.offset.parent.top * a - (d.browser.safari && d.browser.version < 526 && this.cssPosition == "fixed" ? 0 : (this.cssPosition == "fixed" ? -this.scrollParent.scrollTop() :
f ? 0 : c.scrollTop()) * a), left: b.left + this.offset.relative.left * a + this.offset.parent.left * a - (d.browser.safari && d.browser.version < 526 && this.cssPosition == "fixed" ? 0 : (this.cssPosition == "fixed" ? -this.scrollParent.scrollLeft() : f ? 0 : c.scrollLeft()) * a)
        }
    }, _generatePosition: function (a) {
        var b = this.options, c = this.cssPosition == "absolute" && !(this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0], this.offsetParent[0])) ? this.offsetParent : this.scrollParent, f = /(html|body)/i.test(c[0].tagName), e = a.pageX, g = a.pageY;
        if (this.originalPosition) {
            if (this.containment) { if (a.pageX - this.offset.click.left < this.containment[0]) e = this.containment[0] + this.offset.click.left; if (a.pageY - this.offset.click.top < this.containment[1]) g = this.containment[1] + this.offset.click.top; if (a.pageX - this.offset.click.left > this.containment[2]) e = this.containment[2] + this.offset.click.left; if (a.pageY - this.offset.click.top > this.containment[3]) g = this.containment[3] + this.offset.click.top } if (b.grid) {
                g = this.originalPageY + Math.round((g - this.originalPageY) /
b.grid[1]) * b.grid[1]; g = this.containment ? !(g - this.offset.click.top < this.containment[1] || g - this.offset.click.top > this.containment[3]) ? g : !(g - this.offset.click.top < this.containment[1]) ? g - b.grid[1] : g + b.grid[1] : g; e = this.originalPageX + Math.round((e - this.originalPageX) / b.grid[0]) * b.grid[0]; e = this.containment ? !(e - this.offset.click.left < this.containment[0] || e - this.offset.click.left > this.containment[2]) ? e : !(e - this.offset.click.left < this.containment[0]) ? e - b.grid[0] : e + b.grid[0] : e
            } 
        } return { top: g - this.offset.click.top -
this.offset.relative.top - this.offset.parent.top + (d.browser.safari && d.browser.version < 526 && this.cssPosition == "fixed" ? 0 : this.cssPosition == "fixed" ? -this.scrollParent.scrollTop() : f ? 0 : c.scrollTop()), left: e - this.offset.click.left - this.offset.relative.left - this.offset.parent.left + (d.browser.safari && d.browser.version < 526 && this.cssPosition == "fixed" ? 0 : this.cssPosition == "fixed" ? -this.scrollParent.scrollLeft() : f ? 0 : c.scrollLeft())
        }
    }, _clear: function () {
        this.helper.removeClass("ui-draggable-dragging"); this.helper[0] !=
this.element[0] && !this.cancelHelperRemoval && this.helper.remove(); this.helper = null; this.cancelHelperRemoval = false
    }, _trigger: function (a, b, c) { c = c || this._uiHash(); d.ui.plugin.call(this, a, [b, c]); if (a == "drag") this.positionAbs = this._convertPositionTo("absolute"); return d.Widget.prototype._trigger.call(this, a, b, c) }, plugins: {}, _uiHash: function () { return { helper: this.helper, position: this.position, originalPosition: this.originalPosition, offset: this.positionAbs} } 
    }); d.extend(d.ui.draggable, { version: "1.8.7" });
    d.ui.plugin.add("draggable", "connectToSortable", { start: function (a, b) { var c = d(this).data("draggable"), f = c.options, e = d.extend({}, b, { item: c.element }); c.sortables = []; d(f.connectToSortable).each(function () { var g = d.data(this, "sortable"); if (g && !g.options.disabled) { c.sortables.push({ instance: g, shouldRevert: g.options.revert }); g._refreshItems(); g._trigger("activate", a, e) } }) }, stop: function (a, b) {
        var c = d(this).data("draggable"), f = d.extend({}, b, { item: c.element }); d.each(c.sortables, function () {
            if (this.instance.isOver) {
                this.instance.isOver =
0; c.cancelHelperRemoval = true; this.instance.cancelHelperRemoval = false; if (this.shouldRevert) this.instance.options.revert = true; this.instance._mouseStop(a); this.instance.options.helper = this.instance.options._helper; c.options.helper == "original" && this.instance.currentItem.css({ top: "auto", left: "auto" })
            } else { this.instance.cancelHelperRemoval = false; this.instance._trigger("deactivate", a, f) } 
        })
    }, drag: function (a, b) {
        var c = d(this).data("draggable"), f = this; d.each(c.sortables, function () {
            this.instance.positionAbs =
c.positionAbs; this.instance.helperProportions = c.helperProportions; this.instance.offset.click = c.offset.click; if (this.instance._intersectsWith(this.instance.containerCache)) {
                if (!this.instance.isOver) {
                    this.instance.isOver = 1; this.instance.currentItem = d(f).clone().appendTo(this.instance.element).data("sortable-item", true); this.instance.options._helper = this.instance.options.helper; this.instance.options.helper = function () { return b.helper[0] }; a.target = this.instance.currentItem[0]; this.instance._mouseCapture(a,
true); this.instance._mouseStart(a, true, true); this.instance.offset.click.top = c.offset.click.top; this.instance.offset.click.left = c.offset.click.left; this.instance.offset.parent.left -= c.offset.parent.left - this.instance.offset.parent.left; this.instance.offset.parent.top -= c.offset.parent.top - this.instance.offset.parent.top; c._trigger("toSortable", a); c.dropped = this.instance.element; c.currentItem = c.element; this.instance.fromOutside = c
                } this.instance.currentItem && this.instance._mouseDrag(a)
            } else if (this.instance.isOver) {
                this.instance.isOver =
0; this.instance.cancelHelperRemoval = true; this.instance.options.revert = false; this.instance._trigger("out", a, this.instance._uiHash(this.instance)); this.instance._mouseStop(a, true); this.instance.options.helper = this.instance.options._helper; this.instance.currentItem.remove(); this.instance.placeholder && this.instance.placeholder.remove(); c._trigger("fromSortable", a); c.dropped = false
            } 
        })
    } 
    }); d.ui.plugin.add("draggable", "cursor", { start: function () {
        var a = d("body"), b = d(this).data("draggable").options; if (a.css("cursor")) b._cursor =
a.css("cursor"); a.css("cursor", b.cursor)
    }, stop: function () { var a = d(this).data("draggable").options; a._cursor && d("body").css("cursor", a._cursor) } 
    }); d.ui.plugin.add("draggable", "iframeFix", { start: function () { var a = d(this).data("draggable").options; d(a.iframeFix === true ? "iframe" : a.iframeFix).each(function () { d('<div class="ui-draggable-iframeFix" style="background: #fff;"></div>').css({ width: this.offsetWidth + "px", height: this.offsetHeight + "px", position: "absolute", opacity: "0.001", zIndex: 1E3 }).css(d(this).offset()).appendTo("body") }) },
        stop: function () { d("div.ui-draggable-iframeFix").each(function () { this.parentNode.removeChild(this) }) } 
    }); d.ui.plugin.add("draggable", "opacity", { start: function (a, b) { a = d(b.helper); b = d(this).data("draggable").options; if (a.css("opacity")) b._opacity = a.css("opacity"); a.css("opacity", b.opacity) }, stop: function (a, b) { a = d(this).data("draggable").options; a._opacity && d(b.helper).css("opacity", a._opacity) } }); d.ui.plugin.add("draggable", "scroll", { start: function () {
        var a = d(this).data("draggable"); if (a.scrollParent[0] !=
document && a.scrollParent[0].tagName != "HTML") a.overflowOffset = a.scrollParent.offset()
    }, drag: function (a) {
        var b = d(this).data("draggable"), c = b.options, f = false; if (b.scrollParent[0] != document && b.scrollParent[0].tagName != "HTML") {
            if (!c.axis || c.axis != "x") if (b.overflowOffset.top + b.scrollParent[0].offsetHeight - a.pageY < c.scrollSensitivity) b.scrollParent[0].scrollTop = f = b.scrollParent[0].scrollTop + c.scrollSpeed; else if (a.pageY - b.overflowOffset.top < c.scrollSensitivity) b.scrollParent[0].scrollTop = f = b.scrollParent[0].scrollTop -
c.scrollSpeed; if (!c.axis || c.axis != "y") if (b.overflowOffset.left + b.scrollParent[0].offsetWidth - a.pageX < c.scrollSensitivity) b.scrollParent[0].scrollLeft = f = b.scrollParent[0].scrollLeft + c.scrollSpeed; else if (a.pageX - b.overflowOffset.left < c.scrollSensitivity) b.scrollParent[0].scrollLeft = f = b.scrollParent[0].scrollLeft - c.scrollSpeed
        } else {
            if (!c.axis || c.axis != "x") if (a.pageY - d(document).scrollTop() < c.scrollSensitivity) f = d(document).scrollTop(d(document).scrollTop() - c.scrollSpeed); else if (d(window).height() -
(a.pageY - d(document).scrollTop()) < c.scrollSensitivity) f = d(document).scrollTop(d(document).scrollTop() + c.scrollSpeed); if (!c.axis || c.axis != "y") if (a.pageX - d(document).scrollLeft() < c.scrollSensitivity) f = d(document).scrollLeft(d(document).scrollLeft() - c.scrollSpeed); else if (d(window).width() - (a.pageX - d(document).scrollLeft()) < c.scrollSensitivity) f = d(document).scrollLeft(d(document).scrollLeft() + c.scrollSpeed)
        } f !== false && d.ui.ddmanager && !c.dropBehaviour && d.ui.ddmanager.prepareOffsets(b, a)
    } 
    }); d.ui.plugin.add("draggable",
"snap", { start: function () { var a = d(this).data("draggable"), b = a.options; a.snapElements = []; d(b.snap.constructor != String ? b.snap.items || ":data(draggable)" : b.snap).each(function () { var c = d(this), f = c.offset(); this != a.element[0] && a.snapElements.push({ item: this, width: c.outerWidth(), height: c.outerHeight(), top: f.top, left: f.left }) }) }, drag: function (a, b) {
    for (var c = d(this).data("draggable"), f = c.options, e = f.snapTolerance, g = b.offset.left, n = g + c.helperProportions.width, m = b.offset.top, o = m + c.helperProportions.height, h =
c.snapElements.length - 1; h >= 0; h--) {
        var i = c.snapElements[h].left, k = i + c.snapElements[h].width, j = c.snapElements[h].top, l = j + c.snapElements[h].height; if (i - e < g && g < k + e && j - e < m && m < l + e || i - e < g && g < k + e && j - e < o && o < l + e || i - e < n && n < k + e && j - e < m && m < l + e || i - e < n && n < k + e && j - e < o && o < l + e) {
            if (f.snapMode != "inner") {
                var p = Math.abs(j - o) <= e, q = Math.abs(l - m) <= e, r = Math.abs(i - n) <= e, s = Math.abs(k - g) <= e; if (p) b.position.top = c._convertPositionTo("relative", { top: j - c.helperProportions.height, left: 0 }).top - c.margins.top; if (q) b.position.top = c._convertPositionTo("relative",
{ top: l, left: 0 }).top - c.margins.top; if (r) b.position.left = c._convertPositionTo("relative", { top: 0, left: i - c.helperProportions.width }).left - c.margins.left; if (s) b.position.left = c._convertPositionTo("relative", { top: 0, left: k }).left - c.margins.left
            } var t = p || q || r || s; if (f.snapMode != "outer") {
                p = Math.abs(j - m) <= e; q = Math.abs(l - o) <= e; r = Math.abs(i - g) <= e; s = Math.abs(k - n) <= e; if (p) b.position.top = c._convertPositionTo("relative", { top: j, left: 0 }).top - c.margins.top; if (q) b.position.top = c._convertPositionTo("relative", { top: l - c.helperProportions.height,
                    left: 0
                }).top - c.margins.top; if (r) b.position.left = c._convertPositionTo("relative", { top: 0, left: i }).left - c.margins.left; if (s) b.position.left = c._convertPositionTo("relative", { top: 0, left: k - c.helperProportions.width }).left - c.margins.left
            } if (!c.snapElements[h].snapping && (p || q || r || s || t)) c.options.snap.snap && c.options.snap.snap.call(c.element, a, d.extend(c._uiHash(), { snapItem: c.snapElements[h].item })); c.snapElements[h].snapping = p || q || r || s || t
        } else {
            c.snapElements[h].snapping && c.options.snap.release && c.options.snap.release.call(c.element,
a, d.extend(c._uiHash(), { snapItem: c.snapElements[h].item })); c.snapElements[h].snapping = false
        } 
    } 
} 
}); d.ui.plugin.add("draggable", "stack", { start: function () { var a = d(this).data("draggable").options; a = d.makeArray(d(a.stack)).sort(function (c, f) { return (parseInt(d(c).css("zIndex"), 10) || 0) - (parseInt(d(f).css("zIndex"), 10) || 0) }); if (a.length) { var b = parseInt(a[0].style.zIndex) || 0; d(a).each(function (c) { this.style.zIndex = b + c }); this[0].style.zIndex = b + a.length } } }); d.ui.plugin.add("draggable", "zIndex", { start: function (a,
b) { a = d(b.helper); b = d(this).data("draggable").options; if (a.css("zIndex")) b._zIndex = a.css("zIndex"); a.css("zIndex", b.zIndex) }, stop: function (a, b) { a = d(this).data("draggable").options; a._zIndex && d(b.helper).css("zIndex", a._zIndex) } 
})
})(jQuery);
; /*
 * jQuery UI Droppable 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Droppables
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 *	jquery.ui.mouse.js
 *	jquery.ui.draggable.js
 */
(function (d) {
    d.widget("ui.droppable", { widgetEventPrefix: "drop", options: { accept: "*", activeClass: false, addClasses: true, greedy: false, hoverClass: false, scope: "default", tolerance: "intersect" }, _create: function () {
        var a = this.options, b = a.accept; this.isover = 0; this.isout = 1; this.accept = d.isFunction(b) ? b : function (c) { return c.is(b) }; this.proportions = { width: this.element[0].offsetWidth, height: this.element[0].offsetHeight }; d.ui.ddmanager.droppables[a.scope] = d.ui.ddmanager.droppables[a.scope] || []; d.ui.ddmanager.droppables[a.scope].push(this);
        a.addClasses && this.element.addClass("ui-droppable")
    }, destroy: function () { for (var a = d.ui.ddmanager.droppables[this.options.scope], b = 0; b < a.length; b++) a[b] == this && a.splice(b, 1); this.element.removeClass("ui-droppable ui-droppable-disabled").removeData("droppable").unbind(".droppable"); return this }, _setOption: function (a, b) { if (a == "accept") this.accept = d.isFunction(b) ? b : function (c) { return c.is(b) }; d.Widget.prototype._setOption.apply(this, arguments) }, _activate: function (a) {
        var b = d.ui.ddmanager.current; this.options.activeClass &&
this.element.addClass(this.options.activeClass); b && this._trigger("activate", a, this.ui(b))
    }, _deactivate: function (a) { var b = d.ui.ddmanager.current; this.options.activeClass && this.element.removeClass(this.options.activeClass); b && this._trigger("deactivate", a, this.ui(b)) }, _over: function (a) {
        var b = d.ui.ddmanager.current; if (!(!b || (b.currentItem || b.element)[0] == this.element[0])) if (this.accept.call(this.element[0], b.currentItem || b.element)) {
            this.options.hoverClass && this.element.addClass(this.options.hoverClass);
            this._trigger("over", a, this.ui(b))
        } 
    }, _out: function (a) { var b = d.ui.ddmanager.current; if (!(!b || (b.currentItem || b.element)[0] == this.element[0])) if (this.accept.call(this.element[0], b.currentItem || b.element)) { this.options.hoverClass && this.element.removeClass(this.options.hoverClass); this._trigger("out", a, this.ui(b)) } }, _drop: function (a, b) {
        var c = b || d.ui.ddmanager.current; if (!c || (c.currentItem || c.element)[0] == this.element[0]) return false; var e = false; this.element.find(":data(droppable)").not(".ui-draggable-dragging").each(function () {
            var g =
d.data(this, "droppable"); if (g.options.greedy && !g.options.disabled && g.options.scope == c.options.scope && g.accept.call(g.element[0], c.currentItem || c.element) && d.ui.intersect(c, d.extend(g, { offset: g.element.offset() }), g.options.tolerance)) { e = true; return false } 
        }); if (e) return false; if (this.accept.call(this.element[0], c.currentItem || c.element)) {
            this.options.activeClass && this.element.removeClass(this.options.activeClass); this.options.hoverClass && this.element.removeClass(this.options.hoverClass); this._trigger("drop",
a, this.ui(c)); return this.element
        } return false
    }, ui: function (a) { return { draggable: a.currentItem || a.element, helper: a.helper, position: a.position, offset: a.positionAbs} } 
    }); d.extend(d.ui.droppable, { version: "1.8.7" }); d.ui.intersect = function (a, b, c) {
        if (!b.offset) return false; var e = (a.positionAbs || a.position.absolute).left, g = e + a.helperProportions.width, f = (a.positionAbs || a.position.absolute).top, h = f + a.helperProportions.height, i = b.offset.left, k = i + b.proportions.width, j = b.offset.top, l = j + b.proportions.height;
        switch (c) {
            case "fit": return i <= e && g <= k && j <= f && h <= l; case "intersect": return i < e + a.helperProportions.width / 2 && g - a.helperProportions.width / 2 < k && j < f + a.helperProportions.height / 2 && h - a.helperProportions.height / 2 < l; case "pointer": return d.ui.isOver((a.positionAbs || a.position.absolute).top + (a.clickOffset || a.offset.click).top, (a.positionAbs || a.position.absolute).left + (a.clickOffset || a.offset.click).left, j, i, b.proportions.height, b.proportions.width); case "touch": return (f >= j && f <= l || h >= j && h <= l || f < j && h > l) && (e >=
i && e <= k || g >= i && g <= k || e < i && g > k); default: return false
        } 
    }; d.ui.ddmanager = { current: null, droppables: { "default": [] }, prepareOffsets: function (a, b) {
        var c = d.ui.ddmanager.droppables[a.options.scope] || [], e = b ? b.type : null, g = (a.currentItem || a.element).find(":data(droppable)").andSelf(), f = 0; a: for (; f < c.length; f++) if (!(c[f].options.disabled || a && !c[f].accept.call(c[f].element[0], a.currentItem || a.element))) {
            for (var h = 0; h < g.length; h++) if (g[h] == c[f].element[0]) { c[f].proportions.height = 0; continue a } c[f].visible = c[f].element.css("display") !=
"none"; if (c[f].visible) { c[f].offset = c[f].element.offset(); c[f].proportions = { width: c[f].element[0].offsetWidth, height: c[f].element[0].offsetHeight }; e == "mousedown" && c[f]._activate.call(c[f], b) } 
        } 
    }, drop: function (a, b) {
        var c = false; d.each(d.ui.ddmanager.droppables[a.options.scope] || [], function () {
            if (this.options) {
                if (!this.options.disabled && this.visible && d.ui.intersect(a, this, this.options.tolerance)) c = c || this._drop.call(this, b); if (!this.options.disabled && this.visible && this.accept.call(this.element[0], a.currentItem ||
a.element)) { this.isout = 1; this.isover = 0; this._deactivate.call(this, b) } 
            } 
        }); return c
    }, drag: function (a, b) {
        a.options.refreshPositions && d.ui.ddmanager.prepareOffsets(a, b); d.each(d.ui.ddmanager.droppables[a.options.scope] || [], function () {
            if (!(this.options.disabled || this.greedyChild || !this.visible)) {
                var c = d.ui.intersect(a, this, this.options.tolerance); if (c = !c && this.isover == 1 ? "isout" : c && this.isover == 0 ? "isover" : null) {
                    var e; if (this.options.greedy) {
                        var g = this.element.parents(":data(droppable):eq(0)"); if (g.length) {
                            e =
d.data(g[0], "droppable"); e.greedyChild = c == "isover" ? 1 : 0
                        } 
                    } if (e && c == "isover") { e.isover = 0; e.isout = 1; e._out.call(e, b) } this[c] = 1; this[c == "isout" ? "isover" : "isout"] = 0; this[c == "isover" ? "_over" : "_out"].call(this, b); if (e && c == "isout") { e.isout = 0; e.isover = 1; e._over.call(e, b) } 
                } 
            } 
        })
    } 
    }
})(jQuery);
; /*
 * jQuery UI Resizable 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Resizables
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.mouse.js
 *	jquery.ui.widget.js
 */
(function (e) {
    e.widget("ui.resizable", e.ui.mouse, { widgetEventPrefix: "resize", options: { alsoResize: false, animate: false, animateDuration: "slow", animateEasing: "swing", aspectRatio: false, autoHide: false, containment: false, ghost: false, grid: false, handles: "e,s,se", helper: false, maxHeight: null, maxWidth: null, minHeight: 10, minWidth: 10, zIndex: 1E3 }, _create: function () {
        var b = this, a = this.options; this.element.addClass("ui-resizable"); e.extend(this, { _aspectRatio: !!a.aspectRatio, aspectRatio: a.aspectRatio, originalElement: this.element,
            _proportionallyResizeElements: [], _helper: a.helper || a.ghost || a.animate ? a.helper || "ui-resizable-helper" : null
        }); if (this.element[0].nodeName.match(/canvas|textarea|input|select|button|img/i)) {
            /relative/.test(this.element.css("position")) && e.browser.opera && this.element.css({ position: "relative", top: "auto", left: "auto" }); this.element.wrap(e('<div class="ui-wrapper" style="overflow: hidden;"></div>').css({ position: this.element.css("position"), width: this.element.outerWidth(), height: this.element.outerHeight(),
                top: this.element.css("top"), left: this.element.css("left")
            })); this.element = this.element.parent().data("resizable", this.element.data("resizable")); this.elementIsWrapper = true; this.element.css({ marginLeft: this.originalElement.css("marginLeft"), marginTop: this.originalElement.css("marginTop"), marginRight: this.originalElement.css("marginRight"), marginBottom: this.originalElement.css("marginBottom") }); this.originalElement.css({ marginLeft: 0, marginTop: 0, marginRight: 0, marginBottom: 0 }); this.originalResizeStyle =
this.originalElement.css("resize"); this.originalElement.css("resize", "none"); this._proportionallyResizeElements.push(this.originalElement.css({ position: "static", zoom: 1, display: "block" })); this.originalElement.css({ margin: this.originalElement.css("margin") }); this._proportionallyResize()
        } this.handles = a.handles || (!e(".ui-resizable-handle", this.element).length ? "e,s,se" : { n: ".ui-resizable-n", e: ".ui-resizable-e", s: ".ui-resizable-s", w: ".ui-resizable-w", se: ".ui-resizable-se", sw: ".ui-resizable-sw", ne: ".ui-resizable-ne",
            nw: ".ui-resizable-nw"
        }); if (this.handles.constructor == String) { if (this.handles == "all") this.handles = "n,e,s,w,se,sw,ne,nw"; var c = this.handles.split(","); this.handles = {}; for (var d = 0; d < c.length; d++) { var f = e.trim(c[d]), g = e('<div class="ui-resizable-handle ' + ("ui-resizable-" + f) + '"></div>'); /sw|se|ne|nw/.test(f) && g.css({ zIndex: ++a.zIndex }); "se" == f && g.addClass("ui-icon ui-icon-gripsmall-diagonal-se"); this.handles[f] = ".ui-resizable-" + f; this.element.append(g) } } this._renderAxis = function (h) {
            h = h || this.element; for (var i in this.handles) {
                if (this.handles[i].constructor ==
String) this.handles[i] = e(this.handles[i], this.element).show(); if (this.elementIsWrapper && this.originalElement[0].nodeName.match(/textarea|input|select|button/i)) { var j = e(this.handles[i], this.element), k = 0; k = /sw|ne|nw|se|n|s/.test(i) ? j.outerHeight() : j.outerWidth(); j = ["padding", /ne|nw|n/.test(i) ? "Top" : /se|sw|s/.test(i) ? "Bottom" : /^e$/.test(i) ? "Right" : "Left"].join(""); h.css(j, k); this._proportionallyResize() } e(this.handles[i])
            } 
        }; this._renderAxis(this.element); this._handles = e(".ui-resizable-handle", this.element).disableSelection();
        this._handles.mouseover(function () { if (!b.resizing) { if (this.className) var h = this.className.match(/ui-resizable-(se|sw|ne|nw|n|e|s|w)/i); b.axis = h && h[1] ? h[1] : "se" } }); if (a.autoHide) { this._handles.hide(); e(this.element).addClass("ui-resizable-autohide").hover(function () { e(this).removeClass("ui-resizable-autohide"); b._handles.show() }, function () { if (!b.resizing) { e(this).addClass("ui-resizable-autohide"); b._handles.hide() } }) } this._mouseInit()
    }, destroy: function () {
        this._mouseDestroy(); var b = function (c) { e(c).removeClass("ui-resizable ui-resizable-disabled ui-resizable-resizing").removeData("resizable").unbind(".resizable").find(".ui-resizable-handle").remove() };
        if (this.elementIsWrapper) { b(this.element); var a = this.element; a.after(this.originalElement.css({ position: a.css("position"), width: a.outerWidth(), height: a.outerHeight(), top: a.css("top"), left: a.css("left") })).remove() } this.originalElement.css("resize", this.originalResizeStyle); b(this.originalElement); return this
    }, _mouseCapture: function (b) { var a = false; for (var c in this.handles) if (e(this.handles[c])[0] == b.target) a = true; return !this.options.disabled && a }, _mouseStart: function (b) {
        var a = this.options, c = this.element.position(),
d = this.element; this.resizing = true; this.documentScroll = { top: e(document).scrollTop(), left: e(document).scrollLeft() }; if (d.is(".ui-draggable") || /absolute/.test(d.css("position"))) d.css({ position: "absolute", top: c.top, left: c.left }); e.browser.opera && /relative/.test(d.css("position")) && d.css({ position: "relative", top: "auto", left: "auto" }); this._renderProxy(); c = m(this.helper.css("left")); var f = m(this.helper.css("top")); if (a.containment) { c += e(a.containment).scrollLeft() || 0; f += e(a.containment).scrollTop() || 0 } this.offset =
this.helper.offset(); this.position = { left: c, top: f }; this.size = this._helper ? { width: d.outerWidth(), height: d.outerHeight()} : { width: d.width(), height: d.height() }; this.originalSize = this._helper ? { width: d.outerWidth(), height: d.outerHeight()} : { width: d.width(), height: d.height() }; this.originalPosition = { left: c, top: f }; this.sizeDiff = { width: d.outerWidth() - d.width(), height: d.outerHeight() - d.height() }; this.originalMousePosition = { left: b.pageX, top: b.pageY }; this.aspectRatio = typeof a.aspectRatio == "number" ? a.aspectRatio :
this.originalSize.width / this.originalSize.height || 1; a = e(".ui-resizable-" + this.axis).css("cursor"); e("body").css("cursor", a == "auto" ? this.axis + "-resize" : a); d.addClass("ui-resizable-resizing"); this._propagate("start", b); return true
    }, _mouseDrag: function (b) {
        var a = this.helper, c = this.originalMousePosition, d = this._change[this.axis]; if (!d) return false; c = d.apply(this, [b, b.pageX - c.left || 0, b.pageY - c.top || 0]); if (this._aspectRatio || b.shiftKey) c = this._updateRatio(c, b); c = this._respectSize(c, b); this._propagate("resize",
b); a.css({ top: this.position.top + "px", left: this.position.left + "px", width: this.size.width + "px", height: this.size.height + "px" }); !this._helper && this._proportionallyResizeElements.length && this._proportionallyResize(); this._updateCache(c); this._trigger("resize", b, this.ui()); return false
    }, _mouseStop: function (b) {
        this.resizing = false; var a = this.options, c = this; if (this._helper) {
            var d = this._proportionallyResizeElements, f = d.length && /textarea/i.test(d[0].nodeName); d = f && e.ui.hasScroll(d[0], "left") ? 0 : c.sizeDiff.height;
            f = { width: c.size.width - (f ? 0 : c.sizeDiff.width), height: c.size.height - d }; d = parseInt(c.element.css("left"), 10) + (c.position.left - c.originalPosition.left) || null; var g = parseInt(c.element.css("top"), 10) + (c.position.top - c.originalPosition.top) || null; a.animate || this.element.css(e.extend(f, { top: g, left: d })); c.helper.height(c.size.height); c.helper.width(c.size.width); this._helper && !a.animate && this._proportionallyResize()
        } e("body").css("cursor", "auto"); this.element.removeClass("ui-resizable-resizing"); this._propagate("stop",
b); this._helper && this.helper.remove(); return false
    }, _updateCache: function (b) { this.offset = this.helper.offset(); if (l(b.left)) this.position.left = b.left; if (l(b.top)) this.position.top = b.top; if (l(b.height)) this.size.height = b.height; if (l(b.width)) this.size.width = b.width }, _updateRatio: function (b) {
        var a = this.position, c = this.size, d = this.axis; if (b.height) b.width = c.height * this.aspectRatio; else if (b.width) b.height = c.width / this.aspectRatio; if (d == "sw") { b.left = a.left + (c.width - b.width); b.top = null } if (d == "nw") {
            b.top =
a.top + (c.height - b.height); b.left = a.left + (c.width - b.width)
        } return b
    }, _respectSize: function (b) {
        var a = this.options, c = this.axis, d = l(b.width) && a.maxWidth && a.maxWidth < b.width, f = l(b.height) && a.maxHeight && a.maxHeight < b.height, g = l(b.width) && a.minWidth && a.minWidth > b.width, h = l(b.height) && a.minHeight && a.minHeight > b.height; if (g) b.width = a.minWidth; if (h) b.height = a.minHeight; if (d) b.width = a.maxWidth; if (f) b.height = a.maxHeight; var i = this.originalPosition.left + this.originalSize.width, j = this.position.top + this.size.height,
k = /sw|nw|w/.test(c); c = /nw|ne|n/.test(c); if (g && k) b.left = i - a.minWidth; if (d && k) b.left = i - a.maxWidth; if (h && c) b.top = j - a.minHeight; if (f && c) b.top = j - a.maxHeight; if ((a = !b.width && !b.height) && !b.left && b.top) b.top = null; else if (a && !b.top && b.left) b.left = null; return b
    }, _proportionallyResize: function () {
        if (this._proportionallyResizeElements.length) for (var b = this.helper || this.element, a = 0; a < this._proportionallyResizeElements.length; a++) {
            var c = this._proportionallyResizeElements[a]; if (!this.borderDif) {
                var d = [c.css("borderTopWidth"),
c.css("borderRightWidth"), c.css("borderBottomWidth"), c.css("borderLeftWidth")], f = [c.css("paddingTop"), c.css("paddingRight"), c.css("paddingBottom"), c.css("paddingLeft")]; this.borderDif = e.map(d, function (g, h) { g = parseInt(g, 10) || 0; h = parseInt(f[h], 10) || 0; return g + h })
            } e.browser.msie && (e(b).is(":hidden") || e(b).parents(":hidden").length) || c.css({ height: b.height() - this.borderDif[0] - this.borderDif[2] || 0, width: b.width() - this.borderDif[1] - this.borderDif[3] || 0 })
        } 
    }, _renderProxy: function () {
        var b = this.options; this.elementOffset =
this.element.offset(); if (this._helper) { this.helper = this.helper || e('<div style="overflow:hidden;"></div>'); var a = e.browser.msie && e.browser.version < 7, c = a ? 1 : 0; a = a ? 2 : -1; this.helper.addClass(this._helper).css({ width: this.element.outerWidth() + a, height: this.element.outerHeight() + a, position: "absolute", left: this.elementOffset.left - c + "px", top: this.elementOffset.top - c + "px", zIndex: ++b.zIndex }); this.helper.appendTo("body").disableSelection() } else this.helper = this.element
    }, _change: { e: function (b, a) {
        return { width: this.originalSize.width +
a
        }
    }, w: function (b, a) { return { left: this.originalPosition.left + a, width: this.originalSize.width - a} }, n: function (b, a, c) { return { top: this.originalPosition.top + c, height: this.originalSize.height - c} }, s: function (b, a, c) { return { height: this.originalSize.height + c} }, se: function (b, a, c) { return e.extend(this._change.s.apply(this, arguments), this._change.e.apply(this, [b, a, c])) }, sw: function (b, a, c) { return e.extend(this._change.s.apply(this, arguments), this._change.w.apply(this, [b, a, c])) }, ne: function (b, a, c) {
        return e.extend(this._change.n.apply(this,
arguments), this._change.e.apply(this, [b, a, c]))
    }, nw: function (b, a, c) { return e.extend(this._change.n.apply(this, arguments), this._change.w.apply(this, [b, a, c])) } 
    }, _propagate: function (b, a) { e.ui.plugin.call(this, b, [a, this.ui()]); b != "resize" && this._trigger(b, a, this.ui()) }, plugins: {}, ui: function () { return { originalElement: this.originalElement, element: this.element, helper: this.helper, position: this.position, size: this.size, originalSize: this.originalSize, originalPosition: this.originalPosition} } 
    }); e.extend(e.ui.resizable,
{ version: "1.8.7" }); e.ui.plugin.add("resizable", "alsoResize", { start: function () {
    var b = e(this).data("resizable").options, a = function (c) { e(c).each(function () { var d = e(this); d.data("resizable-alsoresize", { width: parseInt(d.width(), 10), height: parseInt(d.height(), 10), left: parseInt(d.css("left"), 10), top: parseInt(d.css("top"), 10), position: d.css("position") }) }) }; if (typeof b.alsoResize == "object" && !b.alsoResize.parentNode) if (b.alsoResize.length) { b.alsoResize = b.alsoResize[0]; a(b.alsoResize) } else e.each(b.alsoResize,
function (c) { a(c) }); else a(b.alsoResize)
}, resize: function (b, a) {
    var c = e(this).data("resizable"); b = c.options; var d = c.originalSize, f = c.originalPosition, g = { height: c.size.height - d.height || 0, width: c.size.width - d.width || 0, top: c.position.top - f.top || 0, left: c.position.left - f.left || 0 }, h = function (i, j) {
        e(i).each(function () {
            var k = e(this), q = e(this).data("resizable-alsoresize"), p = {}, r = j && j.length ? j : k.parents(a.originalElement[0]).length ? ["width", "height"] : ["width", "height", "top", "left"]; e.each(r, function (n, o) {
                if ((n =
(q[o] || 0) + (g[o] || 0)) && n >= 0) p[o] = n || null
            }); if (e.browser.opera && /relative/.test(k.css("position"))) { c._revertToRelativePosition = true; k.css({ position: "absolute", top: "auto", left: "auto" }) } k.css(p)
        })
    }; typeof b.alsoResize == "object" && !b.alsoResize.nodeType ? e.each(b.alsoResize, function (i, j) { h(i, j) }) : h(b.alsoResize)
}, stop: function () {
    var b = e(this).data("resizable"), a = b.options, c = function (d) { e(d).each(function () { var f = e(this); f.css({ position: f.data("resizable-alsoresize").position }) }) }; if (b._revertToRelativePosition) {
        b._revertToRelativePosition =
false; typeof a.alsoResize == "object" && !a.alsoResize.nodeType ? e.each(a.alsoResize, function (d) { c(d) }) : c(a.alsoResize)
    } e(this).removeData("resizable-alsoresize")
} 
}); e.ui.plugin.add("resizable", "animate", { stop: function (b) {
    var a = e(this).data("resizable"), c = a.options, d = a._proportionallyResizeElements, f = d.length && /textarea/i.test(d[0].nodeName), g = f && e.ui.hasScroll(d[0], "left") ? 0 : a.sizeDiff.height; f = { width: a.size.width - (f ? 0 : a.sizeDiff.width), height: a.size.height - g }; g = parseInt(a.element.css("left"), 10) + (a.position.left -
a.originalPosition.left) || null; var h = parseInt(a.element.css("top"), 10) + (a.position.top - a.originalPosition.top) || null; a.element.animate(e.extend(f, h && g ? { top: h, left: g} : {}), { duration: c.animateDuration, easing: c.animateEasing, step: function () {
    var i = { width: parseInt(a.element.css("width"), 10), height: parseInt(a.element.css("height"), 10), top: parseInt(a.element.css("top"), 10), left: parseInt(a.element.css("left"), 10) }; d && d.length && e(d[0]).css({ width: i.width, height: i.height }); a._updateCache(i); a._propagate("resize",
b)
} 
})
} 
}); e.ui.plugin.add("resizable", "containment", { start: function () {
    var b = e(this).data("resizable"), a = b.element, c = b.options.containment; if (a = c instanceof e ? c.get(0) : /parent/.test(c) ? a.parent().get(0) : c) {
        b.containerElement = e(a); if (/document/.test(c) || c == document) { b.containerOffset = { left: 0, top: 0 }; b.containerPosition = { left: 0, top: 0 }; b.parentData = { element: e(document), left: 0, top: 0, width: e(document).width(), height: e(document).height() || document.body.parentNode.scrollHeight} } else {
            var d = e(a), f = []; e(["Top",
"Right", "Left", "Bottom"]).each(function (i, j) { f[i] = m(d.css("padding" + j)) }); b.containerOffset = d.offset(); b.containerPosition = d.position(); b.containerSize = { height: d.innerHeight() - f[3], width: d.innerWidth() - f[1] }; c = b.containerOffset; var g = b.containerSize.height, h = b.containerSize.width; h = e.ui.hasScroll(a, "left") ? a.scrollWidth : h; g = e.ui.hasScroll(a) ? a.scrollHeight : g; b.parentData = { element: a, left: c.left, top: c.top, width: h, height: g}
        } 
    } 
}, resize: function (b) {
    var a = e(this).data("resizable"), c = a.options, d = a.containerOffset,
f = a.position; b = a._aspectRatio || b.shiftKey; var g = { top: 0, left: 0 }, h = a.containerElement; if (h[0] != document && /static/.test(h.css("position"))) g = d; if (f.left < (a._helper ? d.left : 0)) { a.size.width += a._helper ? a.position.left - d.left : a.position.left - g.left; if (b) a.size.height = a.size.width / c.aspectRatio; a.position.left = c.helper ? d.left : 0 } if (f.top < (a._helper ? d.top : 0)) { a.size.height += a._helper ? a.position.top - d.top : a.position.top; if (b) a.size.width = a.size.height * c.aspectRatio; a.position.top = a._helper ? d.top : 0 } a.offset.left =
a.parentData.left + a.position.left; a.offset.top = a.parentData.top + a.position.top; c = Math.abs((a._helper ? a.offset.left - g.left : a.offset.left - g.left) + a.sizeDiff.width); d = Math.abs((a._helper ? a.offset.top - g.top : a.offset.top - d.top) + a.sizeDiff.height); f = a.containerElement.get(0) == a.element.parent().get(0); g = /relative|absolute/.test(a.containerElement.css("position")); if (f && g) c -= a.parentData.left; if (c + a.size.width >= a.parentData.width) { a.size.width = a.parentData.width - c; if (b) a.size.height = a.size.width / a.aspectRatio } if (d +
a.size.height >= a.parentData.height) { a.size.height = a.parentData.height - d; if (b) a.size.width = a.size.height * a.aspectRatio } 
}, stop: function () {
    var b = e(this).data("resizable"), a = b.options, c = b.containerOffset, d = b.containerPosition, f = b.containerElement, g = e(b.helper), h = g.offset(), i = g.outerWidth() - b.sizeDiff.width; g = g.outerHeight() - b.sizeDiff.height; b._helper && !a.animate && /relative/.test(f.css("position")) && e(this).css({ left: h.left - d.left - c.left, width: i, height: g }); b._helper && !a.animate && /static/.test(f.css("position")) &&
e(this).css({ left: h.left - d.left - c.left, width: i, height: g })
} 
}); e.ui.plugin.add("resizable", "ghost", { start: function () { var b = e(this).data("resizable"), a = b.options, c = b.size; b.ghost = b.originalElement.clone(); b.ghost.css({ opacity: 0.25, display: "block", position: "relative", height: c.height, width: c.width, margin: 0, left: 0, top: 0 }).addClass("ui-resizable-ghost").addClass(typeof a.ghost == "string" ? a.ghost : ""); b.ghost.appendTo(b.helper) }, resize: function () {
    var b = e(this).data("resizable"); b.ghost && b.ghost.css({ position: "relative",
        height: b.size.height, width: b.size.width
    })
}, stop: function () { var b = e(this).data("resizable"); b.ghost && b.helper && b.helper.get(0).removeChild(b.ghost.get(0)) } 
}); e.ui.plugin.add("resizable", "grid", { resize: function () {
    var b = e(this).data("resizable"), a = b.options, c = b.size, d = b.originalSize, f = b.originalPosition, g = b.axis; a.grid = typeof a.grid == "number" ? [a.grid, a.grid] : a.grid; var h = Math.round((c.width - d.width) / (a.grid[0] || 1)) * (a.grid[0] || 1); a = Math.round((c.height - d.height) / (a.grid[1] || 1)) * (a.grid[1] || 1); if (/^(se|s|e)$/.test(g)) {
        b.size.width =
d.width + h; b.size.height = d.height + a
    } else if (/^(ne)$/.test(g)) { b.size.width = d.width + h; b.size.height = d.height + a; b.position.top = f.top - a } else { if (/^(sw)$/.test(g)) { b.size.width = d.width + h; b.size.height = d.height + a } else { b.size.width = d.width + h; b.size.height = d.height + a; b.position.top = f.top - a } b.position.left = f.left - h } 
} 
}); var m = function (b) { return parseInt(b, 10) || 0 }, l = function (b) { return !isNaN(parseInt(b, 10)) } 
})(jQuery);
; /*
 * jQuery UI Selectable 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Selectables
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.mouse.js
 *	jquery.ui.widget.js
 */
(function (e) {
    e.widget("ui.selectable", e.ui.mouse, { options: { appendTo: "body", autoRefresh: true, distance: 0, filter: "*", tolerance: "touch" }, _create: function () {
        var c = this; this.element.addClass("ui-selectable"); this.dragged = false; var f; this.refresh = function () {
            f = e(c.options.filter, c.element[0]); f.each(function () {
                var d = e(this), b = d.offset(); e.data(this, "selectable-item", { element: this, $element: d, left: b.left, top: b.top, right: b.left + d.outerWidth(), bottom: b.top + d.outerHeight(), startselected: false, selected: d.hasClass("ui-selected"),
                    selecting: d.hasClass("ui-selecting"), unselecting: d.hasClass("ui-unselecting")
                })
            })
        }; this.refresh(); this.selectees = f.addClass("ui-selectee"); this._mouseInit(); this.helper = e("<div class='ui-selectable-helper'></div>")
    }, destroy: function () { this.selectees.removeClass("ui-selectee").removeData("selectable-item"); this.element.removeClass("ui-selectable ui-selectable-disabled").removeData("selectable").unbind(".selectable"); this._mouseDestroy(); return this }, _mouseStart: function (c) {
        var f = this; this.opos = [c.pageX,
c.pageY]; if (!this.options.disabled) {
            var d = this.options; this.selectees = e(d.filter, this.element[0]); this._trigger("start", c); e(d.appendTo).append(this.helper); this.helper.css({ left: c.clientX, top: c.clientY, width: 0, height: 0 }); d.autoRefresh && this.refresh(); this.selectees.filter(".ui-selected").each(function () {
                var b = e.data(this, "selectable-item"); b.startselected = true; if (!c.metaKey) {
                    b.$element.removeClass("ui-selected"); b.selected = false; b.$element.addClass("ui-unselecting"); b.unselecting = true; f._trigger("unselecting",
c, { unselecting: b.element })
                } 
            }); e(c.target).parents().andSelf().each(function () { var b = e.data(this, "selectable-item"); if (b) { var g = !c.metaKey || !b.$element.hasClass("ui-selected"); b.$element.removeClass(g ? "ui-unselecting" : "ui-selected").addClass(g ? "ui-selecting" : "ui-unselecting"); b.unselecting = !g; b.selecting = g; (b.selected = g) ? f._trigger("selecting", c, { selecting: b.element }) : f._trigger("unselecting", c, { unselecting: b.element }); return false } })
        } 
    }, _mouseDrag: function (c) {
        var f = this; this.dragged = true; if (!this.options.disabled) {
            var d =
this.options, b = this.opos[0], g = this.opos[1], h = c.pageX, i = c.pageY; if (b > h) { var j = h; h = b; b = j } if (g > i) { j = i; i = g; g = j } this.helper.css({ left: b, top: g, width: h - b, height: i - g }); this.selectees.each(function () {
    var a = e.data(this, "selectable-item"); if (!(!a || a.element == f.element[0])) {
        var k = false; if (d.tolerance == "touch") k = !(a.left > h || a.right < b || a.top > i || a.bottom < g); else if (d.tolerance == "fit") k = a.left > b && a.right < h && a.top > g && a.bottom < i; if (k) {
            if (a.selected) { a.$element.removeClass("ui-selected"); a.selected = false } if (a.unselecting) {
                a.$element.removeClass("ui-unselecting");
                a.unselecting = false
            } if (!a.selecting) { a.$element.addClass("ui-selecting"); a.selecting = true; f._trigger("selecting", c, { selecting: a.element }) } 
        } else {
            if (a.selecting) if (c.metaKey && a.startselected) { a.$element.removeClass("ui-selecting"); a.selecting = false; a.$element.addClass("ui-selected"); a.selected = true } else { a.$element.removeClass("ui-selecting"); a.selecting = false; if (a.startselected) { a.$element.addClass("ui-unselecting"); a.unselecting = true } f._trigger("unselecting", c, { unselecting: a.element }) } if (a.selected) if (!c.metaKey &&
!a.startselected) { a.$element.removeClass("ui-selected"); a.selected = false; a.$element.addClass("ui-unselecting"); a.unselecting = true; f._trigger("unselecting", c, { unselecting: a.element }) } 
        } 
    } 
}); return false
        } 
    }, _mouseStop: function (c) {
        var f = this; this.dragged = false; e(".ui-unselecting", this.element[0]).each(function () { var d = e.data(this, "selectable-item"); d.$element.removeClass("ui-unselecting"); d.unselecting = false; d.startselected = false; f._trigger("unselected", c, { unselected: d.element }) }); e(".ui-selecting", this.element[0]).each(function () {
            var d =
e.data(this, "selectable-item"); d.$element.removeClass("ui-selecting").addClass("ui-selected"); d.selecting = false; d.selected = true; d.startselected = true; f._trigger("selected", c, { selected: d.element })
        }); this._trigger("stop", c); this.helper.remove(); return false
    } 
    }); e.extend(e.ui.selectable, { version: "1.8.7" })
})(jQuery);
; /*
 * jQuery UI Sortable 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Sortables
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.mouse.js
 *	jquery.ui.widget.js
 */
(function (d) {
    d.widget("ui.sortable", d.ui.mouse, { widgetEventPrefix: "sort", options: { appendTo: "parent", axis: false, connectWith: false, containment: false, cursor: "auto", cursorAt: false, dropOnEmpty: true, forcePlaceholderSize: false, forceHelperSize: false, grid: false, handle: false, helper: "original", items: "> *", opacity: false, placeholder: false, revert: false, scroll: true, scrollSensitivity: 20, scrollSpeed: 20, scope: "default", tolerance: "intersect", zIndex: 1E3 }, _create: function () {
        this.containerCache = {}; this.element.addClass("ui-sortable");
        this.refresh(); this.floating = this.items.length ? /left|right/.test(this.items[0].item.css("float")) : false; this.offset = this.element.offset(); this._mouseInit()
    }, destroy: function () { this.element.removeClass("ui-sortable ui-sortable-disabled").removeData("sortable").unbind(".sortable"); this._mouseDestroy(); for (var a = this.items.length - 1; a >= 0; a--) this.items[a].item.removeData("sortable-item"); return this }, _setOption: function (a, b) {
        if (a === "disabled") { this.options[a] = b; this.widget()[b ? "addClass" : "removeClass"]("ui-sortable-disabled") } else d.Widget.prototype._setOption.apply(this,
arguments)
    }, _mouseCapture: function (a, b) {
        if (this.reverting) return false; if (this.options.disabled || this.options.type == "static") return false; this._refreshItems(a); var c = null, e = this; d(a.target).parents().each(function () { if (d.data(this, "sortable-item") == e) { c = d(this); return false } }); if (d.data(a.target, "sortable-item") == e) c = d(a.target); if (!c) return false; if (this.options.handle && !b) { var f = false; d(this.options.handle, c).find("*").andSelf().each(function () { if (this == a.target) f = true }); if (!f) return false } this.currentItem =
c; this._removeCurrentsFromItems(); return true
    }, _mouseStart: function (a, b, c) {
        b = this.options; var e = this; this.currentContainer = this; this.refreshPositions(); this.helper = this._createHelper(a); this._cacheHelperProportions(); this._cacheMargins(); this.scrollParent = this.helper.scrollParent(); this.offset = this.currentItem.offset(); this.offset = { top: this.offset.top - this.margins.top, left: this.offset.left - this.margins.left }; this.helper.css("position", "absolute"); this.cssPosition = this.helper.css("position"); d.extend(this.offset,
{ click: { left: a.pageX - this.offset.left, top: a.pageY - this.offset.top }, parent: this._getParentOffset(), relative: this._getRelativeOffset() }); this.originalPosition = this._generatePosition(a); this.originalPageX = a.pageX; this.originalPageY = a.pageY; b.cursorAt && this._adjustOffsetFromHelper(b.cursorAt); this.domPosition = { prev: this.currentItem.prev()[0], parent: this.currentItem.parent()[0] }; this.helper[0] != this.currentItem[0] && this.currentItem.hide(); this._createPlaceholder(); b.containment && this._setContainment();
        if (b.cursor) { if (d("body").css("cursor")) this._storedCursor = d("body").css("cursor"); d("body").css("cursor", b.cursor) } if (b.opacity) { if (this.helper.css("opacity")) this._storedOpacity = this.helper.css("opacity"); this.helper.css("opacity", b.opacity) } if (b.zIndex) { if (this.helper.css("zIndex")) this._storedZIndex = this.helper.css("zIndex"); this.helper.css("zIndex", b.zIndex) } if (this.scrollParent[0] != document && this.scrollParent[0].tagName != "HTML") this.overflowOffset = this.scrollParent.offset(); this._trigger("start",
a, this._uiHash()); this._preserveHelperProportions || this._cacheHelperProportions(); if (!c) for (c = this.containers.length - 1; c >= 0; c--) this.containers[c]._trigger("activate", a, e._uiHash(this)); if (d.ui.ddmanager) d.ui.ddmanager.current = this; d.ui.ddmanager && !b.dropBehaviour && d.ui.ddmanager.prepareOffsets(this, a); this.dragging = true; this.helper.addClass("ui-sortable-helper"); this._mouseDrag(a); return true
    }, _mouseDrag: function (a) {
        this.position = this._generatePosition(a); this.positionAbs = this._convertPositionTo("absolute");
        if (!this.lastPositionAbs) this.lastPositionAbs = this.positionAbs; if (this.options.scroll) {
            var b = this.options, c = false; if (this.scrollParent[0] != document && this.scrollParent[0].tagName != "HTML") {
                if (this.overflowOffset.top + this.scrollParent[0].offsetHeight - a.pageY < b.scrollSensitivity) this.scrollParent[0].scrollTop = c = this.scrollParent[0].scrollTop + b.scrollSpeed; else if (a.pageY - this.overflowOffset.top < b.scrollSensitivity) this.scrollParent[0].scrollTop = c = this.scrollParent[0].scrollTop - b.scrollSpeed; if (this.overflowOffset.left +
this.scrollParent[0].offsetWidth - a.pageX < b.scrollSensitivity) this.scrollParent[0].scrollLeft = c = this.scrollParent[0].scrollLeft + b.scrollSpeed; else if (a.pageX - this.overflowOffset.left < b.scrollSensitivity) this.scrollParent[0].scrollLeft = c = this.scrollParent[0].scrollLeft - b.scrollSpeed
            } else {
                if (a.pageY - d(document).scrollTop() < b.scrollSensitivity) c = d(document).scrollTop(d(document).scrollTop() - b.scrollSpeed); else if (d(window).height() - (a.pageY - d(document).scrollTop()) < b.scrollSensitivity) c = d(document).scrollTop(d(document).scrollTop() +
b.scrollSpeed); if (a.pageX - d(document).scrollLeft() < b.scrollSensitivity) c = d(document).scrollLeft(d(document).scrollLeft() - b.scrollSpeed); else if (d(window).width() - (a.pageX - d(document).scrollLeft()) < b.scrollSensitivity) c = d(document).scrollLeft(d(document).scrollLeft() + b.scrollSpeed)
            } c !== false && d.ui.ddmanager && !b.dropBehaviour && d.ui.ddmanager.prepareOffsets(this, a)
        } this.positionAbs = this._convertPositionTo("absolute"); if (!this.options.axis || this.options.axis != "y") this.helper[0].style.left = this.position.left +
"px"; if (!this.options.axis || this.options.axis != "x") this.helper[0].style.top = this.position.top + "px"; for (b = this.items.length - 1; b >= 0; b--) {
            c = this.items[b]; var e = c.item[0], f = this._intersectsWithPointer(c); if (f) if (e != this.currentItem[0] && this.placeholder[f == 1 ? "next" : "prev"]()[0] != e && !d.ui.contains(this.placeholder[0], e) && (this.options.type == "semi-dynamic" ? !d.ui.contains(this.element[0], e) : true)) {
                this.direction = f == 1 ? "down" : "up"; if (this.options.tolerance == "pointer" || this._intersectsWithSides(c)) this._rearrange(a,
c); else break; this._trigger("change", a, this._uiHash()); break
            } 
        } this._contactContainers(a); d.ui.ddmanager && d.ui.ddmanager.drag(this, a); this._trigger("sort", a, this._uiHash()); this.lastPositionAbs = this.positionAbs; return false
    }, _mouseStop: function (a, b) {
        if (a) {
            d.ui.ddmanager && !this.options.dropBehaviour && d.ui.ddmanager.drop(this, a); if (this.options.revert) {
                var c = this; b = c.placeholder.offset(); c.reverting = true; d(this.helper).animate({ left: b.left - this.offset.parent.left - c.margins.left + (this.offsetParent[0] ==
document.body ? 0 : this.offsetParent[0].scrollLeft), top: b.top - this.offset.parent.top - c.margins.top + (this.offsetParent[0] == document.body ? 0 : this.offsetParent[0].scrollTop)
                }, parseInt(this.options.revert, 10) || 500, function () { c._clear(a) })
            } else this._clear(a, b); return false
        } 
    }, cancel: function () {
        var a = this; if (this.dragging) {
            this._mouseUp(); this.options.helper == "original" ? this.currentItem.css(this._storedCSS).removeClass("ui-sortable-helper") : this.currentItem.show(); for (var b = this.containers.length - 1; b >= 0; b--) {
                this.containers[b]._trigger("deactivate",
null, a._uiHash(this)); if (this.containers[b].containerCache.over) { this.containers[b]._trigger("out", null, a._uiHash(this)); this.containers[b].containerCache.over = 0 } 
            } 
        } this.placeholder[0].parentNode && this.placeholder[0].parentNode.removeChild(this.placeholder[0]); this.options.helper != "original" && this.helper && this.helper[0].parentNode && this.helper.remove(); d.extend(this, { helper: null, dragging: false, reverting: false, _noFinalSort: null }); this.domPosition.prev ? d(this.domPosition.prev).after(this.currentItem) :
d(this.domPosition.parent).prepend(this.currentItem); return this
    }, serialize: function (a) { var b = this._getItemsAsjQuery(a && a.connected), c = []; a = a || {}; d(b).each(function () { var e = (d(a.item || this).attr(a.attribute || "id") || "").match(a.expression || /(.+)[-=_](.+)/); if (e) c.push((a.key || e[1] + "[]") + "=" + (a.key && a.expression ? e[1] : e[2])) }); !c.length && a.key && c.push(a.key + "="); return c.join("&") }, toArray: function (a) {
        var b = this._getItemsAsjQuery(a && a.connected), c = []; a = a || {}; b.each(function () {
            c.push(d(a.item || this).attr(a.attribute ||
"id") || "")
        }); return c
    }, _intersectsWith: function (a) {
        var b = this.positionAbs.left, c = b + this.helperProportions.width, e = this.positionAbs.top, f = e + this.helperProportions.height, g = a.left, h = g + a.width, i = a.top, k = i + a.height, j = this.offset.click.top, l = this.offset.click.left; j = e + j > i && e + j < k && b + l > g && b + l < h; return this.options.tolerance == "pointer" || this.options.forcePointerForContainers || this.options.tolerance != "pointer" && this.helperProportions[this.floating ? "width" : "height"] > a[this.floating ? "width" : "height"] ? j : g < b +
this.helperProportions.width / 2 && c - this.helperProportions.width / 2 < h && i < e + this.helperProportions.height / 2 && f - this.helperProportions.height / 2 < k
    }, _intersectsWithPointer: function (a) {
        var b = d.ui.isOverAxis(this.positionAbs.top + this.offset.click.top, a.top, a.height); a = d.ui.isOverAxis(this.positionAbs.left + this.offset.click.left, a.left, a.width); b = b && a; a = this._getDragVerticalDirection(); var c = this._getDragHorizontalDirection(); if (!b) return false; return this.floating ? c && c == "right" || a == "down" ? 2 : 1 : a && (a == "down" ?
2 : 1)
    }, _intersectsWithSides: function (a) { var b = d.ui.isOverAxis(this.positionAbs.top + this.offset.click.top, a.top + a.height / 2, a.height); a = d.ui.isOverAxis(this.positionAbs.left + this.offset.click.left, a.left + a.width / 2, a.width); var c = this._getDragVerticalDirection(), e = this._getDragHorizontalDirection(); return this.floating && e ? e == "right" && a || e == "left" && !a : c && (c == "down" && b || c == "up" && !b) }, _getDragVerticalDirection: function () { var a = this.positionAbs.top - this.lastPositionAbs.top; return a != 0 && (a > 0 ? "down" : "up") },
        _getDragHorizontalDirection: function () { var a = this.positionAbs.left - this.lastPositionAbs.left; return a != 0 && (a > 0 ? "right" : "left") }, refresh: function (a) { this._refreshItems(a); this.refreshPositions(); return this }, _connectWith: function () { var a = this.options; return a.connectWith.constructor == String ? [a.connectWith] : a.connectWith }, _getItemsAsjQuery: function (a) {
            var b = [], c = [], e = this._connectWith(); if (e && a) for (a = e.length - 1; a >= 0; a--) for (var f = d(e[a]), g = f.length - 1; g >= 0; g--) {
                var h = d.data(f[g], "sortable"); if (h && h !=
this && !h.options.disabled) c.push([d.isFunction(h.options.items) ? h.options.items.call(h.element) : d(h.options.items, h.element).not(".ui-sortable-helper").not(".ui-sortable-placeholder"), h])
            } c.push([d.isFunction(this.options.items) ? this.options.items.call(this.element, null, { options: this.options, item: this.currentItem }) : d(this.options.items, this.element).not(".ui-sortable-helper").not(".ui-sortable-placeholder"), this]); for (a = c.length - 1; a >= 0; a--) c[a][0].each(function () { b.push(this) }); return d(b)
        }, _removeCurrentsFromItems: function () {
            for (var a =
this.currentItem.find(":data(sortable-item)"), b = 0; b < this.items.length; b++) for (var c = 0; c < a.length; c++) a[c] == this.items[b].item[0] && this.items.splice(b, 1)
        }, _refreshItems: function (a) {
            this.items = []; this.containers = [this]; var b = this.items, c = [[d.isFunction(this.options.items) ? this.options.items.call(this.element[0], a, { item: this.currentItem }) : d(this.options.items, this.element), this]], e = this._connectWith(); if (e) for (var f = e.length - 1; f >= 0; f--) for (var g = d(e[f]), h = g.length - 1; h >= 0; h--) {
                var i = d.data(g[h], "sortable");
                if (i && i != this && !i.options.disabled) { c.push([d.isFunction(i.options.items) ? i.options.items.call(i.element[0], a, { item: this.currentItem }) : d(i.options.items, i.element), i]); this.containers.push(i) } 
            } for (f = c.length - 1; f >= 0; f--) { a = c[f][1]; e = c[f][0]; h = 0; for (g = e.length; h < g; h++) { i = d(e[h]); i.data("sortable-item", a); b.push({ item: i, instance: a, width: 0, height: 0, left: 0, top: 0 }) } } 
        }, refreshPositions: function (a) {
            if (this.offsetParent && this.helper) this.offset.parent = this._getParentOffset(); for (var b = this.items.length - 1; b >=
0; b--) { var c = this.items[b], e = this.options.toleranceElement ? d(this.options.toleranceElement, c.item) : c.item; if (!a) { c.width = e.outerWidth(); c.height = e.outerHeight() } e = e.offset(); c.left = e.left; c.top = e.top } if (this.options.custom && this.options.custom.refreshContainers) this.options.custom.refreshContainers.call(this); else for (b = this.containers.length - 1; b >= 0; b--) {
                e = this.containers[b].element.offset(); this.containers[b].containerCache.left = e.left; this.containers[b].containerCache.top = e.top; this.containers[b].containerCache.width =
this.containers[b].element.outerWidth(); this.containers[b].containerCache.height = this.containers[b].element.outerHeight()
            } return this
        }, _createPlaceholder: function (a) {
            var b = a || this, c = b.options; if (!c.placeholder || c.placeholder.constructor == String) {
                var e = c.placeholder; c.placeholder = { element: function () { var f = d(document.createElement(b.currentItem[0].nodeName)).addClass(e || b.currentItem[0].className + " ui-sortable-placeholder").removeClass("ui-sortable-helper")[0]; if (!e) f.style.visibility = "hidden"; return f },
                    update: function (f, g) { if (!(e && !c.forcePlaceholderSize)) { g.height() || g.height(b.currentItem.innerHeight() - parseInt(b.currentItem.css("paddingTop") || 0, 10) - parseInt(b.currentItem.css("paddingBottom") || 0, 10)); g.width() || g.width(b.currentItem.innerWidth() - parseInt(b.currentItem.css("paddingLeft") || 0, 10) - parseInt(b.currentItem.css("paddingRight") || 0, 10)) } } 
                }
            } b.placeholder = d(c.placeholder.element.call(b.element, b.currentItem)); b.currentItem.after(b.placeholder); c.placeholder.update(b, b.placeholder)
        }, _contactContainers: function (a) {
            for (var b =
null, c = null, e = this.containers.length - 1; e >= 0; e--) if (!d.ui.contains(this.currentItem[0], this.containers[e].element[0])) if (this._intersectsWith(this.containers[e].containerCache)) { if (!(b && d.ui.contains(this.containers[e].element[0], b.element[0]))) { b = this.containers[e]; c = e } } else if (this.containers[e].containerCache.over) { this.containers[e]._trigger("out", a, this._uiHash(this)); this.containers[e].containerCache.over = 0 } if (b) if (this.containers.length === 1) {
                this.containers[c]._trigger("over", a, this._uiHash(this));
                this.containers[c].containerCache.over = 1
            } else if (this.currentContainer != this.containers[c]) {
                b = 1E4; e = null; for (var f = this.positionAbs[this.containers[c].floating ? "left" : "top"], g = this.items.length - 1; g >= 0; g--) if (d.ui.contains(this.containers[c].element[0], this.items[g].item[0])) { var h = this.items[g][this.containers[c].floating ? "left" : "top"]; if (Math.abs(h - f) < b) { b = Math.abs(h - f); e = this.items[g] } } if (e || this.options.dropOnEmpty) {
                    this.currentContainer = this.containers[c]; e ? this._rearrange(a, e, null, true) : this._rearrange(a,
null, this.containers[c].element, true); this._trigger("change", a, this._uiHash()); this.containers[c]._trigger("change", a, this._uiHash(this)); this.options.placeholder.update(this.currentContainer, this.placeholder); this.containers[c]._trigger("over", a, this._uiHash(this)); this.containers[c].containerCache.over = 1
                } 
            } 
        }, _createHelper: function (a) {
            var b = this.options; a = d.isFunction(b.helper) ? d(b.helper.apply(this.element[0], [a, this.currentItem])) : b.helper == "clone" ? this.currentItem.clone() : this.currentItem; a.parents("body").length ||
d(b.appendTo != "parent" ? b.appendTo : this.currentItem[0].parentNode)[0].appendChild(a[0]); if (a[0] == this.currentItem[0]) this._storedCSS = { width: this.currentItem[0].style.width, height: this.currentItem[0].style.height, position: this.currentItem.css("position"), top: this.currentItem.css("top"), left: this.currentItem.css("left") }; if (a[0].style.width == "" || b.forceHelperSize) a.width(this.currentItem.width()); if (a[0].style.height == "" || b.forceHelperSize) a.height(this.currentItem.height()); return a
        }, _adjustOffsetFromHelper: function (a) {
            if (typeof a ==
"string") a = a.split(" "); if (d.isArray(a)) a = { left: +a[0], top: +a[1] || 0 }; if ("left" in a) this.offset.click.left = a.left + this.margins.left; if ("right" in a) this.offset.click.left = this.helperProportions.width - a.right + this.margins.left; if ("top" in a) this.offset.click.top = a.top + this.margins.top; if ("bottom" in a) this.offset.click.top = this.helperProportions.height - a.bottom + this.margins.top
        }, _getParentOffset: function () {
            this.offsetParent = this.helper.offsetParent(); var a = this.offsetParent.offset(); if (this.cssPosition ==
"absolute" && this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0], this.offsetParent[0])) { a.left += this.scrollParent.scrollLeft(); a.top += this.scrollParent.scrollTop() } if (this.offsetParent[0] == document.body || this.offsetParent[0].tagName && this.offsetParent[0].tagName.toLowerCase() == "html" && d.browser.msie) a = { top: 0, left: 0 }; return { top: a.top + (parseInt(this.offsetParent.css("borderTopWidth"), 10) || 0), left: a.left + (parseInt(this.offsetParent.css("borderLeftWidth"), 10) || 0)}
        }, _getRelativeOffset: function () {
            if (this.cssPosition ==
"relative") { var a = this.currentItem.position(); return { top: a.top - (parseInt(this.helper.css("top"), 10) || 0) + this.scrollParent.scrollTop(), left: a.left - (parseInt(this.helper.css("left"), 10) || 0) + this.scrollParent.scrollLeft()} } else return { top: 0, left: 0}
        }, _cacheMargins: function () { this.margins = { left: parseInt(this.currentItem.css("marginLeft"), 10) || 0, top: parseInt(this.currentItem.css("marginTop"), 10) || 0} }, _cacheHelperProportions: function () { this.helperProportions = { width: this.helper.outerWidth(), height: this.helper.outerHeight()} },
        _setContainment: function () {
            var a = this.options; if (a.containment == "parent") a.containment = this.helper[0].parentNode; if (a.containment == "document" || a.containment == "window") this.containment = [0 - this.offset.relative.left - this.offset.parent.left, 0 - this.offset.relative.top - this.offset.parent.top, d(a.containment == "document" ? document : window).width() - this.helperProportions.width - this.margins.left, (d(a.containment == "document" ? document : window).height() || document.body.parentNode.scrollHeight) - this.helperProportions.height -
this.margins.top]; if (!/^(document|window|parent)$/.test(a.containment)) {
                var b = d(a.containment)[0]; a = d(a.containment).offset(); var c = d(b).css("overflow") != "hidden"; this.containment = [a.left + (parseInt(d(b).css("borderLeftWidth"), 10) || 0) + (parseInt(d(b).css("paddingLeft"), 10) || 0) - this.margins.left, a.top + (parseInt(d(b).css("borderTopWidth"), 10) || 0) + (parseInt(d(b).css("paddingTop"), 10) || 0) - this.margins.top, a.left + (c ? Math.max(b.scrollWidth, b.offsetWidth) : b.offsetWidth) - (parseInt(d(b).css("borderLeftWidth"),
10) || 0) - (parseInt(d(b).css("paddingRight"), 10) || 0) - this.helperProportions.width - this.margins.left, a.top + (c ? Math.max(b.scrollHeight, b.offsetHeight) : b.offsetHeight) - (parseInt(d(b).css("borderTopWidth"), 10) || 0) - (parseInt(d(b).css("paddingBottom"), 10) || 0) - this.helperProportions.height - this.margins.top]
            } 
        }, _convertPositionTo: function (a, b) {
            if (!b) b = this.position; a = a == "absolute" ? 1 : -1; var c = this.cssPosition == "absolute" && !(this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0], this.offsetParent[0])) ?
this.offsetParent : this.scrollParent, e = /(html|body)/i.test(c[0].tagName); return { top: b.top + this.offset.relative.top * a + this.offset.parent.top * a - (d.browser.safari && this.cssPosition == "fixed" ? 0 : (this.cssPosition == "fixed" ? -this.scrollParent.scrollTop() : e ? 0 : c.scrollTop()) * a), left: b.left + this.offset.relative.left * a + this.offset.parent.left * a - (d.browser.safari && this.cssPosition == "fixed" ? 0 : (this.cssPosition == "fixed" ? -this.scrollParent.scrollLeft() : e ? 0 : c.scrollLeft()) * a)}
        }, _generatePosition: function (a) {
            var b =
this.options, c = this.cssPosition == "absolute" && !(this.scrollParent[0] != document && d.ui.contains(this.scrollParent[0], this.offsetParent[0])) ? this.offsetParent : this.scrollParent, e = /(html|body)/i.test(c[0].tagName); if (this.cssPosition == "relative" && !(this.scrollParent[0] != document && this.scrollParent[0] != this.offsetParent[0])) this.offset.relative = this._getRelativeOffset(); var f = a.pageX, g = a.pageY; if (this.originalPosition) {
                if (this.containment) {
                    if (a.pageX - this.offset.click.left < this.containment[0]) f = this.containment[0] +
this.offset.click.left; if (a.pageY - this.offset.click.top < this.containment[1]) g = this.containment[1] + this.offset.click.top; if (a.pageX - this.offset.click.left > this.containment[2]) f = this.containment[2] + this.offset.click.left; if (a.pageY - this.offset.click.top > this.containment[3]) g = this.containment[3] + this.offset.click.top
                } if (b.grid) {
                    g = this.originalPageY + Math.round((g - this.originalPageY) / b.grid[1]) * b.grid[1]; g = this.containment ? !(g - this.offset.click.top < this.containment[1] || g - this.offset.click.top > this.containment[3]) ?
g : !(g - this.offset.click.top < this.containment[1]) ? g - b.grid[1] : g + b.grid[1] : g; f = this.originalPageX + Math.round((f - this.originalPageX) / b.grid[0]) * b.grid[0]; f = this.containment ? !(f - this.offset.click.left < this.containment[0] || f - this.offset.click.left > this.containment[2]) ? f : !(f - this.offset.click.left < this.containment[0]) ? f - b.grid[0] : f + b.grid[0] : f
                } 
            } return { top: g - this.offset.click.top - this.offset.relative.top - this.offset.parent.top + (d.browser.safari && this.cssPosition == "fixed" ? 0 : this.cssPosition == "fixed" ? -this.scrollParent.scrollTop() :
e ? 0 : c.scrollTop()), left: f - this.offset.click.left - this.offset.relative.left - this.offset.parent.left + (d.browser.safari && this.cssPosition == "fixed" ? 0 : this.cssPosition == "fixed" ? -this.scrollParent.scrollLeft() : e ? 0 : c.scrollLeft())
            }
        }, _rearrange: function (a, b, c, e) {
            c ? c[0].appendChild(this.placeholder[0]) : b.item[0].parentNode.insertBefore(this.placeholder[0], this.direction == "down" ? b.item[0] : b.item[0].nextSibling); this.counter = this.counter ? ++this.counter : 1; var f = this, g = this.counter; window.setTimeout(function () {
                g ==
f.counter && f.refreshPositions(!e)
            }, 0)
        }, _clear: function (a, b) {
            this.reverting = false; var c = []; !this._noFinalSort && this.currentItem[0].parentNode && this.placeholder.before(this.currentItem); this._noFinalSort = null; if (this.helper[0] == this.currentItem[0]) { for (var e in this._storedCSS) if (this._storedCSS[e] == "auto" || this._storedCSS[e] == "static") this._storedCSS[e] = ""; this.currentItem.css(this._storedCSS).removeClass("ui-sortable-helper") } else this.currentItem.show(); this.fromOutside && !b && c.push(function (f) {
                this._trigger("receive",
f, this._uiHash(this.fromOutside))
            }); if ((this.fromOutside || this.domPosition.prev != this.currentItem.prev().not(".ui-sortable-helper")[0] || this.domPosition.parent != this.currentItem.parent()[0]) && !b) c.push(function (f) { this._trigger("update", f, this._uiHash()) }); if (!d.ui.contains(this.element[0], this.currentItem[0])) {
                b || c.push(function (f) { this._trigger("remove", f, this._uiHash()) }); for (e = this.containers.length - 1; e >= 0; e--) if (d.ui.contains(this.containers[e].element[0], this.currentItem[0]) && !b) {
                    c.push(function (f) {
                        return function (g) {
                            f._trigger("receive",
g, this._uiHash(this))
                        } 
                    } .call(this, this.containers[e])); c.push(function (f) { return function (g) { f._trigger("update", g, this._uiHash(this)) } } .call(this, this.containers[e]))
                } 
            } for (e = this.containers.length - 1; e >= 0; e--) {
                b || c.push(function (f) { return function (g) { f._trigger("deactivate", g, this._uiHash(this)) } } .call(this, this.containers[e])); if (this.containers[e].containerCache.over) {
                    c.push(function (f) { return function (g) { f._trigger("out", g, this._uiHash(this)) } } .call(this, this.containers[e])); this.containers[e].containerCache.over =
0
                } 
            } this._storedCursor && d("body").css("cursor", this._storedCursor); this._storedOpacity && this.helper.css("opacity", this._storedOpacity); if (this._storedZIndex) this.helper.css("zIndex", this._storedZIndex == "auto" ? "" : this._storedZIndex); this.dragging = false; if (this.cancelHelperRemoval) { if (!b) { this._trigger("beforeStop", a, this._uiHash()); for (e = 0; e < c.length; e++) c[e].call(this, a); this._trigger("stop", a, this._uiHash()) } return false } b || this._trigger("beforeStop", a, this._uiHash()); this.placeholder[0].parentNode.removeChild(this.placeholder[0]);
            this.helper[0] != this.currentItem[0] && this.helper.remove(); this.helper = null; if (!b) { for (e = 0; e < c.length; e++) c[e].call(this, a); this._trigger("stop", a, this._uiHash()) } this.fromOutside = false; return true
        }, _trigger: function () { d.Widget.prototype._trigger.apply(this, arguments) === false && this.cancel() }, _uiHash: function (a) { var b = a || this; return { helper: b.helper, placeholder: b.placeholder || d([]), position: b.position, originalPosition: b.originalPosition, offset: b.positionAbs, item: b.currentItem, sender: a ? a.element : null} } 
    });
    d.extend(d.ui.sortable, { version: "1.8.7" })
})(jQuery);
; /*
 * jQuery UI Accordion 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Accordion
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 */
(function (c) {
    c.widget("ui.accordion", { options: { active: 0, animated: "slide", autoHeight: true, clearStyle: false, collapsible: false, event: "click", fillSpace: false, header: "> li > :first-child,> :not(li):even", icons: { header: "ui-icon-triangle-1-e", headerSelected: "ui-icon-triangle-1-s" }, navigation: false, navigationFilter: function () { return this.href.toLowerCase() === location.href.toLowerCase() } }, _create: function () {
        var a = this, b = a.options; a.running = 0; a.element.addClass("ui-accordion ui-widget ui-helper-reset").children("li").addClass("ui-accordion-li-fix");
        a.headers = a.element.find(b.header).addClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-all").bind("mouseenter.accordion", function () { b.disabled || c(this).addClass("ui-state-hover") }).bind("mouseleave.accordion", function () { b.disabled || c(this).removeClass("ui-state-hover") }).bind("focus.accordion", function () { b.disabled || c(this).addClass("ui-state-focus") }).bind("blur.accordion", function () { b.disabled || c(this).removeClass("ui-state-focus") }); a.headers.next().addClass("ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom");
        if (b.navigation) { var d = a.element.find("a").filter(b.navigationFilter).eq(0); if (d.length) { var f = d.closest(".ui-accordion-header"); a.active = f.length ? f : d.closest(".ui-accordion-content").prev() } } a.active = a._findActive(a.active || b.active).addClass("ui-state-default ui-state-active").toggleClass("ui-corner-all").toggleClass("ui-corner-top"); a.active.next().addClass("ui-accordion-content-active"); a._createIcons(); a.resize(); a.element.attr("role", "tablist"); a.headers.attr("role", "tab").bind("keydown.accordion",
function (g) { return a._keydown(g) }).next().attr("role", "tabpanel"); a.headers.not(a.active || "").attr({ "aria-expanded": "false", tabIndex: -1 }).next().hide(); a.active.length ? a.active.attr({ "aria-expanded": "true", tabIndex: 0 }) : a.headers.eq(0).attr("tabIndex", 0); c.browser.safari || a.headers.find("a").attr("tabIndex", -1); b.event && a.headers.bind(b.event.split(" ").join(".accordion ") + ".accordion", function (g) { a._clickHandler.call(a, g, this); g.preventDefault() })
    }, _createIcons: function () {
        var a = this.options; if (a.icons) {
            c("<span></span>").addClass("ui-icon " +
a.icons.header).prependTo(this.headers); this.active.children(".ui-icon").toggleClass(a.icons.header).toggleClass(a.icons.headerSelected); this.element.addClass("ui-accordion-icons")
        } 
    }, _destroyIcons: function () { this.headers.children(".ui-icon").remove(); this.element.removeClass("ui-accordion-icons") }, destroy: function () {
        var a = this.options; this.element.removeClass("ui-accordion ui-widget ui-helper-reset").removeAttr("role"); this.headers.unbind(".accordion").removeClass("ui-accordion-header ui-accordion-disabled ui-helper-reset ui-state-default ui-corner-all ui-state-active ui-state-disabled ui-corner-top").removeAttr("role").removeAttr("aria-expanded").removeAttr("tabIndex");
        this.headers.find("a").removeAttr("tabIndex"); this._destroyIcons(); var b = this.headers.next().css("display", "").removeAttr("role").removeClass("ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content ui-accordion-content-active ui-accordion-disabled ui-state-disabled"); if (a.autoHeight || a.fillHeight) b.css("height", ""); return c.Widget.prototype.destroy.call(this)
    }, _setOption: function (a, b) {
        c.Widget.prototype._setOption.apply(this, arguments); a == "active" && this.activate(b); if (a == "icons") {
            this._destroyIcons();
            b && this._createIcons()
        } if (a == "disabled") this.headers.add(this.headers.next())[b ? "addClass" : "removeClass"]("ui-accordion-disabled ui-state-disabled")
    }, _keydown: function (a) {
        if (!(this.options.disabled || a.altKey || a.ctrlKey)) {
            var b = c.ui.keyCode, d = this.headers.length, f = this.headers.index(a.target), g = false; switch (a.keyCode) {
                case b.RIGHT: case b.DOWN: g = this.headers[(f + 1) % d]; break; case b.LEFT: case b.UP: g = this.headers[(f - 1 + d) % d]; break; case b.SPACE: case b.ENTER: this._clickHandler({ target: a.target }, a.target);
                    a.preventDefault()
            } if (g) { c(a.target).attr("tabIndex", -1); c(g).attr("tabIndex", 0); g.focus(); return false } return true
        } 
    }, resize: function () {
        var a = this.options, b; if (a.fillSpace) {
            if (c.browser.msie) { var d = this.element.parent().css("overflow"); this.element.parent().css("overflow", "hidden") } b = this.element.parent().height(); c.browser.msie && this.element.parent().css("overflow", d); this.headers.each(function () { b -= c(this).outerHeight(true) }); this.headers.next().each(function () {
                c(this).height(Math.max(0, b - c(this).innerHeight() +
c(this).height()))
            }).css("overflow", "auto")
        } else if (a.autoHeight) { b = 0; this.headers.next().each(function () { b = Math.max(b, c(this).height("").height()) }).height(b) } return this
    }, activate: function (a) { this.options.active = a; a = this._findActive(a)[0]; this._clickHandler({ target: a }, a); return this }, _findActive: function (a) { return a ? typeof a === "number" ? this.headers.filter(":eq(" + a + ")") : this.headers.not(this.headers.not(a)) : a === false ? c([]) : this.headers.filter(":eq(0)") }, _clickHandler: function (a, b) {
        var d = this.options;
        if (!d.disabled) if (a.target) {
            a = c(a.currentTarget || b); b = a[0] === this.active[0]; d.active = d.collapsible && b ? false : this.headers.index(a); if (!(this.running || !d.collapsible && b)) {
                this.active.removeClass("ui-state-active ui-corner-top").addClass("ui-state-default ui-corner-all").children(".ui-icon").removeClass(d.icons.headerSelected).addClass(d.icons.header); if (!b) {
                    a.removeClass("ui-state-default ui-corner-all").addClass("ui-state-active ui-corner-top").children(".ui-icon").removeClass(d.icons.header).addClass(d.icons.headerSelected);
                    a.next().addClass("ui-accordion-content-active")
                } h = a.next(); f = this.active.next(); g = { options: d, newHeader: b && d.collapsible ? c([]) : a, oldHeader: this.active, newContent: b && d.collapsible ? c([]) : h, oldContent: f }; d = this.headers.index(this.active[0]) > this.headers.index(a[0]); this.active = b ? c([]) : a; this._toggle(h, f, g, b, d)
            } 
        } else if (d.collapsible) {
            this.active.removeClass("ui-state-active ui-corner-top").addClass("ui-state-default ui-corner-all").children(".ui-icon").removeClass(d.icons.headerSelected).addClass(d.icons.header);
            this.active.next().addClass("ui-accordion-content-active"); var f = this.active.next(), g = { options: d, newHeader: c([]), oldHeader: d.active, newContent: c([]), oldContent: f }, h = this.active = c([]); this._toggle(h, f, g)
        } 
    }, _toggle: function (a, b, d, f, g) {
        var h = this, e = h.options; h.toShow = a; h.toHide = b; h.data = d; var j = function () { if (h) return h._completed.apply(h, arguments) }; h._trigger("changestart", null, h.data); h.running = b.size() === 0 ? a.size() : b.size(); if (e.animated) {
            d = {}; d = e.collapsible && f ? { toShow: c([]), toHide: b, complete: j,
                down: g, autoHeight: e.autoHeight || e.fillSpace
            } : { toShow: a, toHide: b, complete: j, down: g, autoHeight: e.autoHeight || e.fillSpace }; if (!e.proxied) e.proxied = e.animated; if (!e.proxiedDuration) e.proxiedDuration = e.duration; e.animated = c.isFunction(e.proxied) ? e.proxied(d) : e.proxied; e.duration = c.isFunction(e.proxiedDuration) ? e.proxiedDuration(d) : e.proxiedDuration; f = c.ui.accordion.animations; var i = e.duration, k = e.animated; if (k && !f[k] && !c.easing[k]) k = "slide"; f[k] || (f[k] = function (l) { this.slide(l, { easing: k, duration: i || 700 }) });
            f[k](d)
        } else { if (e.collapsible && f) a.toggle(); else { b.hide(); a.show() } j(true) } b.prev().attr({ "aria-expanded": "false", tabIndex: -1 }).blur(); a.prev().attr({ "aria-expanded": "true", tabIndex: 0 }).focus()
    }, _completed: function (a) { this.running = a ? 0 : --this.running; if (!this.running) { this.options.clearStyle && this.toShow.add(this.toHide).css({ height: "", overflow: "" }); this.toHide.removeClass("ui-accordion-content-active"); this._trigger("change", null, this.data) } } 
    }); c.extend(c.ui.accordion, { version: "1.8.7", animations: { slide: function (a,
b) {
        a = c.extend({ easing: "swing", duration: 300 }, a, b); if (a.toHide.size()) if (a.toShow.size()) {
            var d = a.toShow.css("overflow"), f = 0, g = {}, h = {}, e; b = a.toShow; e = b[0].style.width; b.width(parseInt(b.parent().width(), 10) - parseInt(b.css("paddingLeft"), 10) - parseInt(b.css("paddingRight"), 10) - (parseInt(b.css("borderLeftWidth"), 10) || 0) - (parseInt(b.css("borderRightWidth"), 10) || 0)); c.each(["height", "paddingTop", "paddingBottom"], function (j, i) {
                h[i] = "hide"; j = ("" + c.css(a.toShow[0], i)).match(/^([\d+-.]+)(.*)$/); g[i] = { value: j[1],
                    unit: j[2] || "px"
                }
            }); a.toShow.css({ height: 0, overflow: "hidden" }).show(); a.toHide.filter(":hidden").each(a.complete).end().filter(":visible").animate(h, { step: function (j, i) { if (i.prop == "height") f = i.end - i.start === 0 ? 0 : (i.now - i.start) / (i.end - i.start); a.toShow[0].style[i.prop] = f * g[i.prop].value + g[i.prop].unit }, duration: a.duration, easing: a.easing, complete: function () { a.autoHeight || a.toShow.css("height", ""); a.toShow.css({ width: e, overflow: d }); a.complete() } })
        } else a.toHide.animate({ height: "hide", paddingTop: "hide",
            paddingBottom: "hide"
        }, a); else a.toShow.animate({ height: "show", paddingTop: "show", paddingBottom: "show" }, a)
    }, bounceslide: function (a) { this.slide(a, { easing: a.down ? "easeOutBounce" : "swing", duration: a.down ? 1E3 : 200 }) } 
    }
    })
})(jQuery);
; /*
 * jQuery UI Autocomplete 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Autocomplete
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 *	jquery.ui.position.js
 */
(function (d) {
    d.widget("ui.autocomplete", { options: { appendTo: "body", delay: 300, minLength: 1, position: { my: "left top", at: "left bottom", collision: "none" }, source: null }, _create: function () {
        var a = this, b = this.element[0].ownerDocument, f; this.element.addClass("ui-autocomplete-input").attr("autocomplete", "off").attr({ role: "textbox", "aria-autocomplete": "list", "aria-haspopup": "true" }).bind("keydown.autocomplete", function (c) {
            if (!(a.options.disabled || a.element.attr("readonly"))) {
                f = false; var e = d.ui.keyCode; switch (c.keyCode) {
                    case e.PAGE_UP: a._move("previousPage",
c); break; case e.PAGE_DOWN: a._move("nextPage", c); break; case e.UP: a._move("previous", c); c.preventDefault(); break; case e.DOWN: a._move("next", c); c.preventDefault(); break; case e.ENTER: case e.NUMPAD_ENTER: if (a.menu.active) { f = true; c.preventDefault() } case e.TAB: if (!a.menu.active) return; a.menu.select(c); break; case e.ESCAPE: a.element.val(a.term); a.close(c); break; default: clearTimeout(a.searching); a.searching = setTimeout(function () { if (a.term != a.element.val()) { a.selectedItem = null; a.search(null, c) } }, a.options.delay);
                        break
                } 
            } 
        }).bind("keypress.autocomplete", function (c) { if (f) { f = false; c.preventDefault() } }).bind("focus.autocomplete", function () { if (!a.options.disabled) { a.selectedItem = null; a.previous = a.element.val() } }).bind("blur.autocomplete", function (c) { if (!a.options.disabled) { clearTimeout(a.searching); a.closing = setTimeout(function () { a.close(c); a._change(c) }, 150) } }); this._initSource(); this.response = function () { return a._response.apply(a, arguments) }; this.menu = d("<ul></ul>").addClass("ui-autocomplete").appendTo(d(this.options.appendTo ||
"body", b)[0]).mousedown(function (c) { var e = a.menu.element[0]; d(c.target).closest(".ui-menu-item").length || setTimeout(function () { d(document).one("mousedown", function (g) { g.target !== a.element[0] && g.target !== e && !d.ui.contains(e, g.target) && a.close() }) }, 1); setTimeout(function () { clearTimeout(a.closing) }, 13) }).menu({ focus: function (c, e) { e = e.item.data("item.autocomplete"); false !== a._trigger("focus", c, { item: e }) && /^key/.test(c.originalEvent.type) && a.element.val(e.value) }, selected: function (c, e) {
    var g = e.item.data("item.autocomplete"),
h = a.previous; if (a.element[0] !== b.activeElement) { a.element.focus(); a.previous = h; setTimeout(function () { a.previous = h; a.selectedItem = g }, 1) } false !== a._trigger("select", c, { item: g }) && a.element.val(g.value); a.term = a.element.val(); a.close(c); a.selectedItem = g
}, blur: function () { a.menu.element.is(":visible") && a.element.val() !== a.term && a.element.val(a.term) } 
}).zIndex(this.element.zIndex() + 1).css({ top: 0, left: 0 }).hide().data("menu"); d.fn.bgiframe && this.menu.element.bgiframe()
    }, destroy: function () {
        this.element.removeClass("ui-autocomplete-input").removeAttr("autocomplete").removeAttr("role").removeAttr("aria-autocomplete").removeAttr("aria-haspopup");
        this.menu.element.remove(); d.Widget.prototype.destroy.call(this)
    }, _setOption: function (a, b) { d.Widget.prototype._setOption.apply(this, arguments); a === "source" && this._initSource(); if (a === "appendTo") this.menu.element.appendTo(d(b || "body", this.element[0].ownerDocument)[0]) }, _initSource: function () {
        var a = this, b, f; if (d.isArray(this.options.source)) { b = this.options.source; this.source = function (c, e) { e(d.ui.autocomplete.filter(b, c.term)) } } else if (typeof this.options.source === "string") {
            f = this.options.source; this.source =
function (c, e) { a.xhr && a.xhr.abort(); a.xhr = d.ajax({ url: f, data: c, dataType: "json", success: function (g, h, i) { i === a.xhr && e(g); a.xhr = null }, error: function (g) { g === a.xhr && e([]); a.xhr = null } }) } 
        } else this.source = this.options.source
    }, search: function (a, b) { a = a != null ? a : this.element.val(); this.term = this.element.val(); if (a.length < this.options.minLength) return this.close(b); clearTimeout(this.closing); if (this._trigger("search", b) !== false) return this._search(a) }, _search: function (a) {
        this.element.addClass("ui-autocomplete-loading");
        this.source({ term: a }, this.response)
    }, _response: function (a) { if (a && a.length) { a = this._normalize(a); this._suggest(a); this._trigger("open") } else this.close(); this.element.removeClass("ui-autocomplete-loading") }, close: function (a) { clearTimeout(this.closing); if (this.menu.element.is(":visible")) { this.menu.element.hide(); this.menu.deactivate(); this._trigger("close", a) } }, _change: function (a) { this.previous !== this.element.val() && this._trigger("change", a, { item: this.selectedItem }) }, _normalize: function (a) {
        if (a.length &&
a[0].label && a[0].value) return a; return d.map(a, function (b) { if (typeof b === "string") return { label: b, value: b }; return d.extend({ label: b.label || b.value, value: b.value || b.label }, b) })
    }, _suggest: function (a) { var b = this.menu.element.empty().zIndex(this.element.zIndex() + 1); this._renderMenu(b, a); this.menu.deactivate(); this.menu.refresh(); b.show(); this._resizeMenu(); b.position(d.extend({ of: this.element }, this.options.position)) }, _resizeMenu: function () {
        var a = this.menu.element; a.outerWidth(Math.max(a.width("").outerWidth(),
this.element.outerWidth()))
    }, _renderMenu: function (a, b) { var f = this; d.each(b, function (c, e) { f._renderItem(a, e) }) }, _renderItem: function (a, b) { return d("<li></li>").data("item.autocomplete", b).append(d("<a></a>").text(b.label)).appendTo(a) }, _move: function (a, b) { if (this.menu.element.is(":visible")) if (this.menu.first() && /^previous/.test(a) || this.menu.last() && /^next/.test(a)) { this.element.val(this.term); this.menu.deactivate() } else this.menu[a](b); else this.search(null, b) }, widget: function () { return this.menu.element } 
    });
    d.extend(d.ui.autocomplete, { escapeRegex: function (a) { return a.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&") }, filter: function (a, b) { var f = new RegExp(d.ui.autocomplete.escapeRegex(b), "i"); return d.grep(a, function (c) { return f.test(c.label || c.value || c) }) } })
})(jQuery);
(function (d) {
    d.widget("ui.menu", { _create: function () { var a = this; this.element.addClass("ui-menu ui-widget ui-widget-content ui-corner-all").attr({ role: "listbox", "aria-activedescendant": "ui-active-menuitem" }).click(function (b) { if (d(b.target).closest(".ui-menu-item a").length) { b.preventDefault(); a.select(b) } }); this.refresh() }, refresh: function () {
        var a = this; this.element.children("li:not(.ui-menu-item):has(a)").addClass("ui-menu-item").attr("role", "menuitem").children("a").addClass("ui-corner-all").attr("tabindex",
-1).mouseenter(function (b) { a.activate(b, d(this).parent()) }).mouseleave(function () { a.deactivate() })
    }, activate: function (a, b) { this.deactivate(); if (this.hasScroll()) { var f = b.offset().top - this.element.offset().top, c = this.element.attr("scrollTop"), e = this.element.height(); if (f < 0) this.element.attr("scrollTop", c + f); else f >= e && this.element.attr("scrollTop", c + f - e + b.height()) } this.active = b.eq(0).children("a").addClass("ui-state-hover").attr("id", "ui-active-menuitem").end(); this._trigger("focus", a, { item: b }) },
        deactivate: function () { if (this.active) { this.active.children("a").removeClass("ui-state-hover").removeAttr("id"); this._trigger("blur"); this.active = null } }, next: function (a) { this.move("next", ".ui-menu-item:first", a) }, previous: function (a) { this.move("prev", ".ui-menu-item:last", a) }, first: function () { return this.active && !this.active.prevAll(".ui-menu-item").length }, last: function () { return this.active && !this.active.nextAll(".ui-menu-item").length }, move: function (a, b, f) {
            if (this.active) {
                a = this.active[a + "All"](".ui-menu-item").eq(0);
                a.length ? this.activate(f, a) : this.activate(f, this.element.children(b))
            } else this.activate(f, this.element.children(b))
        }, nextPage: function (a) {
            if (this.hasScroll()) if (!this.active || this.last()) this.activate(a, this.element.children(".ui-menu-item:first")); else {
                var b = this.active.offset().top, f = this.element.height(), c = this.element.children(".ui-menu-item").filter(function () { var e = d(this).offset().top - b - f + d(this).height(); return e < 10 && e > -10 }); c.length || (c = this.element.children(".ui-menu-item:last")); this.activate(a,
c)
            } else this.activate(a, this.element.children(".ui-menu-item").filter(!this.active || this.last() ? ":first" : ":last"))
        }, previousPage: function (a) {
            if (this.hasScroll()) if (!this.active || this.first()) this.activate(a, this.element.children(".ui-menu-item:last")); else {
                var b = this.active.offset().top, f = this.element.height(); result = this.element.children(".ui-menu-item").filter(function () { var c = d(this).offset().top - b + f - d(this).height(); return c < 10 && c > -10 }); result.length || (result = this.element.children(".ui-menu-item:first"));
                this.activate(a, result)
            } else this.activate(a, this.element.children(".ui-menu-item").filter(!this.active || this.first() ? ":last" : ":first"))
        }, hasScroll: function () { return this.element.height() < this.element.attr("scrollHeight") }, select: function (a) { this._trigger("selected", a, { item: this.active }) } 
    })
})(jQuery);
; /*
 * jQuery UI Button 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Button
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 */
(function (a) {
    var g, i = function (b) { a(":ui-button", b.target.form).each(function () { var c = a(this).data("button"); setTimeout(function () { c.refresh() }, 1) }) }, h = function (b) { var c = b.name, d = b.form, e = a([]); if (c) e = d ? a(d).find("[name='" + c + "']") : a("[name='" + c + "']", b.ownerDocument).filter(function () { return !this.form }); return e }; a.widget("ui.button", { options: { disabled: null, text: true, label: null, icons: { primary: null, secondary: null} }, _create: function () {
        this.element.closest("form").unbind("reset.button").bind("reset.button",
i); if (typeof this.options.disabled !== "boolean") this.options.disabled = this.element.attr("disabled"); this._determineButtonType(); this.hasTitle = !!this.buttonElement.attr("title"); var b = this, c = this.options, d = this.type === "checkbox" || this.type === "radio", e = "ui-state-hover" + (!d ? " ui-state-active" : ""); if (c.label === null) c.label = this.buttonElement.html(); if (this.element.is(":disabled")) c.disabled = true; this.buttonElement.addClass("ui-button ui-widget ui-state-default ui-corner-all").attr("role", "button").bind("mouseenter.button",
function () { if (!c.disabled) { a(this).addClass("ui-state-hover"); this === g && a(this).addClass("ui-state-active") } }).bind("mouseleave.button", function () { c.disabled || a(this).removeClass(e) }).bind("focus.button", function () { a(this).addClass("ui-state-focus") }).bind("blur.button", function () { a(this).removeClass("ui-state-focus") }); d && this.element.bind("change.button", function () { b.refresh() }); if (this.type === "checkbox") this.buttonElement.bind("click.button", function () {
    if (c.disabled) return false; a(this).toggleClass("ui-state-active");
    b.buttonElement.attr("aria-pressed", b.element[0].checked)
}); else if (this.type === "radio") this.buttonElement.bind("click.button", function () { if (c.disabled) return false; a(this).addClass("ui-state-active"); b.buttonElement.attr("aria-pressed", true); var f = b.element[0]; h(f).not(f).map(function () { return a(this).button("widget")[0] }).removeClass("ui-state-active").attr("aria-pressed", false) }); else {
            this.buttonElement.bind("mousedown.button", function () {
                if (c.disabled) return false; a(this).addClass("ui-state-active");
                g = this; a(document).one("mouseup", function () { g = null })
            }).bind("mouseup.button", function () { if (c.disabled) return false; a(this).removeClass("ui-state-active") }).bind("keydown.button", function (f) { if (c.disabled) return false; if (f.keyCode == a.ui.keyCode.SPACE || f.keyCode == a.ui.keyCode.ENTER) a(this).addClass("ui-state-active") }).bind("keyup.button", function () { a(this).removeClass("ui-state-active") }); this.buttonElement.is("a") && this.buttonElement.keyup(function (f) { f.keyCode === a.ui.keyCode.SPACE && a(this).click() })
        } this._setOption("disabled",
c.disabled)
    }, _determineButtonType: function () {
        this.type = this.element.is(":checkbox") ? "checkbox" : this.element.is(":radio") ? "radio" : this.element.is("input") ? "input" : "button"; if (this.type === "checkbox" || this.type === "radio") { this.buttonElement = this.element.parents().last().find("label[for=" + this.element.attr("id") + "]"); this.element.addClass("ui-helper-hidden-accessible"); var b = this.element.is(":checked"); b && this.buttonElement.addClass("ui-state-active"); this.buttonElement.attr("aria-pressed", b) } else this.buttonElement =
this.element
    }, widget: function () { return this.buttonElement }, destroy: function () {
        this.element.removeClass("ui-helper-hidden-accessible"); this.buttonElement.removeClass("ui-button ui-widget ui-state-default ui-corner-all ui-state-hover ui-state-active  ui-button-icons-only ui-button-icon-only ui-button-text-icons ui-button-text-icon-primary ui-button-text-icon-secondary ui-button-text-only").removeAttr("role").removeAttr("aria-pressed").html(this.buttonElement.find(".ui-button-text").html()); this.hasTitle ||
this.buttonElement.removeAttr("title"); a.Widget.prototype.destroy.call(this)
    }, _setOption: function (b, c) { a.Widget.prototype._setOption.apply(this, arguments); if (b === "disabled") c ? this.element.attr("disabled", true) : this.element.removeAttr("disabled"); this._resetButton() }, refresh: function () {
        var b = this.element.is(":disabled"); b !== this.options.disabled && this._setOption("disabled", b); if (this.type === "radio") h(this.element[0]).each(function () {
            a(this).is(":checked") ? a(this).button("widget").addClass("ui-state-active").attr("aria-pressed",
true) : a(this).button("widget").removeClass("ui-state-active").attr("aria-pressed", false)
        }); else if (this.type === "checkbox") this.element.is(":checked") ? this.buttonElement.addClass("ui-state-active").attr("aria-pressed", true) : this.buttonElement.removeClass("ui-state-active").attr("aria-pressed", false)
    }, _resetButton: function () {
        if (this.type === "input") this.options.label && this.element.val(this.options.label); else {
            var b = this.buttonElement.removeClass("ui-button-icons-only ui-button-icon-only ui-button-text-icons ui-button-text-icon-primary ui-button-text-icon-secondary ui-button-text-only"),
c = a("<span></span>").addClass("ui-button-text").html(this.options.label).appendTo(b.empty()).text(), d = this.options.icons, e = d.primary && d.secondary; if (d.primary || d.secondary) {
                b.addClass("ui-button-text-icon" + (e ? "s" : d.primary ? "-primary" : "-secondary")); d.primary && b.prepend("<span class='ui-button-icon-primary ui-icon " + d.primary + "'></span>"); d.secondary && b.append("<span class='ui-button-icon-secondary ui-icon " + d.secondary + "'></span>"); if (!this.options.text) {
                    b.addClass(e ? "ui-button-icons-only" : "ui-button-icon-only").removeClass("ui-button-text-icons ui-button-text-icon-primary ui-button-text-icon-secondary");
                    this.hasTitle || b.attr("title", c)
                } 
            } else b.addClass("ui-button-text-only")
        } 
    } 
    }); a.widget("ui.buttonset", { options: { items: ":button, :submit, :reset, :checkbox, :radio, a, :data(button)" }, _create: function () { this.element.addClass("ui-buttonset") }, _init: function () { this.refresh() }, _setOption: function (b, c) { b === "disabled" && this.buttons.button("option", b, c); a.Widget.prototype._setOption.apply(this, arguments) }, refresh: function () { this.buttons = this.element.find(this.options.items).filter(":ui-button").button("refresh").end().not(":ui-button").button().end().map(function () { return a(this).button("widget")[0] }).removeClass("ui-corner-all ui-corner-left ui-corner-right").filter(":first").addClass("ui-corner-left").end().filter(":last").addClass("ui-corner-right").end().end() },
        destroy: function () { this.element.removeClass("ui-buttonset"); this.buttons.map(function () { return a(this).button("widget")[0] }).removeClass("ui-corner-left ui-corner-right").end().button("destroy"); a.Widget.prototype.destroy.call(this) } 
    })
})(jQuery);
; /*
 * jQuery UI Dialog 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Dialog
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 *  jquery.ui.button.js
 *	jquery.ui.draggable.js
 *	jquery.ui.mouse.js
 *	jquery.ui.position.js
 *	jquery.ui.resizable.js
 */
(function (c, j) {
    var k = { buttons: true, height: true, maxHeight: true, maxWidth: true, minHeight: true, minWidth: true, width: true }, l = { maxHeight: true, maxWidth: true, minHeight: true, minWidth: true }; c.widget("ui.dialog", { options: { autoOpen: true, buttons: {}, closeOnEscape: true, closeText: "close", dialogClass: "", draggable: true, hide: null, height: "auto", maxHeight: false, maxWidth: false, minHeight: 150, minWidth: 150, modal: false, position: { my: "center", at: "center", collision: "fit", using: function (a) {
        var b = c(this).css(a).offset().top; b < 0 &&
c(this).css("top", a.top - b)
    } 
    }, resizable: true, show: null, stack: true, title: "", width: 300, zIndex: 1E3
    }, _create: function () {
        this.originalTitle = this.element.attr("title"); if (typeof this.originalTitle !== "string") this.originalTitle = ""; this.options.title = this.options.title || this.originalTitle; var a = this, b = a.options, d = b.title || "&#160;", e = c.ui.dialog.getTitleId(a.element), g = (a.uiDialog = c("<div></div>")).appendTo(document.body).hide().addClass("ui-dialog ui-widget ui-widget-content ui-corner-all " + b.dialogClass).css({ zIndex: b.zIndex }).attr("tabIndex",
-1).css("outline", 0).keydown(function (i) { if (b.closeOnEscape && i.keyCode && i.keyCode === c.ui.keyCode.ESCAPE) { a.close(i); i.preventDefault() } }).attr({ role: "dialog", "aria-labelledby": e }).mousedown(function (i) { a.moveToTop(false, i) }); a.element.show().removeAttr("title").addClass("ui-dialog-content ui-widget-content").appendTo(g); var f = (a.uiDialogTitlebar = c("<div></div>")).addClass("ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix").prependTo(g), h = c('<a href="#"></a>').addClass("ui-dialog-titlebar-close ui-corner-all").attr("role",
"button").hover(function () { h.addClass("ui-state-hover") }, function () { h.removeClass("ui-state-hover") }).focus(function () { h.addClass("ui-state-focus") }).blur(function () { h.removeClass("ui-state-focus") }).click(function (i) { a.close(i); return false }).appendTo(f); (a.uiDialogTitlebarCloseText = c("<span></span>")).addClass("ui-icon ui-icon-closethick").text(b.closeText).appendTo(h); c("<span></span>").addClass("ui-dialog-title").attr("id", e).html(d).prependTo(f); if (c.isFunction(b.beforeclose) && !c.isFunction(b.beforeClose)) b.beforeClose =
b.beforeclose; f.find("*").add(f).disableSelection(); b.draggable && c.fn.draggable && a._makeDraggable(); b.resizable && c.fn.resizable && a._makeResizable(); a._createButtons(b.buttons); a._isOpen = false; c.fn.bgiframe && g.bgiframe()
    }, _init: function () { this.options.autoOpen && this.open() }, destroy: function () {
        var a = this; a.overlay && a.overlay.destroy(); a.uiDialog.hide(); a.element.unbind(".dialog").removeData("dialog").removeClass("ui-dialog-content ui-widget-content").hide().appendTo("body"); a.uiDialog.remove(); a.originalTitle &&
a.element.attr("title", a.originalTitle); return a
    }, widget: function () { return this.uiDialog }, close: function (a) {
        var b = this, d, e; if (false !== b._trigger("beforeClose", a)) {
            b.overlay && b.overlay.destroy(); b.uiDialog.unbind("keypress.ui-dialog"); b._isOpen = false; if (b.options.hide) b.uiDialog.hide(b.options.hide, function () { b._trigger("close", a) }); else { b.uiDialog.hide(); b._trigger("close", a) } c.ui.dialog.overlay.resize(); if (b.options.modal) {
                d = 0; c(".ui-dialog").each(function () {
                    if (this !== b.uiDialog[0]) {
                        e = c(this).css("z-index");
                        isNaN(e) || (d = Math.max(d, e))
                    } 
                }); c.ui.dialog.maxZ = d
            } return b
        } 
    }, isOpen: function () { return this._isOpen }, moveToTop: function (a, b) {
        var d = this, e = d.options; if (e.modal && !a || !e.stack && !e.modal) return d._trigger("focus", b); if (e.zIndex > c.ui.dialog.maxZ) c.ui.dialog.maxZ = e.zIndex; if (d.overlay) { c.ui.dialog.maxZ += 1; d.overlay.$el.css("z-index", c.ui.dialog.overlay.maxZ = c.ui.dialog.maxZ) } a = { scrollTop: d.element.attr("scrollTop"), scrollLeft: d.element.attr("scrollLeft") }; c.ui.dialog.maxZ += 1; d.uiDialog.css("z-index", c.ui.dialog.maxZ);
        d.element.attr(a); d._trigger("focus", b); return d
    }, open: function () {
        if (!this._isOpen) {
            var a = this, b = a.options, d = a.uiDialog; a.overlay = b.modal ? new c.ui.dialog.overlay(a) : null; a._size(); a._position(b.position); d.show(b.show); a.moveToTop(true); b.modal && d.bind("keypress.ui-dialog", function (e) { if (e.keyCode === c.ui.keyCode.TAB) { var g = c(":tabbable", this), f = g.filter(":first"); g = g.filter(":last"); if (e.target === g[0] && !e.shiftKey) { f.focus(1); return false } else if (e.target === f[0] && e.shiftKey) { g.focus(1); return false } } });
            c(a.element.find(":tabbable").get().concat(d.find(".ui-dialog-buttonpane :tabbable").get().concat(d.get()))).eq(0).focus(); a._isOpen = true; a._trigger("open"); return a
        } 
    }, _createButtons: function (a) {
        var b = this, d = false, e = c("<div></div>").addClass("ui-dialog-buttonpane ui-widget-content ui-helper-clearfix"), g = c("<div></div>").addClass("ui-dialog-buttonset").appendTo(e); b.uiDialog.find(".ui-dialog-buttonpane").remove(); typeof a === "object" && a !== null && c.each(a, function () { return !(d = true) }); if (d) {
            c.each(a, function (f,
h) { h = c.isFunction(h) ? { click: h, text: f} : h; f = c('<button type="button"></button>').attr(h, true).unbind("click").click(function () { h.click.apply(b.element[0], arguments) }).appendTo(g); c.fn.button && f.button() }); e.appendTo(b.uiDialog)
        } 
    }, _makeDraggable: function () {
        function a(f) { return { position: f.position, offset: f.offset} } var b = this, d = b.options, e = c(document), g; b.uiDialog.draggable({ cancel: ".ui-dialog-content, .ui-dialog-titlebar-close", handle: ".ui-dialog-titlebar", containment: "document", start: function (f, h) {
            g =
d.height === "auto" ? "auto" : c(this).height(); c(this).height(c(this).height()).addClass("ui-dialog-dragging"); b._trigger("dragStart", f, a(h))
        }, drag: function (f, h) { b._trigger("drag", f, a(h)) }, stop: function (f, h) { d.position = [h.position.left - e.scrollLeft(), h.position.top - e.scrollTop()]; c(this).removeClass("ui-dialog-dragging").height(g); b._trigger("dragStop", f, a(h)); c.ui.dialog.overlay.resize() } 
        })
    }, _makeResizable: function (a) {
        function b(f) {
            return { originalPosition: f.originalPosition, originalSize: f.originalSize,
                position: f.position, size: f.size
            }
        } a = a === j ? this.options.resizable : a; var d = this, e = d.options, g = d.uiDialog.css("position"); a = typeof a === "string" ? a : "n,e,s,w,se,sw,ne,nw"; d.uiDialog.resizable({ cancel: ".ui-dialog-content", containment: "document", alsoResize: d.element, maxWidth: e.maxWidth, maxHeight: e.maxHeight, minWidth: e.minWidth, minHeight: d._minHeight(), handles: a, start: function (f, h) { c(this).addClass("ui-dialog-resizing"); d._trigger("resizeStart", f, b(h)) }, resize: function (f, h) { d._trigger("resize", f, b(h)) }, stop: function (f,
h) { c(this).removeClass("ui-dialog-resizing"); e.height = c(this).height(); e.width = c(this).width(); d._trigger("resizeStop", f, b(h)); c.ui.dialog.overlay.resize() } 
        }).css("position", g).find(".ui-resizable-se").addClass("ui-icon ui-icon-grip-diagonal-se")
    }, _minHeight: function () { var a = this.options; return a.height === "auto" ? a.minHeight : Math.min(a.minHeight, a.height) }, _position: function (a) {
        var b = [], d = [0, 0], e; if (a) {
            if (typeof a === "string" || typeof a === "object" && "0" in a) {
                b = a.split ? a.split(" ") : [a[0], a[1]]; if (b.length ===
1) b[1] = b[0]; c.each(["left", "top"], function (g, f) { if (+b[g] === b[g]) { d[g] = b[g]; b[g] = f } }); a = { my: b.join(" "), at: b.join(" "), offset: d.join(" ")}
            } a = c.extend({}, c.ui.dialog.prototype.options.position, a)
        } else a = c.ui.dialog.prototype.options.position; (e = this.uiDialog.is(":visible")) || this.uiDialog.show(); this.uiDialog.css({ top: 0, left: 0 }).position(c.extend({ of: window }, a)); e || this.uiDialog.hide()
    }, _setOptions: function (a) {
        var b = this, d = {}, e = false; c.each(a, function (g, f) {
            b._setOption(g, f); if (g in k) e = true; if (g in
l) d[g] = f
        }); e && this._size(); this.uiDialog.is(":data(resizable)") && this.uiDialog.resizable("option", d)
    }, _setOption: function (a, b) {
        var d = this, e = d.uiDialog; switch (a) {
            case "beforeclose": a = "beforeClose"; break; case "buttons": d._createButtons(b); break; case "closeText": d.uiDialogTitlebarCloseText.text("" + b); break; case "dialogClass": e.removeClass(d.options.dialogClass).addClass("ui-dialog ui-widget ui-widget-content ui-corner-all " + b); break; case "disabled": b ? e.addClass("ui-dialog-disabled") : e.removeClass("ui-dialog-disabled");
                break; case "draggable": var g = e.is(":data(draggable)"); g && !b && e.draggable("destroy"); !g && b && d._makeDraggable(); break; case "position": d._position(b); break; case "resizable": (g = e.is(":data(resizable)")) && !b && e.resizable("destroy"); g && typeof b === "string" && e.resizable("option", "handles", b); !g && b !== false && d._makeResizable(b); break; case "title": c(".ui-dialog-title", d.uiDialogTitlebar).html("" + (b || "&#160;")); break
        } c.Widget.prototype._setOption.apply(d, arguments)
    }, _size: function () {
        var a = this.options, b, d, e =
this.uiDialog.is(":visible"); this.element.show().css({ width: "auto", minHeight: 0, height: 0 }); if (a.minWidth > a.width) a.width = a.minWidth; b = this.uiDialog.css({ height: "auto", width: a.width }).height(); d = Math.max(0, a.minHeight - b); if (a.height === "auto") if (c.support.minHeight) this.element.css({ minHeight: d, height: "auto" }); else { this.uiDialog.show(); a = this.element.css("height", "auto").height(); e || this.uiDialog.hide(); this.element.height(Math.max(a, d)) } else this.element.height(Math.max(a.height - b, 0)); this.uiDialog.is(":data(resizable)") &&
this.uiDialog.resizable("option", "minHeight", this._minHeight())
    } 
    }); c.extend(c.ui.dialog, { version: "1.8.7", uuid: 0, maxZ: 0, getTitleId: function (a) { a = a.attr("id"); if (!a) { this.uuid += 1; a = this.uuid } return "ui-dialog-title-" + a }, overlay: function (a) { this.$el = c.ui.dialog.overlay.create(a) } }); c.extend(c.ui.dialog.overlay, { instances: [], oldInstances: [], maxZ: 0, events: c.map("focus,mousedown,mouseup,keydown,keypress,click".split(","), function (a) { return a + ".dialog-overlay" }).join(" "), create: function (a) {
        if (this.instances.length ===
0) { setTimeout(function () { c.ui.dialog.overlay.instances.length && c(document).bind(c.ui.dialog.overlay.events, function (d) { if (c(d.target).zIndex() < c.ui.dialog.overlay.maxZ) return false }) }, 1); c(document).bind("keydown.dialog-overlay", function (d) { if (a.options.closeOnEscape && d.keyCode && d.keyCode === c.ui.keyCode.ESCAPE) { a.close(d); d.preventDefault() } }); c(window).bind("resize.dialog-overlay", c.ui.dialog.overlay.resize) } var b = (this.oldInstances.pop() || c("<div></div>").addClass("ui-widget-overlay")).appendTo(document.body).css({ width: this.width(),
    height: this.height()
}); c.fn.bgiframe && b.bgiframe(); this.instances.push(b); return b
    }, destroy: function (a) { var b = c.inArray(a, this.instances); b != -1 && this.oldInstances.push(this.instances.splice(b, 1)[0]); this.instances.length === 0 && c([document, window]).unbind(".dialog-overlay"); a.remove(); var d = 0; c.each(this.instances, function () { d = Math.max(d, this.css("z-index")) }); this.maxZ = d }, height: function () {
        var a, b; if (c.browser.msie && c.browser.version < 7) {
            a = Math.max(document.documentElement.scrollHeight, document.body.scrollHeight);
            b = Math.max(document.documentElement.offsetHeight, document.body.offsetHeight); return a < b ? c(window).height() + "px" : a + "px"
        } else return c(document).height() + "px"
    }, width: function () { var a, b; if (c.browser.msie && c.browser.version < 7) { a = Math.max(document.documentElement.scrollWidth, document.body.scrollWidth); b = Math.max(document.documentElement.offsetWidth, document.body.offsetWidth); return a < b ? c(window).width() + "px" : a + "px" } else return c(document).width() + "px" }, resize: function () {
        var a = c([]); c.each(c.ui.dialog.overlay.instances,
function () { a = a.add(this) }); a.css({ width: 0, height: 0 }).css({ width: c.ui.dialog.overlay.width(), height: c.ui.dialog.overlay.height() })
    } 
    }); c.extend(c.ui.dialog.overlay.prototype, { destroy: function () { c.ui.dialog.overlay.destroy(this.$el) } })
})(jQuery);
; /*
 * jQuery UI Slider 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Slider
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.mouse.js
 *	jquery.ui.widget.js
 */
(function (d) {
    d.widget("ui.slider", d.ui.mouse, { widgetEventPrefix: "slide", options: { animate: false, distance: 0, max: 100, min: 0, orientation: "horizontal", range: false, step: 1, value: 0, values: null }, _create: function () {
        var b = this, a = this.options; this._mouseSliding = this._keySliding = false; this._animateOff = true; this._handleIndex = null; this._detectOrientation(); this._mouseInit(); this.element.addClass("ui-slider ui-slider-" + this.orientation + " ui-widget ui-widget-content ui-corner-all"); a.disabled && this.element.addClass("ui-slider-disabled ui-disabled");
        this.range = d([]); if (a.range) { if (a.range === true) { this.range = d("<div></div>"); if (!a.values) a.values = [this._valueMin(), this._valueMin()]; if (a.values.length && a.values.length !== 2) a.values = [a.values[0], a.values[0]] } else this.range = d("<div></div>"); this.range.appendTo(this.element).addClass("ui-slider-range"); if (a.range === "min" || a.range === "max") this.range.addClass("ui-slider-range-" + a.range); this.range.addClass("ui-widget-header") } d(".ui-slider-handle", this.element).length === 0 && d("<a href='#'></a>").appendTo(this.element).addClass("ui-slider-handle");
        if (a.values && a.values.length) for (; d(".ui-slider-handle", this.element).length < a.values.length; ) d("<a href='#'></a>").appendTo(this.element).addClass("ui-slider-handle"); this.handles = d(".ui-slider-handle", this.element).addClass("ui-state-default ui-corner-all"); this.handle = this.handles.eq(0); this.handles.add(this.range).filter("a").click(function (c) { c.preventDefault() }).hover(function () { a.disabled || d(this).addClass("ui-state-hover") }, function () { d(this).removeClass("ui-state-hover") }).focus(function () {
            if (a.disabled) d(this).blur();
            else { d(".ui-slider .ui-state-focus").removeClass("ui-state-focus"); d(this).addClass("ui-state-focus") } 
        }).blur(function () { d(this).removeClass("ui-state-focus") }); this.handles.each(function (c) { d(this).data("index.ui-slider-handle", c) }); this.handles.keydown(function (c) {
            var e = true, f = d(this).data("index.ui-slider-handle"), h, g, i; if (!b.options.disabled) {
                switch (c.keyCode) {
                    case d.ui.keyCode.HOME: case d.ui.keyCode.END: case d.ui.keyCode.PAGE_UP: case d.ui.keyCode.PAGE_DOWN: case d.ui.keyCode.UP: case d.ui.keyCode.RIGHT: case d.ui.keyCode.DOWN: case d.ui.keyCode.LEFT: e =
false; if (!b._keySliding) { b._keySliding = true; d(this).addClass("ui-state-active"); h = b._start(c, f); if (h === false) return } break
                } i = b.options.step; h = b.options.values && b.options.values.length ? (g = b.values(f)) : (g = b.value()); switch (c.keyCode) {
                    case d.ui.keyCode.HOME: g = b._valueMin(); break; case d.ui.keyCode.END: g = b._valueMax(); break; case d.ui.keyCode.PAGE_UP: g = b._trimAlignValue(h + (b._valueMax() - b._valueMin()) / 5); break; case d.ui.keyCode.PAGE_DOWN: g = b._trimAlignValue(h - (b._valueMax() - b._valueMin()) / 5); break; case d.ui.keyCode.UP: case d.ui.keyCode.RIGHT: if (h ===
b._valueMax()) return; g = b._trimAlignValue(h + i); break; case d.ui.keyCode.DOWN: case d.ui.keyCode.LEFT: if (h === b._valueMin()) return; g = b._trimAlignValue(h - i); break
                } b._slide(c, f, g); return e
            } 
        }).keyup(function (c) { var e = d(this).data("index.ui-slider-handle"); if (b._keySliding) { b._keySliding = false; b._stop(c, e); b._change(c, e); d(this).removeClass("ui-state-active") } }); this._refreshValue(); this._animateOff = false
    }, destroy: function () {
        this.handles.remove(); this.range.remove(); this.element.removeClass("ui-slider ui-slider-horizontal ui-slider-vertical ui-slider-disabled ui-widget ui-widget-content ui-corner-all").removeData("slider").unbind(".slider");
        this._mouseDestroy(); return this
    }, _mouseCapture: function (b) {
        var a = this.options, c, e, f, h, g; if (a.disabled) return false; this.elementSize = { width: this.element.outerWidth(), height: this.element.outerHeight() }; this.elementOffset = this.element.offset(); c = this._normValueFromMouse({ x: b.pageX, y: b.pageY }); e = this._valueMax() - this._valueMin() + 1; h = this; this.handles.each(function (i) { var j = Math.abs(c - h.values(i)); if (e > j) { e = j; f = d(this); g = i } }); if (a.range === true && this.values(1) === a.min) { g += 1; f = d(this.handles[g]) } if (this._start(b,
g) === false) return false; this._mouseSliding = true; h._handleIndex = g; f.addClass("ui-state-active").focus(); a = f.offset(); this._clickOffset = !d(b.target).parents().andSelf().is(".ui-slider-handle") ? { left: 0, top: 0} : { left: b.pageX - a.left - f.width() / 2, top: b.pageY - a.top - f.height() / 2 - (parseInt(f.css("borderTopWidth"), 10) || 0) - (parseInt(f.css("borderBottomWidth"), 10) || 0) + (parseInt(f.css("marginTop"), 10) || 0) }; this.handles.hasClass("ui-state-hover") || this._slide(b, g, c); return this._animateOff = true
    }, _mouseStart: function () { return true },
        _mouseDrag: function (b) { var a = this._normValueFromMouse({ x: b.pageX, y: b.pageY }); this._slide(b, this._handleIndex, a); return false }, _mouseStop: function (b) { this.handles.removeClass("ui-state-active"); this._mouseSliding = false; this._stop(b, this._handleIndex); this._change(b, this._handleIndex); this._clickOffset = this._handleIndex = null; return this._animateOff = false }, _detectOrientation: function () { this.orientation = this.options.orientation === "vertical" ? "vertical" : "horizontal" }, _normValueFromMouse: function (b) {
            var a;
            if (this.orientation === "horizontal") { a = this.elementSize.width; b = b.x - this.elementOffset.left - (this._clickOffset ? this._clickOffset.left : 0) } else { a = this.elementSize.height; b = b.y - this.elementOffset.top - (this._clickOffset ? this._clickOffset.top : 0) } a = b / a; if (a > 1) a = 1; if (a < 0) a = 0; if (this.orientation === "vertical") a = 1 - a; b = this._valueMax() - this._valueMin(); return this._trimAlignValue(this._valueMin() + a * b)
        }, _start: function (b, a) {
            var c = { handle: this.handles[a], value: this.value() }; if (this.options.values && this.options.values.length) {
                c.value =
this.values(a); c.values = this.values()
            } return this._trigger("start", b, c)
        }, _slide: function (b, a, c) {
            var e; if (this.options.values && this.options.values.length) { e = this.values(a ? 0 : 1); if (this.options.values.length === 2 && this.options.range === true && (a === 0 && c > e || a === 1 && c < e)) c = e; if (c !== this.values(a)) { e = this.values(); e[a] = c; b = this._trigger("slide", b, { handle: this.handles[a], value: c, values: e }); this.values(a ? 0 : 1); b !== false && this.values(a, c, true) } } else if (c !== this.value()) {
                b = this._trigger("slide", b, { handle: this.handles[a],
                    value: c
                }); b !== false && this.value(c)
            } 
        }, _stop: function (b, a) { var c = { handle: this.handles[a], value: this.value() }; if (this.options.values && this.options.values.length) { c.value = this.values(a); c.values = this.values() } this._trigger("stop", b, c) }, _change: function (b, a) { if (!this._keySliding && !this._mouseSliding) { var c = { handle: this.handles[a], value: this.value() }; if (this.options.values && this.options.values.length) { c.value = this.values(a); c.values = this.values() } this._trigger("change", b, c) } }, value: function (b) {
            if (arguments.length) {
                this.options.value =
this._trimAlignValue(b); this._refreshValue(); this._change(null, 0)
            } return this._value()
        }, values: function (b, a) {
            var c, e, f; if (arguments.length > 1) { this.options.values[b] = this._trimAlignValue(a); this._refreshValue(); this._change(null, b) } if (arguments.length) if (d.isArray(arguments[0])) { c = this.options.values; e = arguments[0]; for (f = 0; f < c.length; f += 1) { c[f] = this._trimAlignValue(e[f]); this._change(null, f) } this._refreshValue() } else return this.options.values && this.options.values.length ? this._values(b) : this.value();
            else return this._values()
        }, _setOption: function (b, a) {
            var c, e = 0; if (d.isArray(this.options.values)) e = this.options.values.length; d.Widget.prototype._setOption.apply(this, arguments); switch (b) {
                case "disabled": if (a) { this.handles.filter(".ui-state-focus").blur(); this.handles.removeClass("ui-state-hover"); this.handles.attr("disabled", "disabled"); this.element.addClass("ui-disabled") } else { this.handles.removeAttr("disabled"); this.element.removeClass("ui-disabled") } break; case "orientation": this._detectOrientation();
                    this.element.removeClass("ui-slider-horizontal ui-slider-vertical").addClass("ui-slider-" + this.orientation); this._refreshValue(); break; case "value": this._animateOff = true; this._refreshValue(); this._change(null, 0); this._animateOff = false; break; case "values": this._animateOff = true; this._refreshValue(); for (c = 0; c < e; c += 1) this._change(null, c); this._animateOff = false; break
            } 
        }, _value: function () { var b = this.options.value; return b = this._trimAlignValue(b) }, _values: function (b) {
            var a, c; if (arguments.length) {
                a = this.options.values[b];
                return a = this._trimAlignValue(a)
            } else { a = this.options.values.slice(); for (c = 0; c < a.length; c += 1) a[c] = this._trimAlignValue(a[c]); return a } 
        }, _trimAlignValue: function (b) { if (b <= this._valueMin()) return this._valueMin(); if (b >= this._valueMax()) return this._valueMax(); var a = this.options.step > 0 ? this.options.step : 1, c = (b - this._valueMin()) % a; alignValue = b - c; if (Math.abs(c) * 2 >= a) alignValue += c > 0 ? a : -a; return parseFloat(alignValue.toFixed(5)) }, _valueMin: function () { return this.options.min }, _valueMax: function () { return this.options.max },
        _refreshValue: function () {
            var b = this.options.range, a = this.options, c = this, e = !this._animateOff ? a.animate : false, f, h = {}, g, i, j, l; if (this.options.values && this.options.values.length) this.handles.each(function (k) {
                f = (c.values(k) - c._valueMin()) / (c._valueMax() - c._valueMin()) * 100; h[c.orientation === "horizontal" ? "left" : "bottom"] = f + "%"; d(this).stop(1, 1)[e ? "animate" : "css"](h, a.animate); if (c.options.range === true) if (c.orientation === "horizontal") {
                    if (k === 0) c.range.stop(1, 1)[e ? "animate" : "css"]({ left: f + "%" }, a.animate);
                    if (k === 1) c.range[e ? "animate" : "css"]({ width: f - g + "%" }, { queue: false, duration: a.animate })
                } else { if (k === 0) c.range.stop(1, 1)[e ? "animate" : "css"]({ bottom: f + "%" }, a.animate); if (k === 1) c.range[e ? "animate" : "css"]({ height: f - g + "%" }, { queue: false, duration: a.animate }) } g = f
            }); else {
                i = this.value(); j = this._valueMin(); l = this._valueMax(); f = l !== j ? (i - j) / (l - j) * 100 : 0; h[c.orientation === "horizontal" ? "left" : "bottom"] = f + "%"; this.handle.stop(1, 1)[e ? "animate" : "css"](h, a.animate); if (b === "min" && this.orientation === "horizontal") this.range.stop(1,
1)[e ? "animate" : "css"]({ width: f + "%" }, a.animate); if (b === "max" && this.orientation === "horizontal") this.range[e ? "animate" : "css"]({ width: 100 - f + "%" }, { queue: false, duration: a.animate }); if (b === "min" && this.orientation === "vertical") this.range.stop(1, 1)[e ? "animate" : "css"]({ height: f + "%" }, a.animate); if (b === "max" && this.orientation === "vertical") this.range[e ? "animate" : "css"]({ height: 100 - f + "%" }, { queue: false, duration: a.animate })
            } 
        } 
    }); d.extend(d.ui.slider, { version: "1.8.7" })
})(jQuery);
; /*
 * jQuery UI Tabs 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Tabs
 *
 * Depends:
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 */
(function (d, p) {
    function u() { return ++v } function w() { return ++x } var v = 0, x = 0; d.widget("ui.tabs", { options: { add: null, ajaxOptions: null, cache: false, cookie: null, collapsible: false, disable: null, disabled: [], enable: null, event: "click", fx: null, idPrefix: "ui-tabs-", load: null, panelTemplate: "<div></div>", remove: null, select: null, show: null, spinner: "<em>Loading&#8230;</em>", tabTemplate: "<li><a href='#{href}'><span>#{label}</span></a></li>" }, _create: function () { this._tabify(true) }, _setOption: function (b, e) {
        if (b == "selected") this.options.collapsible &&
e == this.options.selected || this.select(e); else { this.options[b] = e; this._tabify() } 
    }, _tabId: function (b) { return b.title && b.title.replace(/\s/g, "_").replace(/[^\w\u00c0-\uFFFF-]/g, "") || this.options.idPrefix + u() }, _sanitizeSelector: function (b) { return b.replace(/:/g, "\\:") }, _cookie: function () { var b = this.cookie || (this.cookie = this.options.cookie.name || "ui-tabs-" + w()); return d.cookie.apply(null, [b].concat(d.makeArray(arguments))) }, _ui: function (b, e) { return { tab: b, panel: e, index: this.anchors.index(b)} }, _cleanup: function () {
        this.lis.filter(".ui-state-processing").removeClass("ui-state-processing").find("span:data(label.tabs)").each(function () {
            var b =
d(this); b.html(b.data("label.tabs")).removeData("label.tabs")
        })
    }, _tabify: function (b) {
        function e(g, f) { g.css("display", ""); !d.support.opacity && f.opacity && g[0].style.removeAttribute("filter") } var a = this, c = this.options, h = /^#.+/; this.list = this.element.find("ol,ul").eq(0); this.lis = d(" > li:has(a[href])", this.list); this.anchors = this.lis.map(function () { return d("a", this)[0] }); this.panels = d([]); this.anchors.each(function (g, f) {
            var i = d(f).attr("href"), l = i.split("#")[0], q; if (l && (l === location.toString().split("#")[0] ||
(q = d("base")[0]) && l === q.href)) { i = f.hash; f.href = i } if (h.test(i)) a.panels = a.panels.add(a.element.find(a._sanitizeSelector(i))); else if (i && i !== "#") { d.data(f, "href.tabs", i); d.data(f, "load.tabs", i.replace(/#.*$/, "")); i = a._tabId(f); f.href = "#" + i; f = a.element.find("#" + i); if (!f.length) { f = d(c.panelTemplate).attr("id", i).addClass("ui-tabs-panel ui-widget-content ui-corner-bottom").insertAfter(a.panels[g - 1] || a.list); f.data("destroy.tabs", true) } a.panels = a.panels.add(f) } else c.disabled.push(g)
        }); if (b) {
            this.element.addClass("ui-tabs ui-widget ui-widget-content ui-corner-all");
            this.list.addClass("ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all"); this.lis.addClass("ui-state-default ui-corner-top"); this.panels.addClass("ui-tabs-panel ui-widget-content ui-corner-bottom"); if (c.selected === p) {
                location.hash && this.anchors.each(function (g, f) { if (f.hash == location.hash) { c.selected = g; return false } }); if (typeof c.selected !== "number" && c.cookie) c.selected = parseInt(a._cookie(), 10); if (typeof c.selected !== "number" && this.lis.filter(".ui-tabs-selected").length) c.selected =
this.lis.index(this.lis.filter(".ui-tabs-selected")); c.selected = c.selected || (this.lis.length ? 0 : -1)
            } else if (c.selected === null) c.selected = -1; c.selected = c.selected >= 0 && this.anchors[c.selected] || c.selected < 0 ? c.selected : 0; c.disabled = d.unique(c.disabled.concat(d.map(this.lis.filter(".ui-state-disabled"), function (g) { return a.lis.index(g) }))).sort(); d.inArray(c.selected, c.disabled) != -1 && c.disabled.splice(d.inArray(c.selected, c.disabled), 1); this.panels.addClass("ui-tabs-hide"); this.lis.removeClass("ui-tabs-selected ui-state-active");
            if (c.selected >= 0 && this.anchors.length) { a.element.find(a._sanitizeSelector(a.anchors[c.selected].hash)).removeClass("ui-tabs-hide"); this.lis.eq(c.selected).addClass("ui-tabs-selected ui-state-active"); a.element.queue("tabs", function () { a._trigger("show", null, a._ui(a.anchors[c.selected], a.element.find(a._sanitizeSelector(a.anchors[c.selected].hash)))) }); this.load(c.selected) } d(window).bind("unload", function () { a.lis.add(a.anchors).unbind(".tabs"); a.lis = a.anchors = a.panels = null })
        } else c.selected = this.lis.index(this.lis.filter(".ui-tabs-selected"));
        this.element[c.collapsible ? "addClass" : "removeClass"]("ui-tabs-collapsible"); c.cookie && this._cookie(c.selected, c.cookie); b = 0; for (var j; j = this.lis[b]; b++) d(j)[d.inArray(b, c.disabled) != -1 && !d(j).hasClass("ui-tabs-selected") ? "addClass" : "removeClass"]("ui-state-disabled"); c.cache === false && this.anchors.removeData("cache.tabs"); this.lis.add(this.anchors).unbind(".tabs"); if (c.event !== "mouseover") {
            var k = function (g, f) { f.is(":not(.ui-state-disabled)") && f.addClass("ui-state-" + g) }, n = function (g, f) {
                f.removeClass("ui-state-" +
g)
            }; this.lis.bind("mouseover.tabs", function () { k("hover", d(this)) }); this.lis.bind("mouseout.tabs", function () { n("hover", d(this)) }); this.anchors.bind("focus.tabs", function () { k("focus", d(this).closest("li")) }); this.anchors.bind("blur.tabs", function () { n("focus", d(this).closest("li")) })
        } var m, o; if (c.fx) if (d.isArray(c.fx)) { m = c.fx[0]; o = c.fx[1] } else m = o = c.fx; var r = o ? function (g, f) {
            d(g).closest("li").addClass("ui-tabs-selected ui-state-active"); f.hide().removeClass("ui-tabs-hide").animate(o, o.duration || "normal",
function () { e(f, o); a._trigger("show", null, a._ui(g, f[0])) })
        } : function (g, f) { d(g).closest("li").addClass("ui-tabs-selected ui-state-active"); f.removeClass("ui-tabs-hide"); a._trigger("show", null, a._ui(g, f[0])) }, s = m ? function (g, f) { f.animate(m, m.duration || "normal", function () { a.lis.removeClass("ui-tabs-selected ui-state-active"); f.addClass("ui-tabs-hide"); e(f, m); a.element.dequeue("tabs") }) } : function (g, f) { a.lis.removeClass("ui-tabs-selected ui-state-active"); f.addClass("ui-tabs-hide"); a.element.dequeue("tabs") };
        this.anchors.bind(c.event + ".tabs", function () {
            var g = this, f = d(g).closest("li"), i = a.panels.filter(":not(.ui-tabs-hide)"), l = a.element.find(a._sanitizeSelector(g.hash)); if (f.hasClass("ui-tabs-selected") && !c.collapsible || f.hasClass("ui-state-disabled") || f.hasClass("ui-state-processing") || a.panels.filter(":animated").length || a._trigger("select", null, a._ui(this, l[0])) === false) { this.blur(); return false } c.selected = a.anchors.index(this); a.abort(); if (c.collapsible) if (f.hasClass("ui-tabs-selected")) {
                c.selected =
-1; c.cookie && a._cookie(c.selected, c.cookie); a.element.queue("tabs", function () { s(g, i) }).dequeue("tabs"); this.blur(); return false
            } else if (!i.length) { c.cookie && a._cookie(c.selected, c.cookie); a.element.queue("tabs", function () { r(g, l) }); a.load(a.anchors.index(this)); this.blur(); return false } c.cookie && a._cookie(c.selected, c.cookie); if (l.length) { i.length && a.element.queue("tabs", function () { s(g, i) }); a.element.queue("tabs", function () { r(g, l) }); a.load(a.anchors.index(this)) } else throw "jQuery UI Tabs: Mismatching fragment identifier.";
            d.browser.msie && this.blur()
        }); this.anchors.bind("click.tabs", function () { return false })
    }, _getIndex: function (b) { if (typeof b == "string") b = this.anchors.index(this.anchors.filter("[href$=" + b + "]")); return b }, destroy: function () {
        var b = this.options; this.abort(); this.element.unbind(".tabs").removeClass("ui-tabs ui-widget ui-widget-content ui-corner-all ui-tabs-collapsible").removeData("tabs"); this.list.removeClass("ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all"); this.anchors.each(function () {
            var e =
d.data(this, "href.tabs"); if (e) this.href = e; var a = d(this).unbind(".tabs"); d.each(["href", "load", "cache"], function (c, h) { a.removeData(h + ".tabs") })
        }); this.lis.unbind(".tabs").add(this.panels).each(function () { d.data(this, "destroy.tabs") ? d(this).remove() : d(this).removeClass("ui-state-default ui-corner-top ui-tabs-selected ui-state-active ui-state-hover ui-state-focus ui-state-disabled ui-tabs-panel ui-widget-content ui-corner-bottom ui-tabs-hide") }); b.cookie && this._cookie(null, b.cookie); return this
    }, add: function (b,
e, a) {
        if (a === p) a = this.anchors.length; var c = this, h = this.options; e = d(h.tabTemplate.replace(/#\{href\}/g, b).replace(/#\{label\}/g, e)); b = !b.indexOf("#") ? b.replace("#", "") : this._tabId(d("a", e)[0]); e.addClass("ui-state-default ui-corner-top").data("destroy.tabs", true); var j = c.element.find("#" + b); j.length || (j = d(h.panelTemplate).attr("id", b).data("destroy.tabs", true)); j.addClass("ui-tabs-panel ui-widget-content ui-corner-bottom ui-tabs-hide"); if (a >= this.lis.length) { e.appendTo(this.list); j.appendTo(this.list[0].parentNode) } else {
            e.insertBefore(this.lis[a]);
            j.insertBefore(this.panels[a])
        } h.disabled = d.map(h.disabled, function (k) { return k >= a ? ++k : k }); this._tabify(); if (this.anchors.length == 1) { h.selected = 0; e.addClass("ui-tabs-selected ui-state-active"); j.removeClass("ui-tabs-hide"); this.element.queue("tabs", function () { c._trigger("show", null, c._ui(c.anchors[0], c.panels[0])) }); this.load(0) } this._trigger("add", null, this._ui(this.anchors[a], this.panels[a])); return this
    }, remove: function (b) {
        b = this._getIndex(b); var e = this.options, a = this.lis.eq(b).remove(), c = this.panels.eq(b).remove();
        if (a.hasClass("ui-tabs-selected") && this.anchors.length > 1) this.select(b + (b + 1 < this.anchors.length ? 1 : -1)); e.disabled = d.map(d.grep(e.disabled, function (h) { return h != b }), function (h) { return h >= b ? --h : h }); this._tabify(); this._trigger("remove", null, this._ui(a.find("a")[0], c[0])); return this
    }, enable: function (b) {
        b = this._getIndex(b); var e = this.options; if (d.inArray(b, e.disabled) != -1) {
            this.lis.eq(b).removeClass("ui-state-disabled"); e.disabled = d.grep(e.disabled, function (a) { return a != b }); this._trigger("enable", null,
this._ui(this.anchors[b], this.panels[b])); return this
        } 
    }, disable: function (b) { b = this._getIndex(b); var e = this.options; if (b != e.selected) { this.lis.eq(b).addClass("ui-state-disabled"); e.disabled.push(b); e.disabled.sort(); this._trigger("disable", null, this._ui(this.anchors[b], this.panels[b])) } return this }, select: function (b) { b = this._getIndex(b); if (b == -1) if (this.options.collapsible && this.options.selected != -1) b = this.options.selected; else return this; this.anchors.eq(b).trigger(this.options.event + ".tabs"); return this },
        load: function (b) {
            b = this._getIndex(b); var e = this, a = this.options, c = this.anchors.eq(b)[0], h = d.data(c, "load.tabs"); this.abort(); if (!h || this.element.queue("tabs").length !== 0 && d.data(c, "cache.tabs")) this.element.dequeue("tabs"); else {
                this.lis.eq(b).addClass("ui-state-processing"); if (a.spinner) { var j = d("span", c); j.data("label.tabs", j.html()).html(a.spinner) } this.xhr = d.ajax(d.extend({}, a.ajaxOptions, { url: h, success: function (k, n) {
                    e.element.find(e._sanitizeSelector(c.hash)).html(k); e._cleanup(); a.cache && d.data(c,
"cache.tabs", true); e._trigger("load", null, e._ui(e.anchors[b], e.panels[b])); try { a.ajaxOptions.success(k, n) } catch (m) { } 
                }, error: function (k, n) { e._cleanup(); e._trigger("load", null, e._ui(e.anchors[b], e.panels[b])); try { a.ajaxOptions.error(k, n, b, c) } catch (m) { } } 
                })); e.element.dequeue("tabs"); return this
            } 
        }, abort: function () { this.element.queue([]); this.panels.stop(false, true); this.element.queue("tabs", this.element.queue("tabs").splice(-2, 2)); if (this.xhr) { this.xhr.abort(); delete this.xhr } this._cleanup(); return this },
        url: function (b, e) { this.anchors.eq(b).removeData("cache.tabs").data("load.tabs", e); return this }, length: function () { return this.anchors.length } 
    }); d.extend(d.ui.tabs, { version: "1.8.7" }); d.extend(d.ui.tabs.prototype, { rotation: null, rotate: function (b, e) {
        var a = this, c = this.options, h = a._rotate || (a._rotate = function (j) { clearTimeout(a.rotation); a.rotation = setTimeout(function () { var k = c.selected; a.select(++k < a.anchors.length ? k : 0) }, b); j && j.stopPropagation() }); e = a._unrotate || (a._unrotate = !e ? function (j) {
            j.clientX &&
a.rotate(null)
        } : function () { t = c.selected; h() }); if (b) { this.element.bind("tabsshow", h); this.anchors.bind(c.event + ".tabs", e); h() } else { clearTimeout(a.rotation); this.element.unbind("tabsshow", h); this.anchors.unbind(c.event + ".tabs", e); delete this._rotate; delete this._unrotate } return this
    } 
    })
})(jQuery);
; /*
 * jQuery UI Datepicker 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Datepicker
 *
 * Depends:
 *	jquery.ui.core.js
 */
(function (d, G) {
    function K() {
        this.debug = false; this._curInst = null; this._keyEvent = false; this._disabledInputs = []; this._inDialog = this._datepickerShowing = false; this._mainDivId = "ui-datepicker-div"; this._inlineClass = "ui-datepicker-inline"; this._appendClass = "ui-datepicker-append"; this._triggerClass = "ui-datepicker-trigger"; this._dialogClass = "ui-datepicker-dialog"; this._disableClass = "ui-datepicker-disabled"; this._unselectableClass = "ui-datepicker-unselectable"; this._currentClass = "ui-datepicker-current-day"; this._dayOverClass =
"ui-datepicker-days-cell-over"; this.regional = []; this.regional[""] = { closeText: "Done", prevText: "Prev", nextText: "Next", currentText: "Today", monthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"], monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"], dayNames: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"], dayNamesShort: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"], dayNamesMin: ["Su",
"Mo", "Tu", "We", "Th", "Fr", "Sa"], weekHeader: "Wk", dateFormat: "mm/dd/yy", firstDay: 0, isRTL: false, showMonthAfterYear: false, yearSuffix: ""
}; this._defaults = { showOn: "focus", showAnim: "fadeIn", showOptions: {}, defaultDate: null, appendText: "", buttonText: "...", buttonImage: "", buttonImageOnly: false, hideIfNoPrevNext: false, navigationAsDateFormat: false, gotoCurrent: false, changeMonth: false, changeYear: false, yearRange: "c-10:c+10", showOtherMonths: false, selectOtherMonths: false, showWeek: false, calculateWeek: this.iso8601Week, shortYearCutoff: "+10",
    minDate: null, maxDate: null, duration: "fast", beforeShowDay: null, beforeShow: null, onSelect: null, onChangeMonthYear: null, onClose: null, numberOfMonths: 1, showCurrentAtPos: 0, stepMonths: 1, stepBigMonths: 12, altField: "", altFormat: "", constrainInput: true, showButtonPanel: false, autoSize: false
}; d.extend(this._defaults, this.regional[""]); this.dpDiv = d('<div id="' + this._mainDivId + '" class="ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all"></div>')
    } function E(a, b) {
        d.extend(a, b); for (var c in b) if (b[c] ==
null || b[c] == G) a[c] = b[c]; return a
    } d.extend(d.ui, { datepicker: { version: "1.8.7"} }); var y = (new Date).getTime(); d.extend(K.prototype, { markerClassName: "hasDatepicker", log: function () { this.debug && console.log.apply("", arguments) }, _widgetDatepicker: function () { return this.dpDiv }, setDefaults: function (a) { E(this._defaults, a || {}); return this }, _attachDatepicker: function (a, b) {
        var c = null; for (var e in this._defaults) { var f = a.getAttribute("date:" + e); if (f) { c = c || {}; try { c[e] = eval(f) } catch (h) { c[e] = f } } } e = a.nodeName.toLowerCase();
        f = e == "div" || e == "span"; if (!a.id) { this.uuid += 1; a.id = "dp" + this.uuid } var i = this._newInst(d(a), f); i.settings = d.extend({}, b || {}, c || {}); if (e == "input") this._connectDatepicker(a, i); else f && this._inlineDatepicker(a, i)
    }, _newInst: function (a, b) { return { id: a[0].id.replace(/([^A-Za-z0-9_-])/g, "\\\\$1"), input: a, selectedDay: 0, selectedMonth: 0, selectedYear: 0, drawMonth: 0, drawYear: 0, inline: b, dpDiv: !b ? this.dpDiv : d('<div class="' + this._inlineClass + ' ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all"></div>')} },
        _connectDatepicker: function (a, b) { var c = d(a); b.append = d([]); b.trigger = d([]); if (!c.hasClass(this.markerClassName)) { this._attachments(c, b); c.addClass(this.markerClassName).keydown(this._doKeyDown).keypress(this._doKeyPress).keyup(this._doKeyUp).bind("setData.datepicker", function (e, f, h) { b.settings[f] = h }).bind("getData.datepicker", function (e, f) { return this._get(b, f) }); this._autoSize(b); d.data(a, "datepicker", b) } }, _attachments: function (a, b) {
            var c = this._get(b, "appendText"), e = this._get(b, "isRTL"); b.append &&
b.append.remove(); if (c) { b.append = d('<span class="' + this._appendClass + '">' + c + "</span>"); a[e ? "before" : "after"](b.append) } a.unbind("focus", this._showDatepicker); b.trigger && b.trigger.remove(); c = this._get(b, "showOn"); if (c == "focus" || c == "both") a.focus(this._showDatepicker); if (c == "button" || c == "both") {
                c = this._get(b, "buttonText"); var f = this._get(b, "buttonImage"); b.trigger = d(this._get(b, "buttonImageOnly") ? d("<img/>").addClass(this._triggerClass).attr({ src: f, alt: c, title: c }) : d('<button type="button"></button>').addClass(this._triggerClass).html(f ==
"" ? c : d("<img/>").attr({ src: f, alt: c, title: c }))); a[e ? "before" : "after"](b.trigger); b.trigger.click(function () { d.datepicker._datepickerShowing && d.datepicker._lastInput == a[0] ? d.datepicker._hideDatepicker() : d.datepicker._showDatepicker(a[0]); return false })
            } 
        }, _autoSize: function (a) {
            if (this._get(a, "autoSize") && !a.inline) {
                var b = new Date(2009, 11, 20), c = this._get(a, "dateFormat"); if (c.match(/[DM]/)) {
                    var e = function (f) { for (var h = 0, i = 0, g = 0; g < f.length; g++) if (f[g].length > h) { h = f[g].length; i = g } return i }; b.setMonth(e(this._get(a,
c.match(/MM/) ? "monthNames" : "monthNamesShort"))); b.setDate(e(this._get(a, c.match(/DD/) ? "dayNames" : "dayNamesShort")) + 20 - b.getDay())
                } a.input.attr("size", this._formatDate(a, b).length)
            } 
        }, _inlineDatepicker: function (a, b) {
            var c = d(a); if (!c.hasClass(this.markerClassName)) {
                c.addClass(this.markerClassName).append(b.dpDiv).bind("setData.datepicker", function (e, f, h) { b.settings[f] = h }).bind("getData.datepicker", function (e, f) { return this._get(b, f) }); d.data(a, "datepicker", b); this._setDate(b, this._getDefaultDate(b),
true); this._updateDatepicker(b); this._updateAlternate(b); b.dpDiv.show()
            } 
        }, _dialogDatepicker: function (a, b, c, e, f) {
            a = this._dialogInst; if (!a) { this.uuid += 1; this._dialogInput = d('<input type="text" id="' + ("dp" + this.uuid) + '" style="position: absolute; top: -100px; width: 0px; z-index: -10;"/>'); this._dialogInput.keydown(this._doKeyDown); d("body").append(this._dialogInput); a = this._dialogInst = this._newInst(this._dialogInput, false); a.settings = {}; d.data(this._dialogInput[0], "datepicker", a) } E(a.settings, e || {});
            b = b && b.constructor == Date ? this._formatDate(a, b) : b; this._dialogInput.val(b); this._pos = f ? f.length ? f : [f.pageX, f.pageY] : null; if (!this._pos) this._pos = [document.documentElement.clientWidth / 2 - 100 + (document.documentElement.scrollLeft || document.body.scrollLeft), document.documentElement.clientHeight / 2 - 150 + (document.documentElement.scrollTop || document.body.scrollTop)]; this._dialogInput.css("left", this._pos[0] + 20 + "px").css("top", this._pos[1] + "px"); a.settings.onSelect = c; this._inDialog = true; this.dpDiv.addClass(this._dialogClass);
            this._showDatepicker(this._dialogInput[0]); d.blockUI && d.blockUI(this.dpDiv); d.data(this._dialogInput[0], "datepicker", a); return this
        }, _destroyDatepicker: function (a) {
            var b = d(a), c = d.data(a, "datepicker"); if (b.hasClass(this.markerClassName)) {
                var e = a.nodeName.toLowerCase(); d.removeData(a, "datepicker"); if (e == "input") {
                    c.append.remove(); c.trigger.remove(); b.removeClass(this.markerClassName).unbind("focus", this._showDatepicker).unbind("keydown", this._doKeyDown).unbind("keypress", this._doKeyPress).unbind("keyup",
this._doKeyUp)
                } else if (e == "div" || e == "span") b.removeClass(this.markerClassName).empty()
            } 
        }, _enableDatepicker: function (a) {
            var b = d(a), c = d.data(a, "datepicker"); if (b.hasClass(this.markerClassName)) {
                var e = a.nodeName.toLowerCase(); if (e == "input") { a.disabled = false; c.trigger.filter("button").each(function () { this.disabled = false }).end().filter("img").css({ opacity: "1.0", cursor: "" }) } else if (e == "div" || e == "span") b.children("." + this._inlineClass).children().removeClass("ui-state-disabled"); this._disabledInputs = d.map(this._disabledInputs,
function (f) { return f == a ? null : f })
            } 
        }, _disableDatepicker: function (a) {
            var b = d(a), c = d.data(a, "datepicker"); if (b.hasClass(this.markerClassName)) {
                var e = a.nodeName.toLowerCase(); if (e == "input") { a.disabled = true; c.trigger.filter("button").each(function () { this.disabled = true }).end().filter("img").css({ opacity: "0.5", cursor: "default" }) } else if (e == "div" || e == "span") b.children("." + this._inlineClass).children().addClass("ui-state-disabled"); this._disabledInputs = d.map(this._disabledInputs, function (f) {
                    return f == a ? null :
f
                }); this._disabledInputs[this._disabledInputs.length] = a
            } 
        }, _isDisabledDatepicker: function (a) { if (!a) return false; for (var b = 0; b < this._disabledInputs.length; b++) if (this._disabledInputs[b] == a) return true; return false }, _getInst: function (a) { try { return d.data(a, "datepicker") } catch (b) { throw "Missing instance data for this datepicker"; } }, _optionDatepicker: function (a, b, c) {
            var e = this._getInst(a); if (arguments.length == 2 && typeof b == "string") return b == "defaults" ? d.extend({}, d.datepicker._defaults) : e ? b == "all" ? d.extend({},
e.settings) : this._get(e, b) : null; var f = b || {}; if (typeof b == "string") { f = {}; f[b] = c } if (e) { this._curInst == e && this._hideDatepicker(); var h = this._getDateDatepicker(a, true); E(e.settings, f); this._attachments(d(a), e); this._autoSize(e); this._setDateDatepicker(a, h); this._updateDatepicker(e) } 
        }, _changeDatepicker: function (a, b, c) { this._optionDatepicker(a, b, c) }, _refreshDatepicker: function (a) { (a = this._getInst(a)) && this._updateDatepicker(a) }, _setDateDatepicker: function (a, b) {
            if (a = this._getInst(a)) {
                this._setDate(a, b);
                this._updateDatepicker(a); this._updateAlternate(a)
            } 
        }, _getDateDatepicker: function (a, b) { (a = this._getInst(a)) && !a.inline && this._setDateFromField(a, b); return a ? this._getDate(a) : null }, _doKeyDown: function (a) {
            var b = d.datepicker._getInst(a.target), c = true, e = b.dpDiv.is(".ui-datepicker-rtl"); b._keyEvent = true; if (d.datepicker._datepickerShowing) switch (a.keyCode) {
                case 9: d.datepicker._hideDatepicker(); c = false; break; case 13: c = d("td." + d.datepicker._dayOverClass + ":not(." + d.datepicker._currentClass + ")", b.dpDiv); c[0] ?
d.datepicker._selectDay(a.target, b.selectedMonth, b.selectedYear, c[0]) : d.datepicker._hideDatepicker(); return false; case 27: d.datepicker._hideDatepicker(); break; case 33: d.datepicker._adjustDate(a.target, a.ctrlKey ? -d.datepicker._get(b, "stepBigMonths") : -d.datepicker._get(b, "stepMonths"), "M"); break; case 34: d.datepicker._adjustDate(a.target, a.ctrlKey ? +d.datepicker._get(b, "stepBigMonths") : +d.datepicker._get(b, "stepMonths"), "M"); break; case 35: if (a.ctrlKey || a.metaKey) d.datepicker._clearDate(a.target); c = a.ctrlKey ||
a.metaKey; break; case 36: if (a.ctrlKey || a.metaKey) d.datepicker._gotoToday(a.target); c = a.ctrlKey || a.metaKey; break; case 37: if (a.ctrlKey || a.metaKey) d.datepicker._adjustDate(a.target, e ? +1 : -1, "D"); c = a.ctrlKey || a.metaKey; if (a.originalEvent.altKey) d.datepicker._adjustDate(a.target, a.ctrlKey ? -d.datepicker._get(b, "stepBigMonths") : -d.datepicker._get(b, "stepMonths"), "M"); break; case 38: if (a.ctrlKey || a.metaKey) d.datepicker._adjustDate(a.target, -7, "D"); c = a.ctrlKey || a.metaKey; break; case 39: if (a.ctrlKey || a.metaKey) d.datepicker._adjustDate(a.target,
e ? -1 : +1, "D"); c = a.ctrlKey || a.metaKey; if (a.originalEvent.altKey) d.datepicker._adjustDate(a.target, a.ctrlKey ? +d.datepicker._get(b, "stepBigMonths") : +d.datepicker._get(b, "stepMonths"), "M"); break; case 40: if (a.ctrlKey || a.metaKey) d.datepicker._adjustDate(a.target, +7, "D"); c = a.ctrlKey || a.metaKey; break; default: c = false
            } else if (a.keyCode == 36 && a.ctrlKey) d.datepicker._showDatepicker(this); else c = false; if (c) { a.preventDefault(); a.stopPropagation() } 
        }, _doKeyPress: function (a) {
            var b = d.datepicker._getInst(a.target); if (d.datepicker._get(b,
"constrainInput")) { b = d.datepicker._possibleChars(d.datepicker._get(b, "dateFormat")); var c = String.fromCharCode(a.charCode == G ? a.keyCode : a.charCode); return a.ctrlKey || a.metaKey || c < " " || !b || b.indexOf(c) > -1 } 
        }, _doKeyUp: function (a) { a = d.datepicker._getInst(a.target); if (a.input.val() != a.lastVal) try { if (d.datepicker.parseDate(d.datepicker._get(a, "dateFormat"), a.input ? a.input.val() : null, d.datepicker._getFormatConfig(a))) { d.datepicker._setDateFromField(a); d.datepicker._updateAlternate(a); d.datepicker._updateDatepicker(a) } } catch (b) { d.datepicker.log(b) } return true },
        _showDatepicker: function (a) {
            a = a.target || a; if (a.nodeName.toLowerCase() != "input") a = d("input", a.parentNode)[0]; if (!(d.datepicker._isDisabledDatepicker(a) || d.datepicker._lastInput == a)) {
                var b = d.datepicker._getInst(a); d.datepicker._curInst && d.datepicker._curInst != b && d.datepicker._curInst.dpDiv.stop(true, true); var c = d.datepicker._get(b, "beforeShow"); E(b.settings, c ? c.apply(a, [a, b]) : {}); b.lastVal = null; d.datepicker._lastInput = a; d.datepicker._setDateFromField(b); if (d.datepicker._inDialog) a.value = ""; if (!d.datepicker._pos) {
                    d.datepicker._pos =
d.datepicker._findPos(a); d.datepicker._pos[1] += a.offsetHeight
                } var e = false; d(a).parents().each(function () { e |= d(this).css("position") == "fixed"; return !e }); if (e && d.browser.opera) { d.datepicker._pos[0] -= document.documentElement.scrollLeft; d.datepicker._pos[1] -= document.documentElement.scrollTop } c = { left: d.datepicker._pos[0], top: d.datepicker._pos[1] }; d.datepicker._pos = null; b.dpDiv.empty(); b.dpDiv.css({ position: "absolute", display: "block", top: "-1000px" }); d.datepicker._updateDatepicker(b); c = d.datepicker._checkOffset(b,
c, e); b.dpDiv.css({ position: d.datepicker._inDialog && d.blockUI ? "static" : e ? "fixed" : "absolute", display: "none", left: c.left + "px", top: c.top + "px" }); if (!b.inline) {
                    c = d.datepicker._get(b, "showAnim"); var f = d.datepicker._get(b, "duration"), h = function () { d.datepicker._datepickerShowing = true; var i = b.dpDiv.find("iframe.ui-datepicker-cover"); if (i.length) { var g = d.datepicker._getBorders(b.dpDiv); i.css({ left: -g[0], top: -g[1], width: b.dpDiv.outerWidth(), height: b.dpDiv.outerHeight() }) } }; b.dpDiv.zIndex(d(a).zIndex() + 1); d.effects &&
d.effects[c] ? b.dpDiv.show(c, d.datepicker._get(b, "showOptions"), f, h) : b.dpDiv[c || "show"](c ? f : null, h); if (!c || !f) h(); b.input.is(":visible") && !b.input.is(":disabled") && b.input.focus(); d.datepicker._curInst = b
                } 
            } 
        }, _updateDatepicker: function (a) {
            var b = this, c = d.datepicker._getBorders(a.dpDiv); a.dpDiv.empty().append(this._generateHTML(a)); var e = a.dpDiv.find("iframe.ui-datepicker-cover"); e.length && e.css({ left: -c[0], top: -c[1], width: a.dpDiv.outerWidth(), height: a.dpDiv.outerHeight() }); a.dpDiv.find("button, .ui-datepicker-prev, .ui-datepicker-next, .ui-datepicker-calendar td a").bind("mouseout",
function () { d(this).removeClass("ui-state-hover"); this.className.indexOf("ui-datepicker-prev") != -1 && d(this).removeClass("ui-datepicker-prev-hover"); this.className.indexOf("ui-datepicker-next") != -1 && d(this).removeClass("ui-datepicker-next-hover") }).bind("mouseover", function () {
    if (!b._isDisabledDatepicker(a.inline ? a.dpDiv.parent()[0] : a.input[0])) {
        d(this).parents(".ui-datepicker-calendar").find("a").removeClass("ui-state-hover"); d(this).addClass("ui-state-hover"); this.className.indexOf("ui-datepicker-prev") !=
-1 && d(this).addClass("ui-datepicker-prev-hover"); this.className.indexOf("ui-datepicker-next") != -1 && d(this).addClass("ui-datepicker-next-hover")
    } 
}).end().find("." + this._dayOverClass + " a").trigger("mouseover").end(); c = this._getNumberOfMonths(a); e = c[1]; e > 1 ? a.dpDiv.addClass("ui-datepicker-multi-" + e).css("width", 17 * e + "em") : a.dpDiv.removeClass("ui-datepicker-multi-2 ui-datepicker-multi-3 ui-datepicker-multi-4").width(""); a.dpDiv[(c[0] != 1 || c[1] != 1 ? "add" : "remove") + "Class"]("ui-datepicker-multi"); a.dpDiv[(this._get(a,
"isRTL") ? "add" : "remove") + "Class"]("ui-datepicker-rtl"); a == d.datepicker._curInst && d.datepicker._datepickerShowing && a.input && a.input.is(":visible") && !a.input.is(":disabled") && a.input.focus(); if (a.yearshtml) { var f = a.yearshtml; setTimeout(function () { f === a.yearshtml && a.dpDiv.find("select.ui-datepicker-year:first").replaceWith(a.yearshtml); f = a.yearshtml = null }, 0) } 
        }, _getBorders: function (a) { var b = function (c) { return { thin: 1, medium: 2, thick: 3}[c] || c }; return [parseFloat(b(a.css("border-left-width"))), parseFloat(b(a.css("border-top-width")))] },
        _checkOffset: function (a, b, c) {
            var e = a.dpDiv.outerWidth(), f = a.dpDiv.outerHeight(), h = a.input ? a.input.outerWidth() : 0, i = a.input ? a.input.outerHeight() : 0, g = document.documentElement.clientWidth + d(document).scrollLeft(), j = document.documentElement.clientHeight + d(document).scrollTop(); b.left -= this._get(a, "isRTL") ? e - h : 0; b.left -= c && b.left == a.input.offset().left ? d(document).scrollLeft() : 0; b.top -= c && b.top == a.input.offset().top + i ? d(document).scrollTop() : 0; b.left -= Math.min(b.left, b.left + e > g && g > e ? Math.abs(b.left + e -
g) : 0); b.top -= Math.min(b.top, b.top + f > j && j > f ? Math.abs(f + i) : 0); return b
        }, _findPos: function (a) { for (var b = this._get(this._getInst(a), "isRTL"); a && (a.type == "hidden" || a.nodeType != 1); ) a = a[b ? "previousSibling" : "nextSibling"]; a = d(a).offset(); return [a.left, a.top] }, _hideDatepicker: function (a) {
            var b = this._curInst; if (!(!b || a && b != d.data(a, "datepicker"))) if (this._datepickerShowing) {
                a = this._get(b, "showAnim"); var c = this._get(b, "duration"), e = function () { d.datepicker._tidyDialog(b); this._curInst = null }; d.effects && d.effects[a] ?
b.dpDiv.hide(a, d.datepicker._get(b, "showOptions"), c, e) : b.dpDiv[a == "slideDown" ? "slideUp" : a == "fadeIn" ? "fadeOut" : "hide"](a ? c : null, e); a || e(); if (a = this._get(b, "onClose")) a.apply(b.input ? b.input[0] : null, [b.input ? b.input.val() : "", b]); this._datepickerShowing = false; this._lastInput = null; if (this._inDialog) { this._dialogInput.css({ position: "absolute", left: "0", top: "-100px" }); if (d.blockUI) { d.unblockUI(); d("body").append(this.dpDiv) } } this._inDialog = false
            } 
        }, _tidyDialog: function (a) { a.dpDiv.removeClass(this._dialogClass).unbind(".ui-datepicker-calendar") },
        _checkExternalClick: function (a) { if (d.datepicker._curInst) { a = d(a.target); a[0].id != d.datepicker._mainDivId && a.parents("#" + d.datepicker._mainDivId).length == 0 && !a.hasClass(d.datepicker.markerClassName) && !a.hasClass(d.datepicker._triggerClass) && d.datepicker._datepickerShowing && !(d.datepicker._inDialog && d.blockUI) && d.datepicker._hideDatepicker() } }, _adjustDate: function (a, b, c) {
            a = d(a); var e = this._getInst(a[0]); if (!this._isDisabledDatepicker(a[0])) {
                this._adjustInstDate(e, b + (c == "M" ? this._get(e, "showCurrentAtPos") :
0), c); this._updateDatepicker(e)
            } 
        }, _gotoToday: function (a) { a = d(a); var b = this._getInst(a[0]); if (this._get(b, "gotoCurrent") && b.currentDay) { b.selectedDay = b.currentDay; b.drawMonth = b.selectedMonth = b.currentMonth; b.drawYear = b.selectedYear = b.currentYear } else { var c = new Date; b.selectedDay = c.getDate(); b.drawMonth = b.selectedMonth = c.getMonth(); b.drawYear = b.selectedYear = c.getFullYear() } this._notifyChange(b); this._adjustDate(a) }, _selectMonthYear: function (a, b, c) {
            a = d(a); var e = this._getInst(a[0]); e._selectingMonthYear =
false; e["selected" + (c == "M" ? "Month" : "Year")] = e["draw" + (c == "M" ? "Month" : "Year")] = parseInt(b.options[b.selectedIndex].value, 10); this._notifyChange(e); this._adjustDate(a)
        }, _clickMonthYear: function (a) { var b = this._getInst(d(a)[0]); b.input && b._selectingMonthYear && setTimeout(function () { b.input.focus() }, 0); b._selectingMonthYear = !b._selectingMonthYear }, _selectDay: function (a, b, c, e) {
            var f = d(a); if (!(d(e).hasClass(this._unselectableClass) || this._isDisabledDatepicker(f[0]))) {
                f = this._getInst(f[0]); f.selectedDay = f.currentDay =
d("a", e).html(); f.selectedMonth = f.currentMonth = b; f.selectedYear = f.currentYear = c; this._selectDate(a, this._formatDate(f, f.currentDay, f.currentMonth, f.currentYear))
            } 
        }, _clearDate: function (a) { a = d(a); this._getInst(a[0]); this._selectDate(a, "") }, _selectDate: function (a, b) {
            a = this._getInst(d(a)[0]); b = b != null ? b : this._formatDate(a); a.input && a.input.val(b); this._updateAlternate(a); var c = this._get(a, "onSelect"); if (c) c.apply(a.input ? a.input[0] : null, [b, a]); else a.input && a.input.trigger("change"); if (a.inline) this._updateDatepicker(a);
            else { this._hideDatepicker(); this._lastInput = a.input[0]; typeof a.input[0] != "object" && a.input.focus(); this._lastInput = null } 
        }, _updateAlternate: function (a) { var b = this._get(a, "altField"); if (b) { var c = this._get(a, "altFormat") || this._get(a, "dateFormat"), e = this._getDate(a), f = this.formatDate(c, e, this._getFormatConfig(a)); d(b).each(function () { d(this).val(f) }) } }, noWeekends: function (a) { a = a.getDay(); return [a > 0 && a < 6, ""] }, iso8601Week: function (a) {
            a = new Date(a.getTime()); a.setDate(a.getDate() + 4 - (a.getDay() || 7)); var b =
a.getTime(); a.setMonth(0); a.setDate(1); return Math.floor(Math.round((b - a) / 864E5) / 7) + 1
        }, parseDate: function (a, b, c) {
            if (a == null || b == null) throw "Invalid arguments"; b = typeof b == "object" ? b.toString() : b + ""; if (b == "") return null; for (var e = (c ? c.shortYearCutoff : null) || this._defaults.shortYearCutoff, f = (c ? c.dayNamesShort : null) || this._defaults.dayNamesShort, h = (c ? c.dayNames : null) || this._defaults.dayNames, i = (c ? c.monthNamesShort : null) || this._defaults.monthNamesShort, g = (c ? c.monthNames : null) || this._defaults.monthNames,
j = c = -1, l = -1, u = -1, k = false, o = function (p) { (p = z + 1 < a.length && a.charAt(z + 1) == p) && z++; return p }, m = function (p) { var v = o(p); p = new RegExp("^\\d{1," + (p == "@" ? 14 : p == "!" ? 20 : p == "y" && v ? 4 : p == "o" ? 3 : 2) + "}"); p = b.substring(s).match(p); if (!p) throw "Missing number at position " + s; s += p[0].length; return parseInt(p[0], 10) }, n = function (p, v, H) { p = o(p) ? H : v; for (v = 0; v < p.length; v++) if (b.substr(s, p[v].length).toLowerCase() == p[v].toLowerCase()) { s += p[v].length; return v + 1 } throw "Unknown name at position " + s; }, r = function () {
    if (b.charAt(s) !=
a.charAt(z)) throw "Unexpected literal at position " + s; s++
}, s = 0, z = 0; z < a.length; z++) if (k) if (a.charAt(z) == "'" && !o("'")) k = false; else r(); else switch (a.charAt(z)) {
                case "d": l = m("d"); break; case "D": n("D", f, h); break; case "o": u = m("o"); break; case "m": j = m("m"); break; case "M": j = n("M", i, g); break; case "y": c = m("y"); break; case "@": var w = new Date(m("@")); c = w.getFullYear(); j = w.getMonth() + 1; l = w.getDate(); break; case "!": w = new Date((m("!") - this._ticksTo1970) / 1E4); c = w.getFullYear(); j = w.getMonth() + 1; l = w.getDate(); break;
                case "'": if (o("'")) r(); else k = true; break; default: r()
            } if (c == -1) c = (new Date).getFullYear(); else if (c < 100) c += (new Date).getFullYear() - (new Date).getFullYear() % 100 + (c <= e ? 0 : -100); if (u > -1) { j = 1; l = u; do { e = this._getDaysInMonth(c, j - 1); if (l <= e) break; j++; l -= e } while (1) } w = this._daylightSavingAdjust(new Date(c, j - 1, l)); if (w.getFullYear() != c || w.getMonth() + 1 != j || w.getDate() != l) throw "Invalid date"; return w
        }, ATOM: "yy-mm-dd", COOKIE: "D, dd M yy", ISO_8601: "yy-mm-dd", RFC_822: "D, d M y", RFC_850: "DD, dd-M-y", RFC_1036: "D, d M y",
        RFC_1123: "D, d M yy", RFC_2822: "D, d M yy", RSS: "D, d M y", TICKS: "!", TIMESTAMP: "@", W3C: "yy-mm-dd", _ticksTo1970: (718685 + Math.floor(492.5) - Math.floor(19.7) + Math.floor(4.925)) * 24 * 60 * 60 * 1E7, formatDate: function (a, b, c) {
            if (!b) return ""; var e = (c ? c.dayNamesShort : null) || this._defaults.dayNamesShort, f = (c ? c.dayNames : null) || this._defaults.dayNames, h = (c ? c.monthNamesShort : null) || this._defaults.monthNamesShort; c = (c ? c.monthNames : null) || this._defaults.monthNames; var i = function (o) {
                (o = k + 1 < a.length && a.charAt(k + 1) == o) && k++;
                return o
            }, g = function (o, m, n) { m = "" + m; if (i(o)) for (; m.length < n; ) m = "0" + m; return m }, j = function (o, m, n, r) { return i(o) ? r[m] : n[m] }, l = "", u = false; if (b) for (var k = 0; k < a.length; k++) if (u) if (a.charAt(k) == "'" && !i("'")) u = false; else l += a.charAt(k); else switch (a.charAt(k)) {
                case "d": l += g("d", b.getDate(), 2); break; case "D": l += j("D", b.getDay(), e, f); break; case "o": l += g("o", (b.getTime() - (new Date(b.getFullYear(), 0, 0)).getTime()) / 864E5, 3); break; case "m": l += g("m", b.getMonth() + 1, 2); break; case "M": l += j("M", b.getMonth(), h, c); break;
                case "y": l += i("y") ? b.getFullYear() : (b.getYear() % 100 < 10 ? "0" : "") + b.getYear() % 100; break; case "@": l += b.getTime(); break; case "!": l += b.getTime() * 1E4 + this._ticksTo1970; break; case "'": if (i("'")) l += "'"; else u = true; break; default: l += a.charAt(k)
            } return l
        }, _possibleChars: function (a) {
            for (var b = "", c = false, e = function (h) { (h = f + 1 < a.length && a.charAt(f + 1) == h) && f++; return h }, f = 0; f < a.length; f++) if (c) if (a.charAt(f) == "'" && !e("'")) c = false; else b += a.charAt(f); else switch (a.charAt(f)) {
                case "d": case "m": case "y": case "@": b +=
"0123456789"; break; case "D": case "M": return null; case "'": if (e("'")) b += "'"; else c = true; break; default: b += a.charAt(f)
            } return b
        }, _get: function (a, b) { return a.settings[b] !== G ? a.settings[b] : this._defaults[b] }, _setDateFromField: function (a, b) {
            if (a.input.val() != a.lastVal) {
                var c = this._get(a, "dateFormat"), e = a.lastVal = a.input ? a.input.val() : null, f, h; f = h = this._getDefaultDate(a); var i = this._getFormatConfig(a); try { f = this.parseDate(c, e, i) || h } catch (g) { this.log(g); e = b ? "" : e } a.selectedDay = f.getDate(); a.drawMonth = a.selectedMonth =
f.getMonth(); a.drawYear = a.selectedYear = f.getFullYear(); a.currentDay = e ? f.getDate() : 0; a.currentMonth = e ? f.getMonth() : 0; a.currentYear = e ? f.getFullYear() : 0; this._adjustInstDate(a)
            } 
        }, _getDefaultDate: function (a) { return this._restrictMinMax(a, this._determineDate(a, this._get(a, "defaultDate"), new Date)) }, _determineDate: function (a, b, c) {
            var e = function (h) { var i = new Date; i.setDate(i.getDate() + h); return i }, f = function (h) {
                try { return d.datepicker.parseDate(d.datepicker._get(a, "dateFormat"), h, d.datepicker._getFormatConfig(a)) } catch (i) { } var g =
(h.toLowerCase().match(/^c/) ? d.datepicker._getDate(a) : null) || new Date, j = g.getFullYear(), l = g.getMonth(); g = g.getDate(); for (var u = /([+-]?[0-9]+)\s*(d|D|w|W|m|M|y|Y)?/g, k = u.exec(h); k; ) { switch (k[2] || "d") { case "d": case "D": g += parseInt(k[1], 10); break; case "w": case "W": g += parseInt(k[1], 10) * 7; break; case "m": case "M": l += parseInt(k[1], 10); g = Math.min(g, d.datepicker._getDaysInMonth(j, l)); break; case "y": case "Y": j += parseInt(k[1], 10); g = Math.min(g, d.datepicker._getDaysInMonth(j, l)); break } k = u.exec(h) } return new Date(j,
l, g)
            }; if (b = (b = b == null || b === "" ? c : typeof b == "string" ? f(b) : typeof b == "number" ? isNaN(b) ? c : e(b) : new Date(b.getTime())) && b.toString() == "Invalid Date" ? c : b) { b.setHours(0); b.setMinutes(0); b.setSeconds(0); b.setMilliseconds(0) } return this._daylightSavingAdjust(b)
        }, _daylightSavingAdjust: function (a) { if (!a) return null; a.setHours(a.getHours() > 12 ? a.getHours() + 2 : 0); return a }, _setDate: function (a, b, c) {
            var e = !b, f = a.selectedMonth, h = a.selectedYear; b = this._restrictMinMax(a, this._determineDate(a, b, new Date)); a.selectedDay =
a.currentDay = b.getDate(); a.drawMonth = a.selectedMonth = a.currentMonth = b.getMonth(); a.drawYear = a.selectedYear = a.currentYear = b.getFullYear(); if ((f != a.selectedMonth || h != a.selectedYear) && !c) this._notifyChange(a); this._adjustInstDate(a); if (a.input) a.input.val(e ? "" : this._formatDate(a))
        }, _getDate: function (a) { return !a.currentYear || a.input && a.input.val() == "" ? null : this._daylightSavingAdjust(new Date(a.currentYear, a.currentMonth, a.currentDay)) }, _generateHTML: function (a) {
            var b = new Date; b = this._daylightSavingAdjust(new Date(b.getFullYear(),
b.getMonth(), b.getDate())); var c = this._get(a, "isRTL"), e = this._get(a, "showButtonPanel"), f = this._get(a, "hideIfNoPrevNext"), h = this._get(a, "navigationAsDateFormat"), i = this._getNumberOfMonths(a), g = this._get(a, "showCurrentAtPos"), j = this._get(a, "stepMonths"), l = i[0] != 1 || i[1] != 1, u = this._daylightSavingAdjust(!a.currentDay ? new Date(9999, 9, 9) : new Date(a.currentYear, a.currentMonth, a.currentDay)), k = this._getMinMaxDate(a, "min"), o = this._getMinMaxDate(a, "max"); g = a.drawMonth - g; var m = a.drawYear; if (g < 0) { g += 12; m-- } if (o) {
                var n =
this._daylightSavingAdjust(new Date(o.getFullYear(), o.getMonth() - i[0] * i[1] + 1, o.getDate())); for (n = k && n < k ? k : n; this._daylightSavingAdjust(new Date(m, g, 1)) > n; ) { g--; if (g < 0) { g = 11; m-- } } 
            } a.drawMonth = g; a.drawYear = m; n = this._get(a, "prevText"); n = !h ? n : this.formatDate(n, this._daylightSavingAdjust(new Date(m, g - j, 1)), this._getFormatConfig(a)); n = this._canAdjustMonth(a, -1, m, g) ? '<a class="ui-datepicker-prev ui-corner-all" onclick="DP_jQuery_' + y + ".datepicker._adjustDate('#" + a.id + "', -" + j + ", 'M');\" title=\"" + n + '"><span class="ui-icon ui-icon-circle-triangle-' +
(c ? "e" : "w") + '">' + n + "</span></a>" : f ? "" : '<a class="ui-datepicker-prev ui-corner-all ui-state-disabled" title="' + n + '"><span class="ui-icon ui-icon-circle-triangle-' + (c ? "e" : "w") + '">' + n + "</span></a>"; var r = this._get(a, "nextText"); r = !h ? r : this.formatDate(r, this._daylightSavingAdjust(new Date(m, g + j, 1)), this._getFormatConfig(a)); f = this._canAdjustMonth(a, +1, m, g) ? '<a class="ui-datepicker-next ui-corner-all" onclick="DP_jQuery_' + y + ".datepicker._adjustDate('#" + a.id + "', +" + j + ", 'M');\" title=\"" + r + '"><span class="ui-icon ui-icon-circle-triangle-' +
(c ? "w" : "e") + '">' + r + "</span></a>" : f ? "" : '<a class="ui-datepicker-next ui-corner-all ui-state-disabled" title="' + r + '"><span class="ui-icon ui-icon-circle-triangle-' + (c ? "w" : "e") + '">' + r + "</span></a>"; j = this._get(a, "currentText"); r = this._get(a, "gotoCurrent") && a.currentDay ? u : b; j = !h ? j : this.formatDate(j, r, this._getFormatConfig(a)); h = !a.inline ? '<button type="button" class="ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all" onclick="DP_jQuery_' + y + '.datepicker._hideDatepicker();">' + this._get(a,
"closeText") + "</button>" : ""; e = e ? '<div class="ui-datepicker-buttonpane ui-widget-content">' + (c ? h : "") + (this._isInRange(a, r) ? '<button type="button" class="ui-datepicker-current ui-state-default ui-priority-secondary ui-corner-all" onclick="DP_jQuery_' + y + ".datepicker._gotoToday('#" + a.id + "');\">" + j + "</button>" : "") + (c ? "" : h) + "</div>" : ""; h = parseInt(this._get(a, "firstDay"), 10); h = isNaN(h) ? 0 : h; j = this._get(a, "showWeek"); r = this._get(a, "dayNames"); this._get(a, "dayNamesShort"); var s = this._get(a, "dayNamesMin"), z =
this._get(a, "monthNames"), w = this._get(a, "monthNamesShort"), p = this._get(a, "beforeShowDay"), v = this._get(a, "showOtherMonths"), H = this._get(a, "selectOtherMonths"); this._get(a, "calculateWeek"); for (var L = this._getDefaultDate(a), I = "", C = 0; C < i[0]; C++) {
                for (var M = "", D = 0; D < i[1]; D++) {
                    var N = this._daylightSavingAdjust(new Date(m, g, a.selectedDay)), t = " ui-corner-all", x = ""; if (l) {
                        x += '<div class="ui-datepicker-group'; if (i[1] > 1) switch (D) {
                            case 0: x += " ui-datepicker-group-first"; t = " ui-corner-" + (c ? "right" : "left"); break; case i[1] -
1: x += " ui-datepicker-group-last"; t = " ui-corner-" + (c ? "left" : "right"); break; default: x += " ui-datepicker-group-middle"; t = ""; break
                        } x += '">'
                    } x += '<div class="ui-datepicker-header ui-widget-header ui-helper-clearfix' + t + '">' + (/all|left/.test(t) && C == 0 ? c ? f : n : "") + (/all|right/.test(t) && C == 0 ? c ? n : f : "") + this._generateMonthYearHeader(a, g, m, k, o, C > 0 || D > 0, z, w) + '</div><table class="ui-datepicker-calendar"><thead><tr>'; var A = j ? '<th class="ui-datepicker-week-col">' + this._get(a, "weekHeader") + "</th>" : ""; for (t = 0; t < 7; t++) {
                        var q =
(t + h) % 7; A += "<th" + ((t + h + 6) % 7 >= 5 ? ' class="ui-datepicker-week-end"' : "") + '><span title="' + r[q] + '">' + s[q] + "</span></th>"
                    } x += A + "</tr></thead><tbody>"; A = this._getDaysInMonth(m, g); if (m == a.selectedYear && g == a.selectedMonth) a.selectedDay = Math.min(a.selectedDay, A); t = (this._getFirstDayOfMonth(m, g) - h + 7) % 7; A = l ? 6 : Math.ceil((t + A) / 7); q = this._daylightSavingAdjust(new Date(m, g, 1 - t)); for (var O = 0; O < A; O++) {
                        x += "<tr>"; var P = !j ? "" : '<td class="ui-datepicker-week-col">' + this._get(a, "calculateWeek")(q) + "</td>"; for (t = 0; t < 7; t++) {
                            var F =
p ? p.apply(a.input ? a.input[0] : null, [q]) : [true, ""], B = q.getMonth() != g, J = B && !H || !F[0] || k && q < k || o && q > o; P += '<td class="' + ((t + h + 6) % 7 >= 5 ? " ui-datepicker-week-end" : "") + (B ? " ui-datepicker-other-month" : "") + (q.getTime() == N.getTime() && g == a.selectedMonth && a._keyEvent || L.getTime() == q.getTime() && L.getTime() == N.getTime() ? " " + this._dayOverClass : "") + (J ? " " + this._unselectableClass + " ui-state-disabled" : "") + (B && !v ? "" : " " + F[1] + (q.getTime() == u.getTime() ? " " + this._currentClass : "") + (q.getTime() == b.getTime() ? " ui-datepicker-today" :
"")) + '"' + ((!B || v) && F[2] ? ' title="' + F[2] + '"' : "") + (J ? "" : ' onclick="DP_jQuery_' + y + ".datepicker._selectDay('#" + a.id + "'," + q.getMonth() + "," + q.getFullYear() + ', this);return false;"') + ">" + (B && !v ? "&#xa0;" : J ? '<span class="ui-state-default">' + q.getDate() + "</span>" : '<a class="ui-state-default' + (q.getTime() == b.getTime() ? " ui-state-highlight" : "") + (q.getTime() == u.getTime() ? " ui-state-active" : "") + (B ? " ui-priority-secondary" : "") + '" href="#">' + q.getDate() + "</a>") + "</td>"; q.setDate(q.getDate() + 1); q = this._daylightSavingAdjust(q)
                        } x +=
P + "</tr>"
                    } g++; if (g > 11) { g = 0; m++ } x += "</tbody></table>" + (l ? "</div>" + (i[0] > 0 && D == i[1] - 1 ? '<div class="ui-datepicker-row-break"></div>' : "") : ""); M += x
                } I += M
            } I += e + (d.browser.msie && parseInt(d.browser.version, 10) < 7 && !a.inline ? '<iframe src="javascript:false;" class="ui-datepicker-cover" frameborder="0"></iframe>' : ""); a._keyEvent = false; return I
        }, _generateMonthYearHeader: function (a, b, c, e, f, h, i, g) {
            var j = this._get(a, "changeMonth"), l = this._get(a, "changeYear"), u = this._get(a, "showMonthAfterYear"), k = '<div class="ui-datepicker-title">',
o = ""; if (h || !j) o += '<span class="ui-datepicker-month">' + i[b] + "</span>"; else { i = e && e.getFullYear() == c; var m = f && f.getFullYear() == c; o += '<select class="ui-datepicker-month" onchange="DP_jQuery_' + y + ".datepicker._selectMonthYear('#" + a.id + "', this, 'M');\" onclick=\"DP_jQuery_" + y + ".datepicker._clickMonthYear('#" + a.id + "');\">"; for (var n = 0; n < 12; n++) if ((!i || n >= e.getMonth()) && (!m || n <= f.getMonth())) o += '<option value="' + n + '"' + (n == b ? ' selected="selected"' : "") + ">" + g[n] + "</option>"; o += "</select>" } u || (k += o + (h || !(j &&
l) ? "&#xa0;" : "")); a.yearshtml = ""; if (h || !l) k += '<span class="ui-datepicker-year">' + c + "</span>"; else {
                g = this._get(a, "yearRange").split(":"); var r = (new Date).getFullYear(); i = function (s) { s = s.match(/c[+-].*/) ? c + parseInt(s.substring(1), 10) : s.match(/[+-].*/) ? r + parseInt(s, 10) : parseInt(s, 10); return isNaN(s) ? r : s }; b = i(g[0]); g = Math.max(b, i(g[1] || "")); b = e ? Math.max(b, e.getFullYear()) : b; g = f ? Math.min(g, f.getFullYear()) : g; for (a.yearshtml += '<select class="ui-datepicker-year" onchange="DP_jQuery_' + y + ".datepicker._selectMonthYear('#" +
a.id + "', this, 'Y');\" onclick=\"DP_jQuery_" + y + ".datepicker._clickMonthYear('#" + a.id + "');\">"; b <= g; b++) a.yearshtml += '<option value="' + b + '"' + (b == c ? ' selected="selected"' : "") + ">" + b + "</option>"; a.yearshtml += "</select>"; if (d.browser.mozilla) k += '<select class="ui-datepicker-year"><option value="' + c + '" selected="selected">' + c + "</option></select>"; else { k += a.yearshtml; a.yearshtml = null } 
            } k += this._get(a, "yearSuffix"); if (u) k += (h || !(j && l) ? "&#xa0;" : "") + o; k += "</div>"; return k
        }, _adjustInstDate: function (a, b, c) {
            var e =
a.drawYear + (c == "Y" ? b : 0), f = a.drawMonth + (c == "M" ? b : 0); b = Math.min(a.selectedDay, this._getDaysInMonth(e, f)) + (c == "D" ? b : 0); e = this._restrictMinMax(a, this._daylightSavingAdjust(new Date(e, f, b))); a.selectedDay = e.getDate(); a.drawMonth = a.selectedMonth = e.getMonth(); a.drawYear = a.selectedYear = e.getFullYear(); if (c == "M" || c == "Y") this._notifyChange(a)
        }, _restrictMinMax: function (a, b) { var c = this._getMinMaxDate(a, "min"); a = this._getMinMaxDate(a, "max"); b = c && b < c ? c : b; return b = a && b > a ? a : b }, _notifyChange: function (a) {
            var b = this._get(a,
"onChangeMonthYear"); if (b) b.apply(a.input ? a.input[0] : null, [a.selectedYear, a.selectedMonth + 1, a])
        }, _getNumberOfMonths: function (a) { a = this._get(a, "numberOfMonths"); return a == null ? [1, 1] : typeof a == "number" ? [1, a] : a }, _getMinMaxDate: function (a, b) { return this._determineDate(a, this._get(a, b + "Date"), null) }, _getDaysInMonth: function (a, b) { return 32 - (new Date(a, b, 32)).getDate() }, _getFirstDayOfMonth: function (a, b) { return (new Date(a, b, 1)).getDay() }, _canAdjustMonth: function (a, b, c, e) {
            var f = this._getNumberOfMonths(a);
            c = this._daylightSavingAdjust(new Date(c, e + (b < 0 ? b : f[0] * f[1]), 1)); b < 0 && c.setDate(this._getDaysInMonth(c.getFullYear(), c.getMonth())); return this._isInRange(a, c)
        }, _isInRange: function (a, b) { var c = this._getMinMaxDate(a, "min"); a = this._getMinMaxDate(a, "max"); return (!c || b.getTime() >= c.getTime()) && (!a || b.getTime() <= a.getTime()) }, _getFormatConfig: function (a) {
            var b = this._get(a, "shortYearCutoff"); b = typeof b != "string" ? b : (new Date).getFullYear() % 100 + parseInt(b, 10); return { shortYearCutoff: b, dayNamesShort: this._get(a,
"dayNamesShort"), dayNames: this._get(a, "dayNames"), monthNamesShort: this._get(a, "monthNamesShort"), monthNames: this._get(a, "monthNames")
            }
        }, _formatDate: function (a, b, c, e) { if (!b) { a.currentDay = a.selectedDay; a.currentMonth = a.selectedMonth; a.currentYear = a.selectedYear } b = b ? typeof b == "object" ? b : this._daylightSavingAdjust(new Date(e, c, b)) : this._daylightSavingAdjust(new Date(a.currentYear, a.currentMonth, a.currentDay)); return this.formatDate(this._get(a, "dateFormat"), b, this._getFormatConfig(a)) } 
    }); d.fn.datepicker =
function (a) {
    if (!d.datepicker.initialized) { d(document).mousedown(d.datepicker._checkExternalClick).find("body").append(d.datepicker.dpDiv); d.datepicker.initialized = true } var b = Array.prototype.slice.call(arguments, 1); if (typeof a == "string" && (a == "isDisabled" || a == "getDate" || a == "widget")) return d.datepicker["_" + a + "Datepicker"].apply(d.datepicker, [this[0]].concat(b)); if (a == "option" && arguments.length == 2 && typeof arguments[1] == "string") return d.datepicker["_" + a + "Datepicker"].apply(d.datepicker, [this[0]].concat(b));
    return this.each(function () { typeof a == "string" ? d.datepicker["_" + a + "Datepicker"].apply(d.datepicker, [this].concat(b)) : d.datepicker._attachDatepicker(this, a) })
}; d.datepicker = new K; d.datepicker.initialized = false; d.datepicker.uuid = (new Date).getTime(); d.datepicker.version = "1.8.7"; window["DP_jQuery_" + y] = d
})(jQuery);
; /*
 * jQuery UI Progressbar 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Progressbar
 *
 * Depends:
 *   jquery.ui.core.js
 *   jquery.ui.widget.js
 */
(function (b, d) {
    b.widget("ui.progressbar", { options: { value: 0, max: 100 }, min: 0, _create: function () { this.element.addClass("ui-progressbar ui-widget ui-widget-content ui-corner-all").attr({ role: "progressbar", "aria-valuemin": this.min, "aria-valuemax": this.options.max, "aria-valuenow": this._value() }); this.valueDiv = b("<div class='ui-progressbar-value ui-widget-header ui-corner-left'></div>").appendTo(this.element); this.oldValue = this._value(); this._refreshValue() }, destroy: function () {
        this.element.removeClass("ui-progressbar ui-widget ui-widget-content ui-corner-all").removeAttr("role").removeAttr("aria-valuemin").removeAttr("aria-valuemax").removeAttr("aria-valuenow");
        this.valueDiv.remove(); b.Widget.prototype.destroy.apply(this, arguments)
    }, value: function (a) { if (a === d) return this._value(); this._setOption("value", a); return this }, _setOption: function (a, c) { if (a === "value") { this.options.value = c; this._refreshValue(); this._value() === this.options.max && this._trigger("complete") } b.Widget.prototype._setOption.apply(this, arguments) }, _value: function () { var a = this.options.value; if (typeof a !== "number") a = 0; return Math.min(this.options.max, Math.max(this.min, a)) }, _percentage: function () {
        return 100 *
this._value() / this.options.max
    }, _refreshValue: function () { var a = this.value(), c = this._percentage(); if (this.oldValue !== a) { this.oldValue = a; this._trigger("change") } this.valueDiv.toggleClass("ui-corner-right", a === this.options.max).width(c.toFixed(0) + "%"); this.element.attr("aria-valuenow", a) } 
    }); b.extend(b.ui.progressbar, { version: "1.8.7" })
})(jQuery);
; /*
 * jQuery UI Effects 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/
 */
jQuery.effects || function (f, j) {
    function n(c) {
        var a; if (c && c.constructor == Array && c.length == 3) return c; if (a = /rgb\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*\)/.exec(c)) return [parseInt(a[1], 10), parseInt(a[2], 10), parseInt(a[3], 10)]; if (a = /rgb\(\s*([0-9]+(?:\.[0-9]+)?)\%\s*,\s*([0-9]+(?:\.[0-9]+)?)\%\s*,\s*([0-9]+(?:\.[0-9]+)?)\%\s*\)/.exec(c)) return [parseFloat(a[1]) * 2.55, parseFloat(a[2]) * 2.55, parseFloat(a[3]) * 2.55]; if (a = /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/.exec(c)) return [parseInt(a[1],
16), parseInt(a[2], 16), parseInt(a[3], 16)]; if (a = /#([a-fA-F0-9])([a-fA-F0-9])([a-fA-F0-9])/.exec(c)) return [parseInt(a[1] + a[1], 16), parseInt(a[2] + a[2], 16), parseInt(a[3] + a[3], 16)]; if (/rgba\(0, 0, 0, 0\)/.exec(c)) return o.transparent; return o[f.trim(c).toLowerCase()]
    } function s(c, a) { var b; do { b = f.curCSS(c, a); if (b != "" && b != "transparent" || f.nodeName(c, "body")) break; a = "backgroundColor" } while (c = c.parentNode); return n(b) } function p() {
        var c = document.defaultView ? document.defaultView.getComputedStyle(this, null) : this.currentStyle,
a = {}, b, d; if (c && c.length && c[0] && c[c[0]]) for (var e = c.length; e--; ) { b = c[e]; if (typeof c[b] == "string") { d = b.replace(/\-(\w)/g, function (g, h) { return h.toUpperCase() }); a[d] = c[b] } } else for (b in c) if (typeof c[b] === "string") a[b] = c[b]; return a
    } function q(c) { var a, b; for (a in c) { b = c[a]; if (b == null || f.isFunction(b) || a in t || /scrollbar/.test(a) || !/color/i.test(a) && isNaN(parseFloat(b))) delete c[a] } return c } function u(c, a) { var b = { _: 0 }, d; for (d in a) if (c[d] != a[d]) b[d] = a[d]; return b } function k(c, a, b, d) {
        if (typeof c == "object") {
            d =
a; b = null; a = c; c = a.effect
        } if (f.isFunction(a)) { d = a; b = null; a = {} } if (typeof a == "number" || f.fx.speeds[a]) { d = b; b = a; a = {} } if (f.isFunction(b)) { d = b; b = null } a = a || {}; b = b || a.duration; b = f.fx.off ? 0 : typeof b == "number" ? b : b in f.fx.speeds ? f.fx.speeds[b] : f.fx.speeds._default; d = d || a.complete; return [c, a, b, d]
    } function m(c) { if (!c || typeof c === "number" || f.fx.speeds[c]) return true; if (typeof c === "string" && !f.effects[c]) return true; return false } f.effects = {}; f.each(["backgroundColor", "borderBottomColor", "borderLeftColor", "borderRightColor",
"borderTopColor", "borderColor", "color", "outlineColor"], function (c, a) { f.fx.step[a] = function (b) { if (!b.colorInit) { b.start = s(b.elem, a); b.end = n(b.end); b.colorInit = true } b.elem.style[a] = "rgb(" + Math.max(Math.min(parseInt(b.pos * (b.end[0] - b.start[0]) + b.start[0], 10), 255), 0) + "," + Math.max(Math.min(parseInt(b.pos * (b.end[1] - b.start[1]) + b.start[1], 10), 255), 0) + "," + Math.max(Math.min(parseInt(b.pos * (b.end[2] - b.start[2]) + b.start[2], 10), 255), 0) + ")" } }); var o = { aqua: [0, 255, 255], azure: [240, 255, 255], beige: [245, 245, 220], black: [0,
0, 0], blue: [0, 0, 255], brown: [165, 42, 42], cyan: [0, 255, 255], darkblue: [0, 0, 139], darkcyan: [0, 139, 139], darkgrey: [169, 169, 169], darkgreen: [0, 100, 0], darkkhaki: [189, 183, 107], darkmagenta: [139, 0, 139], darkolivegreen: [85, 107, 47], darkorange: [255, 140, 0], darkorchid: [153, 50, 204], darkred: [139, 0, 0], darksalmon: [233, 150, 122], darkviolet: [148, 0, 211], fuchsia: [255, 0, 255], gold: [255, 215, 0], green: [0, 128, 0], indigo: [75, 0, 130], khaki: [240, 230, 140], lightblue: [173, 216, 230], lightcyan: [224, 255, 255], lightgreen: [144, 238, 144], lightgrey: [211,
211, 211], lightpink: [255, 182, 193], lightyellow: [255, 255, 224], lime: [0, 255, 0], magenta: [255, 0, 255], maroon: [128, 0, 0], navy: [0, 0, 128], olive: [128, 128, 0], orange: [255, 165, 0], pink: [255, 192, 203], purple: [128, 0, 128], violet: [128, 0, 128], red: [255, 0, 0], silver: [192, 192, 192], white: [255, 255, 255], yellow: [255, 255, 0], transparent: [255, 255, 255]
}, r = ["add", "remove", "toggle"], t = { border: 1, borderBottom: 1, borderColor: 1, borderLeft: 1, borderRight: 1, borderTop: 1, borderWidth: 1, margin: 1, padding: 1 }; f.effects.animateClass = function (c, a, b,
d) {
    if (f.isFunction(b)) { d = b; b = null } return this.each(function () {
        f.queue(this, "fx", function () {
            var e = f(this), g = e.attr("style") || " ", h = q(p.call(this)), l, v = e.attr("className"); f.each(r, function (w, i) { c[i] && e[i + "Class"](c[i]) }); l = q(p.call(this)); e.attr("className", v); e.animate(u(h, l), a, b, function () { f.each(r, function (w, i) { c[i] && e[i + "Class"](c[i]) }); if (typeof e.attr("style") == "object") { e.attr("style").cssText = ""; e.attr("style").cssText = g } else e.attr("style", g); d && d.apply(this, arguments) }); h = f.queue(this); l =
h.splice(h.length - 1, 1)[0]; h.splice(1, 0, l); f.dequeue(this)
        })
    })
}; f.fn.extend({ _addClass: f.fn.addClass, addClass: function (c, a, b, d) { return a ? f.effects.animateClass.apply(this, [{ add: c }, a, b, d]) : this._addClass(c) }, _removeClass: f.fn.removeClass, removeClass: function (c, a, b, d) { return a ? f.effects.animateClass.apply(this, [{ remove: c }, a, b, d]) : this._removeClass(c) }, _toggleClass: f.fn.toggleClass, toggleClass: function (c, a, b, d, e) {
    return typeof a == "boolean" || a === j ? b ? f.effects.animateClass.apply(this, [a ? { add: c} : { remove: c },
b, d, e]) : this._toggleClass(c, a) : f.effects.animateClass.apply(this, [{ toggle: c }, a, b, d])
}, switchClass: function (c, a, b, d, e) { return f.effects.animateClass.apply(this, [{ add: a, remove: c }, b, d, e]) } 
}); f.extend(f.effects, { version: "1.8.7", save: function (c, a) { for (var b = 0; b < a.length; b++) a[b] !== null && c.data("ec.storage." + a[b], c[0].style[a[b]]) }, restore: function (c, a) { for (var b = 0; b < a.length; b++) a[b] !== null && c.css(a[b], c.data("ec.storage." + a[b])) }, setMode: function (c, a) {
    if (a == "toggle") a = c.is(":hidden") ? "show" : "hide";
    return a
}, getBaseline: function (c, a) { var b; switch (c[0]) { case "top": b = 0; break; case "middle": b = 0.5; break; case "bottom": b = 1; break; default: b = c[0] / a.height } switch (c[1]) { case "left": c = 0; break; case "center": c = 0.5; break; case "right": c = 1; break; default: c = c[1] / a.width } return { x: c, y: b} }, createWrapper: function (c) {
    if (c.parent().is(".ui-effects-wrapper")) return c.parent(); var a = { width: c.outerWidth(true), height: c.outerHeight(true), "float": c.css("float") }, b = f("<div></div>").addClass("ui-effects-wrapper").css({ fontSize: "100%",
        background: "transparent", border: "none", margin: 0, padding: 0
    }); c.wrap(b); b = c.parent(); if (c.css("position") == "static") { b.css({ position: "relative" }); c.css({ position: "relative" }) } else { f.extend(a, { position: c.css("position"), zIndex: c.css("z-index") }); f.each(["top", "left", "bottom", "right"], function (d, e) { a[e] = c.css(e); if (isNaN(parseInt(a[e], 10))) a[e] = "auto" }); c.css({ position: "relative", top: 0, left: 0 }) } return b.css(a).show()
}, removeWrapper: function (c) {
    if (c.parent().is(".ui-effects-wrapper")) return c.parent().replaceWith(c);
    return c
}, setTransition: function (c, a, b, d) { d = d || {}; f.each(a, function (e, g) { unit = c.cssUnit(g); if (unit[0] > 0) d[g] = unit[0] * b + unit[1] }); return d } 
}); f.fn.extend({ effect: function (c) { var a = k.apply(this, arguments), b = { options: a[1], duration: a[2], callback: a[3] }; a = b.options.mode; var d = f.effects[c]; if (f.fx.off || !d) return a ? this[a](b.duration, b.callback) : this.each(function () { b.callback && b.callback.call(this) }); return d.call(this, b) }, _show: f.fn.show, show: function (c) {
    if (m(c)) return this._show.apply(this, arguments);
    else { var a = k.apply(this, arguments); a[1].mode = "show"; return this.effect.apply(this, a) } 
}, _hide: f.fn.hide, hide: function (c) { if (m(c)) return this._hide.apply(this, arguments); else { var a = k.apply(this, arguments); a[1].mode = "hide"; return this.effect.apply(this, a) } }, __toggle: f.fn.toggle, toggle: function (c) { if (m(c) || typeof c === "boolean" || f.isFunction(c)) return this.__toggle.apply(this, arguments); else { var a = k.apply(this, arguments); a[1].mode = "toggle"; return this.effect.apply(this, a) } }, cssUnit: function (c) {
    var a = this.css(c),
b = []; f.each(["em", "px", "%", "pt"], function (d, e) { if (a.indexOf(e) > 0) b = [parseFloat(a), e] }); return b
} 
}); f.easing.jswing = f.easing.swing; f.extend(f.easing, { def: "easeOutQuad", swing: function (c, a, b, d, e) { return f.easing[f.easing.def](c, a, b, d, e) }, easeInQuad: function (c, a, b, d, e) { return d * (a /= e) * a + b }, easeOutQuad: function (c, a, b, d, e) { return -d * (a /= e) * (a - 2) + b }, easeInOutQuad: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a + b; return -d / 2 * (--a * (a - 2) - 1) + b }, easeInCubic: function (c, a, b, d, e) { return d * (a /= e) * a * a + b }, easeOutCubic: function (c,
a, b, d, e) { return d * ((a = a / e - 1) * a * a + 1) + b }, easeInOutCubic: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a + b; return d / 2 * ((a -= 2) * a * a + 2) + b }, easeInQuart: function (c, a, b, d, e) { return d * (a /= e) * a * a * a + b }, easeOutQuart: function (c, a, b, d, e) { return -d * ((a = a / e - 1) * a * a * a - 1) + b }, easeInOutQuart: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a * a + b; return -d / 2 * ((a -= 2) * a * a * a - 2) + b }, easeInQuint: function (c, a, b, d, e) { return d * (a /= e) * a * a * a * a + b }, easeOutQuint: function (c, a, b, d, e) { return d * ((a = a / e - 1) * a * a * a * a + 1) + b }, easeInOutQuint: function (c,
a, b, d, e) { if ((a /= e / 2) < 1) return d / 2 * a * a * a * a * a + b; return d / 2 * ((a -= 2) * a * a * a * a + 2) + b }, easeInSine: function (c, a, b, d, e) { return -d * Math.cos(a / e * (Math.PI / 2)) + d + b }, easeOutSine: function (c, a, b, d, e) { return d * Math.sin(a / e * (Math.PI / 2)) + b }, easeInOutSine: function (c, a, b, d, e) { return -d / 2 * (Math.cos(Math.PI * a / e) - 1) + b }, easeInExpo: function (c, a, b, d, e) { return a == 0 ? b : d * Math.pow(2, 10 * (a / e - 1)) + b }, easeOutExpo: function (c, a, b, d, e) { return a == e ? b + d : d * (-Math.pow(2, -10 * a / e) + 1) + b }, easeInOutExpo: function (c, a, b, d, e) {
    if (a == 0) return b; if (a ==
e) return b + d; if ((a /= e / 2) < 1) return d / 2 * Math.pow(2, 10 * (a - 1)) + b; return d / 2 * (-Math.pow(2, -10 * --a) + 2) + b
}, easeInCirc: function (c, a, b, d, e) { return -d * (Math.sqrt(1 - (a /= e) * a) - 1) + b }, easeOutCirc: function (c, a, b, d, e) { return d * Math.sqrt(1 - (a = a / e - 1) * a) + b }, easeInOutCirc: function (c, a, b, d, e) { if ((a /= e / 2) < 1) return -d / 2 * (Math.sqrt(1 - a * a) - 1) + b; return d / 2 * (Math.sqrt(1 - (a -= 2) * a) + 1) + b }, easeInElastic: function (c, a, b, d, e) {
    c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e) == 1) return b + d; g || (g = e * 0.3); if (h < Math.abs(d)) { h = d; c = g / 4 } else c =
g / (2 * Math.PI) * Math.asin(d / h); return -(h * Math.pow(2, 10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g)) + b
}, easeOutElastic: function (c, a, b, d, e) { c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e) == 1) return b + d; g || (g = e * 0.3); if (h < Math.abs(d)) { h = d; c = g / 4 } else c = g / (2 * Math.PI) * Math.asin(d / h); return h * Math.pow(2, -10 * a) * Math.sin((a * e - c) * 2 * Math.PI / g) + d + b }, easeInOutElastic: function (c, a, b, d, e) {
    c = 1.70158; var g = 0, h = d; if (a == 0) return b; if ((a /= e / 2) == 2) return b + d; g || (g = e * 0.3 * 1.5); if (h < Math.abs(d)) { h = d; c = g / 4 } else c = g / (2 * Math.PI) * Math.asin(d /
h); if (a < 1) return -0.5 * h * Math.pow(2, 10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g) + b; return h * Math.pow(2, -10 * (a -= 1)) * Math.sin((a * e - c) * 2 * Math.PI / g) * 0.5 + d + b
}, easeInBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; return d * (a /= e) * a * ((g + 1) * a - g) + b }, easeOutBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; return d * ((a = a / e - 1) * a * ((g + 1) * a + g) + 1) + b }, easeInOutBack: function (c, a, b, d, e, g) { if (g == j) g = 1.70158; if ((a /= e / 2) < 1) return d / 2 * a * a * (((g *= 1.525) + 1) * a - g) + b; return d / 2 * ((a -= 2) * a * (((g *= 1.525) + 1) * a + g) + 2) + b }, easeInBounce: function (c,
a, b, d, e) { return d - f.easing.easeOutBounce(c, e - a, 0, d, e) + b }, easeOutBounce: function (c, a, b, d, e) { return (a /= e) < 1 / 2.75 ? d * 7.5625 * a * a + b : a < 2 / 2.75 ? d * (7.5625 * (a -= 1.5 / 2.75) * a + 0.75) + b : a < 2.5 / 2.75 ? d * (7.5625 * (a -= 2.25 / 2.75) * a + 0.9375) + b : d * (7.5625 * (a -= 2.625 / 2.75) * a + 0.984375) + b }, easeInOutBounce: function (c, a, b, d, e) { if (a < e / 2) return f.easing.easeInBounce(c, a * 2, 0, d, e) * 0.5 + b; return f.easing.easeOutBounce(c, a * 2 - e, 0, d, e) * 0.5 + d * 0.5 + b } 
})
} (jQuery);
; /*
 * jQuery UI Effects Blind 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Blind
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (b) {
    b.effects.blind = function (c) {
        return this.queue(function () {
            var a = b(this), g = ["position", "top", "left"], f = b.effects.setMode(a, c.options.mode || "hide"), d = c.options.direction || "vertical"; b.effects.save(a, g); a.show(); var e = b.effects.createWrapper(a).css({ overflow: "hidden" }), h = d == "vertical" ? "height" : "width"; d = d == "vertical" ? e.height() : e.width(); f == "show" && e.css(h, 0); var i = {}; i[h] = f == "show" ? d : 0; e.animate(i, c.duration, c.options.easing, function () {
                f == "hide" && a.hide(); b.effects.restore(a, g); b.effects.removeWrapper(a);
                c.callback && c.callback.apply(a[0], arguments); a.dequeue()
            })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Bounce 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Bounce
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (e) {
    e.effects.bounce = function (b) {
        return this.queue(function () {
            var a = e(this), l = ["position", "top", "left"], h = e.effects.setMode(a, b.options.mode || "effect"), d = b.options.direction || "up", c = b.options.distance || 20, m = b.options.times || 5, i = b.duration || 250; /show|hide/.test(h) && l.push("opacity"); e.effects.save(a, l); a.show(); e.effects.createWrapper(a); var f = d == "up" || d == "down" ? "top" : "left"; d = d == "up" || d == "left" ? "pos" : "neg"; c = b.options.distance || (f == "top" ? a.outerHeight({ margin: true }) / 3 : a.outerWidth({ margin: true }) /
3); if (h == "show") a.css("opacity", 0).css(f, d == "pos" ? -c : c); if (h == "hide") c /= m * 2; h != "hide" && m--; if (h == "show") { var g = { opacity: 1 }; g[f] = (d == "pos" ? "+=" : "-=") + c; a.animate(g, i / 2, b.options.easing); c /= 2; m-- } for (g = 0; g < m; g++) { var j = {}, k = {}; j[f] = (d == "pos" ? "-=" : "+=") + c; k[f] = (d == "pos" ? "+=" : "-=") + c; a.animate(j, i / 2, b.options.easing).animate(k, i / 2, b.options.easing); c = h == "hide" ? c * 2 : c / 2 } if (h == "hide") {
                g = { opacity: 0 }; g[f] = (d == "pos" ? "-=" : "+=") + c; a.animate(g, i / 2, b.options.easing, function () {
                    a.hide(); e.effects.restore(a, l); e.effects.removeWrapper(a);
                    b.callback && b.callback.apply(this, arguments)
                })
            } else { j = {}; k = {}; j[f] = (d == "pos" ? "-=" : "+=") + c; k[f] = (d == "pos" ? "+=" : "-=") + c; a.animate(j, i / 2, b.options.easing).animate(k, i / 2, b.options.easing, function () { e.effects.restore(a, l); e.effects.removeWrapper(a); b.callback && b.callback.apply(this, arguments) }) } a.queue("fx", function () { a.dequeue() }); a.dequeue()
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Clip 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Clip
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (b) {
    b.effects.clip = function (e) {
        return this.queue(function () {
            var a = b(this), i = ["position", "top", "left", "height", "width"], f = b.effects.setMode(a, e.options.mode || "hide"), c = e.options.direction || "vertical"; b.effects.save(a, i); a.show(); var d = b.effects.createWrapper(a).css({ overflow: "hidden" }); d = a[0].tagName == "IMG" ? d : a; var g = { size: c == "vertical" ? "height" : "width", position: c == "vertical" ? "top" : "left" }; c = c == "vertical" ? d.height() : d.width(); if (f == "show") { d.css(g.size, 0); d.css(g.position, c / 2) } var h = {}; h[g.size] =
f == "show" ? c : 0; h[g.position] = f == "show" ? 0 : c / 2; d.animate(h, { queue: false, duration: e.duration, easing: e.options.easing, complete: function () { f == "hide" && a.hide(); b.effects.restore(a, i); b.effects.removeWrapper(a); e.callback && e.callback.apply(a[0], arguments); a.dequeue() } })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Drop 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Drop
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (c) {
    c.effects.drop = function (d) {
        return this.queue(function () {
            var a = c(this), h = ["position", "top", "left", "opacity"], e = c.effects.setMode(a, d.options.mode || "hide"), b = d.options.direction || "left"; c.effects.save(a, h); a.show(); c.effects.createWrapper(a); var f = b == "up" || b == "down" ? "top" : "left"; b = b == "up" || b == "left" ? "pos" : "neg"; var g = d.options.distance || (f == "top" ? a.outerHeight({ margin: true }) / 2 : a.outerWidth({ margin: true }) / 2); if (e == "show") a.css("opacity", 0).css(f, b == "pos" ? -g : g); var i = { opacity: e == "show" ? 1 :
0
            }; i[f] = (e == "show" ? b == "pos" ? "+=" : "-=" : b == "pos" ? "-=" : "+=") + g; a.animate(i, { queue: false, duration: d.duration, easing: d.options.easing, complete: function () { e == "hide" && a.hide(); c.effects.restore(a, h); c.effects.removeWrapper(a); d.callback && d.callback.apply(this, arguments); a.dequeue() } })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Explode 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Explode
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (j) {
    j.effects.explode = function (a) {
        return this.queue(function () {
            var c = a.options.pieces ? Math.round(Math.sqrt(a.options.pieces)) : 3, d = a.options.pieces ? Math.round(Math.sqrt(a.options.pieces)) : 3; a.options.mode = a.options.mode == "toggle" ? j(this).is(":visible") ? "hide" : "show" : a.options.mode; var b = j(this).show().css("visibility", "hidden"), g = b.offset(); g.top -= parseInt(b.css("marginTop"), 10) || 0; g.left -= parseInt(b.css("marginLeft"), 10) || 0; for (var h = b.outerWidth(true), i = b.outerHeight(true), e = 0; e < c; e++) for (var f =
0; f < d; f++) b.clone().appendTo("body").wrap("<div></div>").css({ position: "absolute", visibility: "visible", left: -f * (h / d), top: -e * (i / c) }).parent().addClass("ui-effects-explode").css({ position: "absolute", overflow: "hidden", width: h / d, height: i / c, left: g.left + f * (h / d) + (a.options.mode == "show" ? (f - Math.floor(d / 2)) * (h / d) : 0), top: g.top + e * (i / c) + (a.options.mode == "show" ? (e - Math.floor(c / 2)) * (i / c) : 0), opacity: a.options.mode == "show" ? 0 : 1 }).animate({ left: g.left + f * (h / d) + (a.options.mode == "show" ? 0 : (f - Math.floor(d / 2)) * (h / d)), top: g.top +
e * (i / c) + (a.options.mode == "show" ? 0 : (e - Math.floor(c / 2)) * (i / c)), opacity: a.options.mode == "show" ? 1 : 0
}, a.duration || 500); setTimeout(function () { a.options.mode == "show" ? b.css({ visibility: "visible" }) : b.css({ visibility: "visible" }).hide(); a.callback && a.callback.apply(b[0]); b.dequeue(); j("div.ui-effects-explode").remove() }, a.duration || 500)
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Fade 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Fade
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (b) { b.effects.fade = function (a) { return this.queue(function () { var c = b(this), d = b.effects.setMode(c, a.options.mode || "hide"); c.animate({ opacity: d }, { queue: false, duration: a.duration, easing: a.options.easing, complete: function () { a.callback && a.callback.apply(this, arguments); c.dequeue() } }) }) } })(jQuery);
; /*
 * jQuery UI Effects Fold 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Fold
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (c) {
    c.effects.fold = function (a) {
        return this.queue(function () {
            var b = c(this), j = ["position", "top", "left"], d = c.effects.setMode(b, a.options.mode || "hide"), g = a.options.size || 15, h = !!a.options.horizFirst, k = a.duration ? a.duration / 2 : c.fx.speeds._default / 2; c.effects.save(b, j); b.show(); var e = c.effects.createWrapper(b).css({ overflow: "hidden" }), f = d == "show" != h, l = f ? ["width", "height"] : ["height", "width"]; f = f ? [e.width(), e.height()] : [e.height(), e.width()]; var i = /([0-9]+)%/.exec(g); if (i) g = parseInt(i[1], 10) / 100 *
f[d == "hide" ? 0 : 1]; if (d == "show") e.css(h ? { height: 0, width: g} : { height: g, width: 0 }); h = {}; i = {}; h[l[0]] = d == "show" ? f[0] : g; i[l[1]] = d == "show" ? f[1] : 0; e.animate(h, k, a.options.easing).animate(i, k, a.options.easing, function () { d == "hide" && b.hide(); c.effects.restore(b, j); c.effects.removeWrapper(b); a.callback && a.callback.apply(b[0], arguments); b.dequeue() })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Highlight 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Highlight
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (b) {
    b.effects.highlight = function (c) {
        return this.queue(function () {
            var a = b(this), e = ["backgroundImage", "backgroundColor", "opacity"], d = b.effects.setMode(a, c.options.mode || "show"), f = { backgroundColor: a.css("backgroundColor") }; if (d == "hide") f.opacity = 0; b.effects.save(a, e); a.show().css({ backgroundImage: "none", backgroundColor: c.options.color || "#ffff99" }).animate(f, { queue: false, duration: c.duration, easing: c.options.easing, complete: function () {
                d == "hide" && a.hide(); b.effects.restore(a, e); d == "show" && !b.support.opacity &&
this.style.removeAttribute("filter"); c.callback && c.callback.apply(this, arguments); a.dequeue()
            } 
            })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Pulsate 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Pulsate
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (d) {
    d.effects.pulsate = function (a) {
        return this.queue(function () {
            var b = d(this), c = d.effects.setMode(b, a.options.mode || "show"); times = (a.options.times || 5) * 2 - 1; duration = a.duration ? a.duration / 2 : d.fx.speeds._default / 2; isVisible = b.is(":visible"); animateTo = 0; if (!isVisible) { b.css("opacity", 0).show(); animateTo = 1 } if (c == "hide" && isVisible || c == "show" && !isVisible) times--; for (c = 0; c < times; c++) { b.animate({ opacity: animateTo }, duration, a.options.easing); animateTo = (animateTo + 1) % 2 } b.animate({ opacity: animateTo }, duration,
a.options.easing, function () { animateTo == 0 && b.hide(); a.callback && a.callback.apply(this, arguments) }); b.queue("fx", function () { b.dequeue() }).dequeue()
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Scale 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Scale
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (c) {
    c.effects.puff = function (b) { return this.queue(function () { var a = c(this), e = c.effects.setMode(a, b.options.mode || "hide"), g = parseInt(b.options.percent, 10) || 150, h = g / 100, i = { height: a.height(), width: a.width() }; c.extend(b.options, { fade: true, mode: e, percent: e == "hide" ? g : 100, from: e == "hide" ? i : { height: i.height * h, width: i.width * h} }); a.effect("scale", b.options, b.duration, b.callback); a.dequeue() }) }; c.effects.scale = function (b) {
        return this.queue(function () {
            var a = c(this), e = c.extend(true, {}, b.options), g = c.effects.setMode(a,
b.options.mode || "effect"), h = parseInt(b.options.percent, 10) || (parseInt(b.options.percent, 10) == 0 ? 0 : g == "hide" ? 0 : 100), i = b.options.direction || "both", f = b.options.origin; if (g != "effect") { e.origin = f || ["middle", "center"]; e.restore = true } f = { height: a.height(), width: a.width() }; a.from = b.options.from || (g == "show" ? { height: 0, width: 0} : f); h = { y: i != "horizontal" ? h / 100 : 1, x: i != "vertical" ? h / 100 : 1 }; a.to = { height: f.height * h.y, width: f.width * h.x }; if (b.options.fade) {
                if (g == "show") { a.from.opacity = 0; a.to.opacity = 1 } if (g == "hide") {
                    a.from.opacity =
1; a.to.opacity = 0
                } 
            } e.from = a.from; e.to = a.to; e.mode = g; a.effect("size", e, b.duration, b.callback); a.dequeue()
        })
    }; c.effects.size = function (b) {
        return this.queue(function () {
            var a = c(this), e = ["position", "top", "left", "width", "height", "overflow", "opacity"], g = ["position", "top", "left", "overflow", "opacity"], h = ["width", "height", "overflow"], i = ["fontSize"], f = ["borderTopWidth", "borderBottomWidth", "paddingTop", "paddingBottom"], k = ["borderLeftWidth", "borderRightWidth", "paddingLeft", "paddingRight"], p = c.effects.setMode(a,
b.options.mode || "effect"), n = b.options.restore || false, m = b.options.scale || "both", l = b.options.origin, j = { height: a.height(), width: a.width() }; a.from = b.options.from || j; a.to = b.options.to || j; if (l) { l = c.effects.getBaseline(l, j); a.from.top = (j.height - a.from.height) * l.y; a.from.left = (j.width - a.from.width) * l.x; a.to.top = (j.height - a.to.height) * l.y; a.to.left = (j.width - a.to.width) * l.x } var d = { from: { y: a.from.height / j.height, x: a.from.width / j.width }, to: { y: a.to.height / j.height, x: a.to.width / j.width} }; if (m == "box" || m == "both") {
                if (d.from.y !=
d.to.y) { e = e.concat(f); a.from = c.effects.setTransition(a, f, d.from.y, a.from); a.to = c.effects.setTransition(a, f, d.to.y, a.to) } if (d.from.x != d.to.x) { e = e.concat(k); a.from = c.effects.setTransition(a, k, d.from.x, a.from); a.to = c.effects.setTransition(a, k, d.to.x, a.to) } 
            } if (m == "content" || m == "both") if (d.from.y != d.to.y) { e = e.concat(i); a.from = c.effects.setTransition(a, i, d.from.y, a.from); a.to = c.effects.setTransition(a, i, d.to.y, a.to) } c.effects.save(a, n ? e : g); a.show(); c.effects.createWrapper(a); a.css("overflow", "hidden").css(a.from);
            if (m == "content" || m == "both") {
                f = f.concat(["marginTop", "marginBottom"]).concat(i); k = k.concat(["marginLeft", "marginRight"]); h = e.concat(f).concat(k); a.find("*[width]").each(function () {
                    child = c(this); n && c.effects.save(child, h); var o = { height: child.height(), width: child.width() }; child.from = { height: o.height * d.from.y, width: o.width * d.from.x }; child.to = { height: o.height * d.to.y, width: o.width * d.to.x }; if (d.from.y != d.to.y) {
                        child.from = c.effects.setTransition(child, f, d.from.y, child.from); child.to = c.effects.setTransition(child,
f, d.to.y, child.to)
                    } if (d.from.x != d.to.x) { child.from = c.effects.setTransition(child, k, d.from.x, child.from); child.to = c.effects.setTransition(child, k, d.to.x, child.to) } child.css(child.from); child.animate(child.to, b.duration, b.options.easing, function () { n && c.effects.restore(child, h) })
                })
            } a.animate(a.to, { queue: false, duration: b.duration, easing: b.options.easing, complete: function () {
                a.to.opacity === 0 && a.css("opacity", a.from.opacity); p == "hide" && a.hide(); c.effects.restore(a, n ? e : g); c.effects.removeWrapper(a); b.callback &&
b.callback.apply(this, arguments); a.dequeue()
            } 
            })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Shake 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Shake
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (d) {
    d.effects.shake = function (a) {
        return this.queue(function () {
            var b = d(this), j = ["position", "top", "left"]; d.effects.setMode(b, a.options.mode || "effect"); var c = a.options.direction || "left", e = a.options.distance || 20, l = a.options.times || 3, f = a.duration || a.options.duration || 140; d.effects.save(b, j); b.show(); d.effects.createWrapper(b); var g = c == "up" || c == "down" ? "top" : "left", h = c == "up" || c == "left" ? "pos" : "neg"; c = {}; var i = {}, k = {}; c[g] = (h == "pos" ? "-=" : "+=") + e; i[g] = (h == "pos" ? "+=" : "-=") + e * 2; k[g] = (h == "pos" ? "-=" : "+=") +
e * 2; b.animate(c, f, a.options.easing); for (e = 1; e < l; e++) b.animate(i, f, a.options.easing).animate(k, f, a.options.easing); b.animate(i, f, a.options.easing).animate(c, f / 2, a.options.easing, function () { d.effects.restore(b, j); d.effects.removeWrapper(b); a.callback && a.callback.apply(this, arguments) }); b.queue("fx", function () { b.dequeue() }); b.dequeue()
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Slide 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Slide
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (c) {
    c.effects.slide = function (d) {
        return this.queue(function () {
            var a = c(this), h = ["position", "top", "left"], f = c.effects.setMode(a, d.options.mode || "show"), b = d.options.direction || "left"; c.effects.save(a, h); a.show(); c.effects.createWrapper(a).css({ overflow: "hidden" }); var g = b == "up" || b == "down" ? "top" : "left"; b = b == "up" || b == "left" ? "pos" : "neg"; var e = d.options.distance || (g == "top" ? a.outerHeight({ margin: true }) : a.outerWidth({ margin: true })); if (f == "show") a.css(g, b == "pos" ? isNaN(e) ? "-" + e : -e : e); var i = {}; i[g] = (f ==
"show" ? b == "pos" ? "+=" : "-=" : b == "pos" ? "-=" : "+=") + e; a.animate(i, { queue: false, duration: d.duration, easing: d.options.easing, complete: function () { f == "hide" && a.hide(); c.effects.restore(a, h); c.effects.removeWrapper(a); d.callback && d.callback.apply(this, arguments); a.dequeue() } })
        })
    } 
})(jQuery);
; /*
 * jQuery UI Effects Transfer 1.8.7
 *
 * Copyright 2010, AUTHORS.txt (http://jqueryui.com/about)
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 *
 * http://docs.jquery.com/UI/Effects/Transfer
 *
 * Depends:
 *	jquery.effects.core.js
 */
(function (e) {
    e.effects.transfer = function (a) {
        return this.queue(function () {
            var b = e(this), c = e(a.options.to), d = c.offset(); c = { top: d.top, left: d.left, height: c.innerHeight(), width: c.innerWidth() }; d = b.offset(); var f = e('<div class="ui-effects-transfer"></div>').appendTo(document.body).addClass(a.options.className).css({ top: d.top, left: d.left, height: b.innerHeight(), width: b.innerWidth(), position: "absolute" }).animate(c, a.duration, a.options.easing, function () {
                f.remove(); a.callback && a.callback.apply(b[0], arguments);
                b.dequeue()
            })
        })
    } 
})(jQuery);
;
/*
* jQuery Tools 1.2.5 - The missing UI library for the Web
* 
* [toolbox.flashembed, toolbox.history, toolbox.expose, toolbox.mousewheel, tabs, tabs.slideshow, tooltip, tooltip.slide, tooltip.dynamic, scrollable, scrollable.autoscroll, scrollable.navigator, overlay, overlay.apple, dateinput, rangeinput, validator]
* 
* NO COPYRIGHTS OR LICENSES. DO WHAT YOU LIKE.
* 
* http://flowplayer.org/tools/
* 
* jquery.event.wheel.js - rev 1 
* Copyright (c) 2008, Three Dub Media (http://threedubmedia.com)
* Liscensed under the MIT License (MIT-LICENSE.txt)
* http://www.opensource.org/licenses/mit-license.php
* Created: 2008-07-01 | Updated: 2008-07-14
* 
* -----
* 
* File generated: Wed Sep 22 06:12:53 GMT 2010
*/
(function () {
    function f(a, b) { if (b) for (var c in b) if (b.hasOwnProperty(c)) a[c] = b[c]; return a } function l(a, b) { var c = []; for (var d in a) if (a.hasOwnProperty(d)) c[d] = b(a[d]); return c } function m(a, b, c) {
        if (e.isSupported(b.version)) a.innerHTML = e.getHTML(b, c); else if (b.expressInstall && e.isSupported([6, 65])) a.innerHTML = e.getHTML(f(b, { src: b.expressInstall }), { MMredirectURL: location.href, MMplayerType: "PlugIn", MMdoctitle: document.title }); else {
            if (!a.innerHTML.replace(/\s/g, "")) {
                a.innerHTML = "<h2>Flash version " + b.version +
" or greater is required</h2><h3>" + (g[0] > 0 ? "Your version is " + g : "You have no flash plugin installed") + "</h3>" + (a.tagName == "A" ? "<p>Click here to download latest version</p>" : "<p>Download latest version from <a href='" + k + "'>here</a></p>"); if (a.tagName == "A") a.onclick = function () { location.href = k } 
            } if (b.onFail) { var d = b.onFail.call(this); if (typeof d == "string") a.innerHTML = d } 
        } if (i) window[b.id] = document.getElementById(b.id); f(this, { getRoot: function () { return a }, getOptions: function () { return b }, getConf: function () { return c },
            getApi: function () { return a.firstChild } 
        })
    } var i = document.all, k = "http://www.adobe.com/go/getflashplayer", n = typeof jQuery == "function", o = /(\d+)[^\d]+(\d+)[^\d]*(\d*)/, j = { width: "100%", height: "100%", id: "_" + ("" + Math.random()).slice(9), allowfullscreen: true, allowscriptaccess: "always", quality: "high", version: [3, 0], onFail: null, expressInstall: null, w3c: false, cachebusting: false }; window.attachEvent && window.attachEvent("onbeforeunload", function () { __flash_unloadHandler = function () { }; __flash_savedUnloadHandler = function () { } });
    window.flashembed = function (a, b, c) { if (typeof a == "string") a = document.getElementById(a.replace("#", "")); if (a) { if (typeof b == "string") b = { src: b }; return new m(a, f(f({}, j), b), c) } }; var e = f(window.flashembed, { conf: j, getVersion: function () {
        var a, b; try { b = navigator.plugins["Shockwave Flash"].description.slice(16) } catch (c) { try { b = (a = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7")) && a.GetVariable("$version") } catch (d) { try { b = (a = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6")) && a.GetVariable("$version") } catch (h) { } } } return (b =
o.exec(b)) ? [b[1], b[3]] : [0, 0]
    }, asString: function (a) {
        if (a === null || a === undefined) return null; var b = typeof a; if (b == "object" && a.push) b = "array"; switch (b) { case "string": a = a.replace(new RegExp('(["\\\\])', "g"), "\\$1"); a = a.replace(/^\s?(\d+\.?\d+)%/, "$1pct"); return '"' + a + '"'; case "array": return "[" + l(a, function (d) { return e.asString(d) }).join(",") + "]"; case "function": return '"function()"'; case "object": b = []; for (var c in a) a.hasOwnProperty(c) && b.push('"' + c + '":' + e.asString(a[c])); return "{" + b.join(",") + "}" } return String(a).replace(/\s/g,
" ").replace(/\'/g, '"')
    }, getHTML: function (a, b) {
        a = f({}, a); var c = '<object width="' + a.width + '" height="' + a.height + '" id="' + a.id + '" name="' + a.id + '"'; if (a.cachebusting) a.src += (a.src.indexOf("?") != -1 ? "&" : "?") + Math.random(); c += a.w3c || !i ? ' data="' + a.src + '" type="application/x-shockwave-flash"' : ' classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"'; c += ">"; if (a.w3c || i) c += '<param name="movie" value="' + a.src + '" />'; a.width = a.height = a.id = a.w3c = a.src = null; a.onFail = a.version = a.expressInstall = null; for (var d in a) if (a[d]) c +=
'<param name="' + d + '" value="' + a[d] + '" />'; a = ""; if (b) { for (var h in b) if (b[h]) { d = b[h]; a += h + "=" + (/function|object/.test(typeof d) ? e.asString(d) : d) + "&" } a = a.slice(0, -1); c += '<param name="flashvars" value=\'' + a + "' />" } c += "</object>"; return c
    }, isSupported: function (a) { return g[0] > a[0] || g[0] == a[0] && g[1] >= a[1] } 
    }), g = e.getVersion(); if (n) {
        jQuery.tools = jQuery.tools || { version: "1.2.5" }; jQuery.tools.flashembed = { conf: j }; jQuery.fn.flashembed = function (a, b) {
            return this.each(function () {
                $(this).data("flashembed", flashembed(this,
a, b))
            })
        } 
    } 
})();
(function (b) {
    function h(c) { if (c) { var a = d.contentWindow.document; a.open().close(); a.location.hash = c } } var g, d, f, i; b.tools = b.tools || { version: "1.2.5" }; b.tools.history = { init: function (c) {
        if (!i) {
            if (b.browser.msie && b.browser.version < "8") { if (!d) { d = b("<iframe/>").attr("src", "javascript:false;").hide().get(0); b("body").append(d); setInterval(function () { var a = d.contentWindow.document; a = a.location.hash; g !== a && b.event.trigger("hash", a) }, 100); h(location.hash || "#") } } else setInterval(function () {
                var a = location.hash;
                a !== g && b.event.trigger("hash", a)
            }, 100); f = !f ? c : f.add(c); c.click(function (a) { var e = b(this).attr("href"); d && h(e); if (e.slice(0, 1) != "#") { location.href = "#" + e; return a.preventDefault() } }); i = true
        } 
    } 
    }; b(window).bind("hash", function (c, a) { a ? f.filter(function () { var e = b(this).attr("href"); return e == a || e == a.replace("#", "") }).trigger("history", [a]) : f.eq(0).trigger("history", [a]); g = a }); b.fn.history = function (c) { b.tools.history.init(this); return this.bind("history", c) } 
})(jQuery);
(function (b) {
    function k() { if (b.browser.msie) { var a = b(document).height(), d = b(window).height(); return [window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth, a - d < 20 ? d : a] } return [b(document).width(), b(document).height()] } function h(a) { if (a) return a.call(b.mask) } b.tools = b.tools || { version: "1.2.5" }; var l; l = b.tools.expose = { conf: { maskId: "exposeMask", loadSpeed: "slow", closeSpeed: "fast", closeOnClick: true, closeOnEsc: true, zIndex: 9998, opacity: 0.8, startOpacity: 0, color: "#fff", onLoad: null,
        onClose: null
    }
    }; var c, i, e, g, j; b.mask = { load: function (a, d) {
        if (e) return this; if (typeof a == "string") a = { color: a }; a = a || g; g = a = b.extend(b.extend({}, l.conf), a); c = b("#" + a.maskId); if (!c.length) { c = b("<div/>").attr("id", a.maskId); b("body").append(c) } var m = k(); c.css({ position: "absolute", top: 0, left: 0, width: m[0], height: m[1], display: "none", opacity: a.startOpacity, zIndex: a.zIndex }); a.color && c.css("backgroundColor", a.color); if (h(a.onBeforeLoad) === false) return this; a.closeOnEsc && b(document).bind("keydown.mask", function (f) {
            f.keyCode ==
27 && b.mask.close(f)
        }); a.closeOnClick && c.bind("click.mask", function (f) { b.mask.close(f) }); b(window).bind("resize.mask", function () { b.mask.fit() }); if (d && d.length) { j = d.eq(0).css("zIndex"); b.each(d, function () { var f = b(this); /relative|absolute|fixed/i.test(f.css("position")) || f.css("position", "relative") }); i = d.css({ zIndex: Math.max(a.zIndex + 1, j == "auto" ? 0 : j) }) } c.css({ display: "block" }).fadeTo(a.loadSpeed, a.opacity, function () { b.mask.fit(); h(a.onLoad); e = "full" }); e = true; return this
    }, close: function () {
        if (e) {
            if (h(g.onBeforeClose) ===
false) return this; c.fadeOut(g.closeSpeed, function () { h(g.onClose); i && i.css({ zIndex: j }); e = false }); b(document).unbind("keydown.mask"); c.unbind("click.mask"); b(window).unbind("resize.mask")
        } return this
    }, fit: function () { if (e) { var a = k(); c.css({ width: a[0], height: a[1] }) } }, getMask: function () { return c }, isLoaded: function (a) { return a ? e == "full" : e }, getConf: function () { return g }, getExposed: function () { return i } 
    }; b.fn.mask = function (a) { b.mask.load(a); return this }; b.fn.expose = function (a) { b.mask.load(a, this); return this } 
})(jQuery);
(function (b) {
    function c(a) { switch (a.type) { case "mousemove": return b.extend(a.data, { clientX: a.clientX, clientY: a.clientY, pageX: a.pageX, pageY: a.pageY }); case "DOMMouseScroll": b.extend(a, a.data); a.delta = -a.detail / 3; break; case "mousewheel": a.delta = a.wheelDelta / 120; break } a.type = "wheel"; return b.event.handle.call(this, a, a.delta) } b.fn.mousewheel = function (a) { return this[a ? "bind" : "trigger"]("wheel", a) }; b.event.special.wheel = { setup: function () { b.event.add(this, d, c, {}) }, teardown: function () {
        b.event.remove(this,
d, c)
    } 
    }; var d = !b.browser.mozilla ? "mousewheel" : "DOMMouseScroll" + (b.browser.version < "1.9" ? " mousemove" : "")
})(jQuery);
(function (c) {
    function p(d, b, a) {
        var e = this, l = d.add(this), h = d.find(a.tabs), i = b.jquery ? b : d.children(b), j; h.length || (h = d.children()); i.length || (i = d.parent().find(b)); i.length || (i = c(b)); c.extend(this, { click: function (f, g) {
            var k = h.eq(f); if (typeof f == "string" && f.replace("#", "")) { k = h.filter("[href*=" + f.replace("#", "") + "]"); f = Math.max(h.index(k), 0) } if (a.rotate) { var n = h.length - 1; if (f < 0) return e.click(n, g); if (f > n) return e.click(0, g) } if (!k.length) { if (j >= 0) return e; f = a.initialIndex; k = h.eq(f) } if (f === j) return e;
            g = g || c.Event(); g.type = "onBeforeClick"; l.trigger(g, [f]); if (!g.isDefaultPrevented()) { o[a.effect].call(e, f, function () { g.type = "onClick"; l.trigger(g, [f]) }); j = f; h.removeClass(a.current); k.addClass(a.current); return e } 
        }, getConf: function () { return a }, getTabs: function () { return h }, getPanes: function () { return i }, getCurrentPane: function () { return i.eq(j) }, getCurrentTab: function () { return h.eq(j) }, getIndex: function () { return j }, next: function () { return e.click(j + 1) }, prev: function () { return e.click(j - 1) }, destroy: function () {
            h.unbind(a.event).removeClass(a.current);
            i.find("a[href^=#]").unbind("click.T"); return e
        } 
        }); c.each("onBeforeClick,onClick".split(","), function (f, g) { c.isFunction(a[g]) && c(e).bind(g, a[g]); e[g] = function (k) { k && c(e).bind(g, k); return e } }); if (a.history && c.fn.history) { c.tools.history.init(h); a.event = "history" } h.each(function (f) { c(this).bind(a.event, function (g) { e.click(f, g); return g.preventDefault() }) }); i.find("a[href^=#]").bind("click.T", function (f) { e.click(c(this).attr("href"), f) }); if (location.hash && a.tabs == "a" && d.find("[href=" + location.hash + "]").length) e.click(location.hash);
        else if (a.initialIndex === 0 || a.initialIndex > 0) e.click(a.initialIndex)
    } c.tools = c.tools || { version: "1.2.5" }; c.tools.tabs = { conf: { tabs: "a", current: "current", onBeforeClick: null, onClick: null, effect: "default", initialIndex: 0, event: "click", rotate: false, history: false }, addEffect: function (d, b) { o[d] = b } }; var o = { "default": function (d, b) { this.getPanes().hide().eq(d).show(); b.call() }, fade: function (d, b) { var a = this.getConf(), e = a.fadeOutSpeed, l = this.getPanes(); e ? l.fadeOut(e) : l.hide(); l.eq(d).fadeIn(a.fadeInSpeed, b) }, slide: function (d,
b) { this.getPanes().slideUp(200); this.getPanes().eq(d).slideDown(400, b) }, ajax: function (d, b) { this.getPanes().eq(0).load(this.getTabs().eq(d).attr("href"), b) } 
    }, m; c.tools.tabs.addEffect("horizontal", function (d, b) { m || (m = this.getPanes().eq(0).width()); this.getCurrentPane().animate({ width: 0 }, function () { c(this).hide() }); this.getPanes().eq(d).animate({ width: m }, function () { c(this).show(); b.call() }) }); c.fn.tabs = function (d, b) {
        var a = this.data("tabs"); if (a) { a.destroy(); this.removeData("tabs") } if (c.isFunction(b)) b =
{ onBeforeClick: b }; b = c.extend({}, c.tools.tabs.conf, b); this.each(function () { a = new p(c(this), d, b); c(this).data("tabs", a) }); return b.api ? a : this
    } 
})(jQuery);
(function (c) {
    function p(g, a) {
        function m(f) { var e = c(f); return e.length < 2 ? e : g.parent().find(f) } var b = this, i = g.add(this), d = g.data("tabs"), h, j = true, n = m(a.next).click(function () { d.next() }), k = m(a.prev).click(function () { d.prev() }); c.extend(b, { getTabs: function () { return d }, getConf: function () { return a }, play: function () { if (h) return b; var f = c.Event("onBeforePlay"); i.trigger(f); if (f.isDefaultPrevented()) return b; h = setInterval(d.next, a.interval); j = false; i.trigger("onPlay"); return b }, pause: function () {
            if (!h) return b;
            var f = c.Event("onBeforePause"); i.trigger(f); if (f.isDefaultPrevented()) return b; h = clearInterval(h); i.trigger("onPause"); return b
        }, stop: function () { b.pause(); j = true } 
        }); c.each("onBeforePlay,onPlay,onBeforePause,onPause".split(","), function (f, e) { c.isFunction(a[e]) && c(b).bind(e, a[e]); b[e] = function (q) { return c(b).bind(e, q) } }); a.autopause && d.getTabs().add(n).add(k).add(d.getPanes()).hover(b.pause, function () { j || b.play() }); a.autoplay && b.play(); a.clickable && d.getPanes().click(function () { d.next() }); if (!d.getConf().rotate) {
            var l =
a.disabledClass; d.getIndex() || k.addClass(l); d.onBeforeClick(function (f, e) { k.toggleClass(l, !e); n.toggleClass(l, e == d.getTabs().length - 1) })
        } 
    } var o; o = c.tools.tabs.slideshow = { conf: { next: ".forward", prev: ".backward", disabledClass: "disabled", autoplay: false, autopause: true, interval: 3E3, clickable: true, api: false} }; c.fn.slideshow = function (g) { var a = this.data("slideshow"); if (a) return a; g = c.extend({}, o.conf, g); this.each(function () { a = new p(c(this), g); c(this).data("slideshow", a) }); return g.api ? a : this } 
})(jQuery);
(function (f) {
    function p(a, b, c) { var h = c.relative ? a.position().top : a.offset().top, d = c.relative ? a.position().left : a.offset().left, i = c.position[0]; h -= b.outerHeight() - c.offset[0]; d += a.outerWidth() + c.offset[1]; if (/iPad/i.test(navigator.userAgent)) h -= f(window).scrollTop(); var j = b.outerHeight() + a.outerHeight(); if (i == "center") h += j / 2; if (i == "bottom") h += j; i = c.position[1]; a = b.outerWidth() + a.outerWidth(); if (i == "center") d -= a / 2; if (i == "left") d -= a; return { top: h, left: d} } function u(a, b) {
        var c = this, h = a.add(c), d, i = 0, j =
0, m = a.attr("title"), q = a.attr("data-tooltip"), r = o[b.effect], l, s = a.is(":input"), v = s && a.is(":checkbox, :radio, select, :button, :submit"), t = a.attr("type"), k = b.events[t] || b.events[s ? v ? "widget" : "input" : "def"]; if (!r) throw 'Nonexistent effect "' + b.effect + '"'; k = k.split(/,\s*/); if (k.length != 2) throw "Tooltip: bad events configuration for " + t; a.bind(k[0], function (e) { clearTimeout(i); if (b.predelay) j = setTimeout(function () { c.show(e) }, b.predelay); else c.show(e) }).bind(k[1], function (e) {
    clearTimeout(j); if (b.delay) i =
setTimeout(function () { c.hide(e) }, b.delay); else c.hide(e)
}); if (m && b.cancelDefault) { a.removeAttr("title"); a.data("title", m) } f.extend(c, { show: function (e) {
    if (!d) { if (q) d = f(q); else if (b.tip) d = f(b.tip).eq(0); else if (m) d = f(b.layout).addClass(b.tipClass).appendTo(document.body).hide().append(m); else { d = a.next(); d.length || (d = a.parent().next()) } if (!d.length) throw "Cannot find tooltip for " + a; } if (c.isShown()) return c; d.stop(true, true); var g = p(a, d, b); b.tip && d.html(a.data("title")); e = e || f.Event(); e.type = "onBeforeShow";
    h.trigger(e, [g]); if (e.isDefaultPrevented()) return c; g = p(a, d, b); d.css({ position: "absolute", top: g.top, left: g.left }); l = true; r[0].call(c, function () { e.type = "onShow"; l = "full"; h.trigger(e) }); g = b.events.tooltip.split(/,\s*/); if (!d.data("__set")) { d.bind(g[0], function () { clearTimeout(i); clearTimeout(j) }); g[1] && !a.is("input:not(:checkbox, :radio), textarea") && d.bind(g[1], function (n) { n.relatedTarget != a[0] && a.trigger(k[1].split(" ")[0]) }); d.data("__set", true) } return c
}, hide: function (e) {
    if (!d || !c.isShown()) return c;
    e = e || f.Event(); e.type = "onBeforeHide"; h.trigger(e); if (!e.isDefaultPrevented()) { l = false; o[b.effect][1].call(c, function () { e.type = "onHide"; h.trigger(e) }); return c } 
}, isShown: function (e) { return e ? l == "full" : l }, getConf: function () { return b }, getTip: function () { return d }, getTrigger: function () { return a } 
}); f.each("onHide,onBeforeShow,onShow,onBeforeHide".split(","), function (e, g) { f.isFunction(b[g]) && f(c).bind(g, b[g]); c[g] = function (n) { n && f(c).bind(g, n); return c } })
    } f.tools = f.tools || { version: "1.2.5" }; f.tools.tooltip =
{ conf: { effect: "toggle", fadeOutSpeed: "fast", predelay: 0, delay: 30, opacity: 1, tip: 0, position: ["top", "center"], offset: [0, 0], relative: false, cancelDefault: true, events: { def: "mouseenter,mouseleave", input: "focus,blur", widget: "focus mouseenter,blur mouseleave", tooltip: "mouseenter,mouseleave" }, layout: "<div/>", tipClass: "tooltip" }, addEffect: function (a, b, c) { o[a] = [b, c] } }; var o = { toggle: [function (a) { var b = this.getConf(), c = this.getTip(); b = b.opacity; b < 1 && c.css({ opacity: b }); c.show(); a.call() }, function (a) {
    this.getTip().hide();
    a.call()
} ], fade: [function (a) { var b = this.getConf(); this.getTip().fadeTo(b.fadeInSpeed, b.opacity, a) }, function (a) { this.getTip().fadeOut(this.getConf().fadeOutSpeed, a) } ]
}; f.fn.tooltip = function (a) { var b = this.data("tooltip"); if (b) return b; a = f.extend(true, {}, f.tools.tooltip.conf, a); if (typeof a.position == "string") a.position = a.position.split(/,?\s/); this.each(function () { b = new u(f(this), a); f(this).data("tooltip", b) }); return a.api ? b : this } 
})(jQuery);
(function (d) {
    var i = d.tools.tooltip; d.extend(i.conf, { direction: "up", bounce: false, slideOffset: 10, slideInSpeed: 200, slideOutSpeed: 200, slideFade: !d.browser.msie }); var e = { up: ["-", "top"], down: ["+", "top"], left: ["-", "left"], right: ["+", "left"] }; i.addEffect("slide", function (g) { var a = this.getConf(), f = this.getTip(), b = a.slideFade ? { opacity: a.opacity} : {}, c = e[a.direction] || e.up; b[c[1]] = c[0] + "=" + a.slideOffset; a.slideFade && f.css({ opacity: 0 }); f.show().animate(b, a.slideInSpeed, g) }, function (g) {
        var a = this.getConf(), f = a.slideOffset,
b = a.slideFade ? { opacity: 0} : {}, c = e[a.direction] || e.up, h = "" + c[0]; if (a.bounce) h = h == "+" ? "-" : "+"; b[c[1]] = h + "=" + f; this.getTip().animate(b, a.slideOutSpeed, function () { d(this).hide(); g.call() })
    })
})(jQuery);
(function (g) {
    function j(a) { var c = g(window), d = c.width() + c.scrollLeft(), h = c.height() + c.scrollTop(); return [a.offset().top <= c.scrollTop(), d <= a.offset().left + a.width(), h <= a.offset().top + a.height(), c.scrollLeft() >= a.offset().left] } function k(a) { for (var c = a.length; c--; ) if (a[c]) return false; return true } var i = g.tools.tooltip; i.dynamic = { conf: { classNames: "top right bottom left"} }; g.fn.dynamic = function (a) {
        if (typeof a == "number") a = { speed: a }; a = g.extend({}, i.dynamic.conf, a); var c = a.classNames.split(/\s/), d; this.each(function () {
            var h =
g(this).tooltip().onBeforeShow(function (e, f) {
    e = this.getTip(); var b = this.getConf(); d || (d = [b.position[0], b.position[1], b.offset[0], b.offset[1], g.extend({}, b)]); g.extend(b, d[4]); b.position = [d[0], d[1]]; b.offset = [d[2], d[3]]; e.css({ visibility: "hidden", position: "absolute", top: f.top, left: f.left }).show(); f = j(e); if (!k(f)) {
        if (f[2]) { g.extend(b, a.top); b.position[0] = "top"; e.addClass(c[0]) } if (f[3]) { g.extend(b, a.right); b.position[1] = "right"; e.addClass(c[1]) } if (f[0]) { g.extend(b, a.bottom); b.position[0] = "bottom"; e.addClass(c[2]) } if (f[1]) {
            g.extend(b,
a.left); b.position[1] = "left"; e.addClass(c[3])
        } if (f[0] || f[2]) b.offset[0] *= -1; if (f[1] || f[3]) b.offset[1] *= -1
    } e.css({ visibility: "visible" }).hide()
}); h.onBeforeShow(function () { var e = this.getConf(); this.getTip(); setTimeout(function () { e.position = [d[0], d[1]]; e.offset = [d[2], d[3]] }, 0) }); h.onHide(function () { var e = this.getTip(); e.removeClass(a.classNames) }); ret = h
        }); return a.api ? ret : this
    } 
})(jQuery);
(function (e) {
    function p(f, c) { var b = e(c); return b.length < 2 ? b : f.parent().find(c) } function u(f, c) {
        var b = this, n = f.add(b), g = f.children(), l = 0, j = c.vertical; k || (k = b); if (g.length > 1) g = e(c.items, f); e.extend(b, { getConf: function () { return c }, getIndex: function () { return l }, getSize: function () { return b.getItems().size() }, getNaviButtons: function () { return o.add(q) }, getRoot: function () { return f }, getItemWrap: function () { return g }, getItems: function () { return g.children(c.item).not("." + c.clonedClass) }, move: function (a, d) {
            return b.seekTo(l +
a, d)
        }, next: function (a) { return b.move(1, a) }, prev: function (a) { return b.move(-1, a) }, begin: function (a) { return b.seekTo(0, a) }, end: function (a) { return b.seekTo(b.getSize() - 1, a) }, focus: function () { return k = b }, addItem: function (a) { a = e(a); if (c.circular) { g.children("." + c.clonedClass + ":last").before(a); g.children("." + c.clonedClass + ":first").replaceWith(a.clone().addClass(c.clonedClass)) } else g.append(a); n.trigger("onAddItem", [a]); return b }, seekTo: function (a, d, h) {
            a.jquery || (a *= 1); if (c.circular && a === 0 && l == -1 && d !==
0) return b; if (!c.circular && a < 0 || a > b.getSize() || a < -1) return b; var i = a; if (a.jquery) a = b.getItems().index(a); else i = b.getItems().eq(a); var r = e.Event("onBeforeSeek"); if (!h) { n.trigger(r, [a, d]); if (r.isDefaultPrevented() || !i.length) return b } i = j ? { top: -i.position().top} : { left: -i.position().left }; l = a; k = b; if (d === undefined) d = c.speed; g.animate(i, d, c.easing, h || function () { n.trigger("onSeek", [a]) }); return b
        } 
        }); e.each(["onBeforeSeek", "onSeek", "onAddItem"], function (a, d) {
            e.isFunction(c[d]) && e(b).bind(d, c[d]); b[d] = function (h) {
                h &&
e(b).bind(d, h); return b
            } 
        }); if (c.circular) { var s = b.getItems().slice(-1).clone().prependTo(g), t = b.getItems().eq(1).clone().appendTo(g); s.add(t).addClass(c.clonedClass); b.onBeforeSeek(function (a, d, h) { if (!a.isDefaultPrevented()) if (d == -1) { b.seekTo(s, h, function () { b.end(0) }); return a.preventDefault() } else d == b.getSize() && b.seekTo(t, h, function () { b.begin(0) }) }); b.seekTo(0, 0, function () { }) } var o = p(f, c.prev).click(function () { b.prev() }), q = p(f, c.next).click(function () { b.next() }); if (!c.circular && b.getSize() > 1) {
            b.onBeforeSeek(function (a,
d) { setTimeout(function () { if (!a.isDefaultPrevented()) { o.toggleClass(c.disabledClass, d <= 0); q.toggleClass(c.disabledClass, d >= b.getSize() - 1) } }, 1) }); c.initialIndex || o.addClass(c.disabledClass)
        } c.mousewheel && e.fn.mousewheel && f.mousewheel(function (a, d) { if (c.mousewheel) { b.move(d < 0 ? 1 : -1, c.wheelSpeed || 50); return false } }); if (c.touch) {
            var m = {}; g[0].ontouchstart = function (a) { a = a.touches[0]; m.x = a.clientX; m.y = a.clientY }; g[0].ontouchmove = function (a) {
                if (a.touches.length == 1 && !g.is(":animated")) {
                    var d = a.touches[0], h =
m.x - d.clientX; d = m.y - d.clientY; b[j && d > 0 || !j && h > 0 ? "next" : "prev"](); a.preventDefault()
                } 
            } 
        } c.keyboard && e(document).bind("keydown.scrollable", function (a) { if (!(!c.keyboard || a.altKey || a.ctrlKey || e(a.target).is(":input"))) if (!(c.keyboard != "static" && k != b)) { var d = a.keyCode; if (j && (d == 38 || d == 40)) { b.move(d == 38 ? -1 : 1); return a.preventDefault() } if (!j && (d == 37 || d == 39)) { b.move(d == 37 ? -1 : 1); return a.preventDefault() } } }); c.initialIndex && b.seekTo(c.initialIndex, 0, function () { })
    } e.tools = e.tools || { version: "1.2.5" }; e.tools.scrollable =
{ conf: { activeClass: "active", circular: false, clonedClass: "cloned", disabledClass: "disabled", easing: "swing", initialIndex: 0, item: null, items: ".items", keyboard: true, mousewheel: false, next: ".next", prev: ".prev", speed: 400, vertical: false, touch: true, wheelSpeed: 0} }; var k; e.fn.scrollable = function (f) { var c = this.data("scrollable"); if (c) return c; f = e.extend({}, e.tools.scrollable.conf, f); this.each(function () { c = new u(e(this), f); e(this).data("scrollable", c) }); return f.api ? c : this } 
})(jQuery);
(function (b) {
    var f = b.tools.scrollable; f.autoscroll = { conf: { autoplay: true, interval: 3E3, autopause: true} }; b.fn.autoscroll = function (c) {
        if (typeof c == "number") c = { interval: c }; var d = b.extend({}, f.autoscroll.conf, c), g; this.each(function () {
            var a = b(this).data("scrollable"); if (a) g = a; var e, h = true; a.play = function () { if (!e) { h = false; e = setInterval(function () { a.next() }, d.interval) } }; a.pause = function () { e = clearInterval(e) }; a.stop = function () { a.pause(); h = true }; d.autopause && a.getRoot().add(a.getNaviButtons()).hover(a.pause,
a.play); d.autoplay && a.play()
        }); return d.api ? g : this
    } 
})(jQuery);
(function (d) {
    function p(b, g) { var h = d(g); return h.length < 2 ? h : b.parent().find(g) } var m = d.tools.scrollable; m.navigator = { conf: { navi: ".navi", naviItem: null, activeClass: "active", indexed: false, idPrefix: null, history: false} }; d.fn.navigator = function (b) {
        if (typeof b == "string") b = { navi: b }; b = d.extend({}, m.navigator.conf, b); var g; this.each(function () {
            function h(a, c, i) { e.seekTo(c); if (j) { if (location.hash) location.hash = a.attr("href").replace("#", "") } else return i.preventDefault() } function f() {
                return k.find(b.naviItem ||
"> *")
            } function n(a) { var c = d("<" + (b.naviItem || "a") + "/>").click(function (i) { h(d(this), a, i) }).attr("href", "#" + a); a === 0 && c.addClass(l); b.indexed && c.text(a + 1); b.idPrefix && c.attr("id", b.idPrefix + a); return c.appendTo(k) } function o(a, c) { a = f().eq(c.replace("#", "")); a.length || (a = f().filter("[href=" + c + "]")); a.click() } var e = d(this).data("scrollable"), k = b.navi.jquery ? b.navi : p(e.getRoot(), b.navi), q = e.getNaviButtons(), l = b.activeClass, j = b.history && d.fn.history; if (e) g = e; e.getNaviButtons = function () { return q.add(k) };
            f().length ? f().each(function (a) { d(this).click(function (c) { h(d(this), a, c) }) }) : d.each(e.getItems(), function (a) { n(a) }); e.onBeforeSeek(function (a, c) { setTimeout(function () { if (!a.isDefaultPrevented()) { var i = f().eq(c); !a.isDefaultPrevented() && i.length && f().removeClass(l).eq(c).addClass(l) } }, 1) }); e.onAddItem(function (a, c) { c = n(e.getItems().index(c)); j && c.history(o) }); j && f().history(o)
        }); return b.api ? g : this
    } 
})(jQuery);
(function (a) {
    function t(d, b) {
        var c = this, j = d.add(c), o = a(window), k, f, m, g = a.tools.expose && (b.mask || b.expose), n = Math.random().toString().slice(10); if (g) { if (typeof g == "string") g = { color: g }; g.closeOnClick = g.closeOnEsc = false } var p = b.target || d.attr("rel"); f = p ? a(p) : d; if (!f.length) throw "Could not find Overlay: " + p; d && d.index(f) == -1 && d.click(function (e) { c.load(e); return e.preventDefault() }); a.extend(c, { load: function (e) {
            if (c.isOpened()) return c; var h = q[b.effect]; if (!h) throw 'Overlay: cannot find effect : "' + b.effect +
'"'; b.oneInstance && a.each(s, function () { this.close(e) }); e = e || a.Event(); e.type = "onBeforeLoad"; j.trigger(e); if (e.isDefaultPrevented()) return c; m = true; g && a(f).expose(g); var i = b.top, r = b.left, u = f.outerWidth({ margin: true }), v = f.outerHeight({ margin: true }); if (typeof i == "string") i = i == "center" ? Math.max((o.height() - v) / 2, 0) : parseInt(i, 10) / 100 * o.height(); if (r == "center") r = Math.max((o.width() - u) / 2, 0); h[0].call(c, { top: i, left: r }, function () { if (m) { e.type = "onLoad"; j.trigger(e) } }); g && b.closeOnClick && a.mask.getMask().one("click",
c.close); b.closeOnClick && a(document).bind("click." + n, function (l) { a(l.target).parents(f).length || c.close(l) }); b.closeOnEsc && a(document).bind("keydown." + n, function (l) { l.keyCode == 27 && c.close(l) }); return c
        }, close: function (e) { if (!c.isOpened()) return c; e = e || a.Event(); e.type = "onBeforeClose"; j.trigger(e); if (!e.isDefaultPrevented()) { m = false; q[b.effect][1].call(c, function () { e.type = "onClose"; j.trigger(e) }); a(document).unbind("click." + n).unbind("keydown." + n); g && a.mask.close(); return c } }, getOverlay: function () { return f },
            getTrigger: function () { return d }, getClosers: function () { return k }, isOpened: function () { return m }, getConf: function () { return b } 
        }); a.each("onBeforeLoad,onStart,onLoad,onBeforeClose,onClose".split(","), function (e, h) { a.isFunction(b[h]) && a(c).bind(h, b[h]); c[h] = function (i) { i && a(c).bind(h, i); return c } }); k = f.find(b.close || ".close"); if (!k.length && !b.close) { k = a('<a class="close"></a>'); f.prepend(k) } k.click(function (e) { c.close(e) }); b.load && c.load()
    } a.tools = a.tools || { version: "1.2.5" }; a.tools.overlay = { addEffect: function (d,
b, c) { q[d] = [b, c] }, conf: { close: null, closeOnClick: true, closeOnEsc: true, closeSpeed: "fast", effect: "default", fixed: !a.browser.msie || a.browser.version > 6, left: "center", load: false, mask: null, oneInstance: true, speed: "normal", target: null, top: "10%"}
    }; var s = [], q = {}; a.tools.overlay.addEffect("default", function (d, b) { var c = this.getConf(), j = a(window); if (!c.fixed) { d.top += j.scrollTop(); d.left += j.scrollLeft() } d.position = c.fixed ? "fixed" : "absolute"; this.getOverlay().css(d).fadeIn(c.speed, b) }, function (d) {
        this.getOverlay().fadeOut(this.getConf().closeSpeed,
d)
    }); a.fn.overlay = function (d) { var b = this.data("overlay"); if (b) return b; if (a.isFunction(d)) d = { onBeforeLoad: d }; d = a.extend(true, {}, a.tools.overlay.conf, d); this.each(function () { b = new t(a(this), d); s.push(b); a(this).data("overlay", b) }); return d.api ? b : this } 
})(jQuery);
(function (h) {
    function k(d) { var e = d.offset(); return { top: e.top + d.height() / 2, left: e.left + d.width() / 2} } var l = h.tools.overlay, f = h(window); h.extend(l.conf, { start: { top: null, left: null }, fadeInSpeed: "fast", zIndex: 9999 }); function o(d, e) {
        var a = this.getOverlay(), c = this.getConf(), g = this.getTrigger(), p = this, m = a.outerWidth({ margin: true }), b = a.data("img"), n = c.fixed ? "fixed" : "absolute"; if (!b) {
            b = a.css("backgroundImage"); if (!b) throw "background-image CSS property not set for overlay"; b = b.slice(b.indexOf("(") + 1, b.indexOf(")")).replace(/\"/g,
""); a.css("backgroundImage", "none"); b = h('<img src="' + b + '"/>'); b.css({ border: 0, display: "none" }).width(m); h("body").append(b); a.data("img", b)
        } var i = c.start.top || Math.round(f.height() / 2), j = c.start.left || Math.round(f.width() / 2); if (g) { g = k(g); i = g.top; j = g.left } if (c.fixed) { i -= f.scrollTop(); j -= f.scrollLeft() } else { d.top += f.scrollTop(); d.left += f.scrollLeft() } b.css({ position: "absolute", top: i, left: j, width: 0, zIndex: c.zIndex }).show(); d.position = n; a.css(d); b.animate({ top: a.css("top"), left: a.css("left"), width: m },
c.speed, function () { a.css("zIndex", c.zIndex + 1).fadeIn(c.fadeInSpeed, function () { p.isOpened() && !h(this).index(a) ? e.call() : a.hide() }) }).css("position", n)
    } function q(d) { var e = this.getOverlay().hide(), a = this.getConf(), c = this.getTrigger(); e = e.data("img"); var g = { top: a.start.top, left: a.start.left, width: 0 }; c && h.extend(g, k(c)); a.fixed && e.css({ position: "absolute" }).animate({ top: "+=" + f.scrollTop(), left: "+=" + f.scrollLeft() }, 0); e.animate(g, a.closeSpeed, d) } l.addEffect("apple", o, q)
})(jQuery);
(function (d) {
    function R(a, c) { return 32 - (new Date(a, c, 32)).getDate() } function S(a, c) { a = "" + a; for (c = c || 2; a.length < c; ) a = "0" + a; return a } function T(a, c, j) { var q = a.getDate(), h = a.getDay(), r = a.getMonth(); a = a.getFullYear(); var f = { d: q, dd: S(q), ddd: B[j].shortDays[h], dddd: B[j].days[h], m: r + 1, mm: S(r + 1), mmm: B[j].shortMonths[r], mmmm: B[j].months[r], yy: String(a).slice(2), yyyy: a }; c = c.replace(X, function (s) { return s in f ? f[s] : s.slice(1, s.length - 1) }); return Y.html(c).html() } function v(a) { return parseInt(a, 10) } function U(a,
c) { return a.getFullYear() === c.getFullYear() && a.getMonth() == c.getMonth() && a.getDate() == c.getDate() } function C(a) { if (a) { if (a.constructor == Date) return a; if (typeof a == "string") { var c = a.split("-"); if (c.length == 3) return new Date(v(c[0]), v(c[1]) - 1, v(c[2])); if (!/^-?\d+$/.test(a)) return; a = v(a) } c = new Date; c.setDate(c.getDate() + a); return c } } function Z(a, c) {
    function j(b, e, g) {
        n = b; D = b.getFullYear(); E = b.getMonth(); G = b.getDate(); g = g || d.Event("api"); g.type = "change"; H.trigger(g, [b]); if (!g.isDefaultPrevented()) {
            a.val(T(b,
e.format, e.lang)); a.data("date", b); h.hide(g)
        } 
    } function q(b) {
        b.type = "onShow"; H.trigger(b); d(document).bind("keydown.d", function (e) {
            if (e.ctrlKey) return true; var g = e.keyCode; if (g == 8) { a.val(""); return h.hide(e) } if (g == 27) return h.hide(e); if (d(V).index(g) >= 0) {
                if (!w) { h.show(e); return e.preventDefault() } var i = d("#" + f.weeks + " a"), t = d("." + f.focus), o = i.index(t); t.removeClass(f.focus); if (g == 74 || g == 40) o += 7; else if (g == 75 || g == 38) o -= 7; else if (g == 76 || g == 39) o += 1; else if (g == 72 || g == 37) o -= 1; if (o > 41) {
                    h.addMonth(); t = d("#" +
f.weeks + " a:eq(" + (o - 42) + ")")
                } else if (o < 0) { h.addMonth(-1); t = d("#" + f.weeks + " a:eq(" + (o + 42) + ")") } else t = i.eq(o); t.addClass(f.focus); return e.preventDefault()
            } if (g == 34) return h.addMonth(); if (g == 33) return h.addMonth(-1); if (g == 36) return h.today(); if (g == 13) d(e.target).is("select") || d("." + f.focus).click(); return d([16, 17, 18, 9]).index(g) >= 0
        }); d(document).bind("click.d", function (e) { var g = e.target; if (!d(g).parents("#" + f.root).length && g != a[0] && (!L || g != L[0])) h.hide(e) })
    } var h = this, r = new Date, f = c.css, s = B[c.lang],
k = d("#" + f.root), M = k.find("#" + f.title), L, I, J, D, E, G, n = a.attr("data-value") || c.value || a.val(), m = a.attr("min") || c.min, p = a.attr("max") || c.max, w; if (m === 0) m = "0"; n = C(n) || r; m = C(m || c.yearRange[0] * 365); p = C(p || c.yearRange[1] * 365); if (!s) throw "Dateinput: invalid language: " + c.lang; if (a.attr("type") == "date") { var N = d("<input/>"); d.each("class,disabled,id,maxlength,name,readonly,required,size,style,tabindex,title,value".split(","), function (b, e) { N.attr(e, a.attr(e)) }); a.replaceWith(N); a = N } a.addClass(f.input); var H =
a.add(h); if (!k.length) {
        k = d("<div><div><a/><div/><a/></div><div><div/><div/></div></div>").hide().css({ position: "absolute" }).attr("id", f.root); k.children().eq(0).attr("id", f.head).end().eq(1).attr("id", f.body).children().eq(0).attr("id", f.days).end().eq(1).attr("id", f.weeks).end().end().end().find("a").eq(0).attr("id", f.prev).end().eq(1).attr("id", f.next); M = k.find("#" + f.head).find("div").attr("id", f.title); if (c.selectors) { var z = d("<select/>").attr("id", f.month), A = d("<select/>").attr("id", f.year); M.html(z.add(A)) } for (var $ =
k.find("#" + f.days), O = 0; O < 7; O++) $.append(d("<span/>").text(s.shortDays[(O + c.firstDay) % 7])); d("body").append(k)
    } if (c.trigger) L = d("<a/>").attr("href", "#").addClass(f.trigger).click(function (b) { h.show(); return b.preventDefault() }).insertAfter(a); var K = k.find("#" + f.weeks); A = k.find("#" + f.year); z = k.find("#" + f.month); d.extend(h, { show: function (b) {
        if (!(a.attr("readonly") || a.attr("disabled") || w)) {
            b = b || d.Event(); b.type = "onBeforeShow"; H.trigger(b); if (!b.isDefaultPrevented()) {
                d.each(W, function () { this.hide() });
                w = true; z.unbind("change").change(function () { h.setValue(A.val(), d(this).val()) }); A.unbind("change").change(function () { h.setValue(d(this).val(), z.val()) }); I = k.find("#" + f.prev).unbind("click").click(function () { I.hasClass(f.disabled) || h.addMonth(-1); return false }); J = k.find("#" + f.next).unbind("click").click(function () { J.hasClass(f.disabled) || h.addMonth(); return false }); h.setValue(n); var e = a.offset(); if (/iPad/i.test(navigator.userAgent)) e.top -= d(window).scrollTop(); k.css({ top: e.top + a.outerHeight({ margins: true }) +
c.offset[0], left: e.left + c.offset[1]
                }); if (c.speed) k.show(c.speed, function () { q(b) }); else { k.show(); q(b) } return h
            } 
        } 
    }, setValue: function (b, e, g) {
        var i = v(e) >= -1 ? new Date(v(b), v(e), v(g || 1)) : b || n; if (i < m) i = m; else if (i > p) i = p; b = i.getFullYear(); e = i.getMonth(); g = i.getDate(); if (e == -1) { e = 11; b-- } else if (e == 12) { e = 0; b++ } if (!w) { j(i, c); return h } E = e; D = b; g = new Date(b, e, 1 - c.firstDay); g = g.getDay(); var t = R(b, e), o = R(b, e - 1), P; if (c.selectors) {
            z.empty(); d.each(s.months, function (x, F) {
                m < new Date(b, x + 1, -1) && p > new Date(b, x, 0) && z.append(d("<option/>").html(F).attr("value",
x))
            }); A.empty(); i = r.getFullYear(); for (var l = i + c.yearRange[0]; l < i + c.yearRange[1]; l++) m <= new Date(l + 1, -1, 1) && p > new Date(l, 0, 0) && A.append(d("<option/>").text(l)); z.val(e); A.val(b)
        } else M.html(s.months[e] + " " + b); K.empty(); I.add(J).removeClass(f.disabled); l = !g ? -7 : 0; for (var u, y; l < (!g ? 35 : 42); l++) {
            u = d("<a/>"); if (l % 7 === 0) { P = d("<div/>").addClass(f.week); K.append(P) } if (l < g) { u.addClass(f.off); y = o - g + l + 1; i = new Date(b, e - 1, y) } else if (l >= g + t) { u.addClass(f.off); y = l - t - g + 1; i = new Date(b, e + 1, y) } else {
                y = l - g + 1; i = new Date(b,
e, y); if (U(n, i)) u.attr("id", f.current).addClass(f.focus); else U(r, i) && u.attr("id", f.today)
            } m && i < m && u.add(I).addClass(f.disabled); p && i > p && u.add(J).addClass(f.disabled); u.attr("href", "#" + y).text(y).data("date", i); P.append(u)
        } K.find("a").click(function (x) { var F = d(this); if (!F.hasClass(f.disabled)) { d("#" + f.current).removeAttr("id"); F.attr("id", f.current); j(F.data("date"), c, x) } return false }); f.sunday && K.find(f.week).each(function () { var x = c.firstDay ? 7 - c.firstDay : 0; d(this).children().slice(x, x + 1).addClass(f.sunday) });
        return h
    }, setMin: function (b, e) { m = C(b); e && n < m && h.setValue(m); return h }, setMax: function (b, e) { p = C(b); e && n > p && h.setValue(p); return h }, today: function () { return h.setValue(r) }, addDay: function (b) { return this.setValue(D, E, G + (b || 1)) }, addMonth: function (b) { return this.setValue(D, E + (b || 1), G) }, addYear: function (b) { return this.setValue(D + (b || 1), E, G) }, hide: function (b) { if (w) { b = d.Event(); b.type = "onHide"; H.trigger(b); d(document).unbind("click.d").unbind("keydown.d"); if (b.isDefaultPrevented()) return; k.hide(); w = false } return h },
        getConf: function () { return c }, getInput: function () { return a }, getCalendar: function () { return k }, getValue: function (b) { return b ? T(n, b, c.lang) : n }, isOpen: function () { return w } 
    }); d.each(["onBeforeShow", "onShow", "change", "onHide"], function (b, e) { d.isFunction(c[e]) && d(h).bind(e, c[e]); h[e] = function (g) { g && d(h).bind(e, g); return h } }); a.bind("focus click", h.show).keydown(function (b) { var e = b.keyCode; if (!w && d(V).index(e) >= 0) { h.show(b); return b.preventDefault() } return b.shiftKey || b.ctrlKey || b.altKey || e == 9 ? true : b.preventDefault() });
    C(a.val()) && j(n, c)
} d.tools = d.tools || { version: "1.2.5" }; var W = [], Q, V = [75, 76, 38, 39, 74, 72, 40, 37], B = {}; Q = d.tools.dateinput = { conf: { format: "mm/dd/yy", selectors: false, yearRange: [-5, 5], lang: "en", offset: [0, 0], speed: 0, firstDay: 0, min: undefined, max: undefined, trigger: false, css: { prefix: "cal", input: "date", root: 0, head: 0, title: 0, prev: 0, next: 0, month: 0, year: 0, days: 0, body: 0, weeks: 0, today: 0, current: 0, week: 0, off: 0, sunday: 0, focus: 0, disabled: 0, trigger: 0} }, localize: function (a, c) {
    d.each(c, function (j, q) { c[j] = q.split(",") });
    B[a] = c
} 
}; Q.localize("en", { months: "January,February,March,April,May,June,July,August,September,October,November,December", shortMonths: "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", days: "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday", shortDays: "Sun,Mon,Tue,Wed,Thu,Fri,Sat" }); var X = /d{1,4}|m{1,4}|yy(?:yy)?|"[^"]*"|'[^']*'/g, Y = d("<a/>"); d.expr[":"].date = function (a) { var c = a.getAttribute("type"); return c && c == "date" || !!d(a).data("dateinput") }; d.fn.dateinput = function (a) {
    if (this.data("dateinput")) return this;
    a = d.extend(true, {}, Q.conf, a); d.each(a.css, function (j, q) { if (!q && j != "prefix") a.css[j] = (a.css.prefix || "") + (q || j) }); var c; this.each(function () { var j = new Z(d(this), a); W.push(j); j = j.getInput().data("dateinput", j); c = c ? c.add(j) : j }); return c ? c : this
} 
})(jQuery);
(function (e) {
    function F(d, a) { a = Math.pow(10, a); return Math.round(d * a) / a } function q(d, a) { if (a = parseInt(d.css(a), 10)) return a; return (d = d[0].currentStyle) && d.width && parseInt(d.width, 10) } function C(d) { return (d = d.data("events")) && d.onSlide } function G(d, a) {
        function h(c, b, f, j) {
            if (f === undefined) f = b / k * z; else if (j) f -= a.min; if (s) f = Math.round(f / s) * s; if (b === undefined || s) b = f * k / z; if (isNaN(f)) return g; b = Math.max(0, Math.min(b, k)); f = b / k * z; if (j || !n) f += a.min; if (n) if (j) b = k - b; else f = a.max - f; f = F(f, t); var r = c.type == "click";
            if (D && l !== undefined && !r) { c.type = "onSlide"; A.trigger(c, [f, b]); if (c.isDefaultPrevented()) return g } j = r ? a.speed : 0; r = r ? function () { c.type = "change"; A.trigger(c, [f]) } : null; if (n) { m.animate({ top: b }, j, r); a.progress && B.animate({ height: k - b + m.width() / 2 }, j) } else { m.animate({ left: b }, j, r); a.progress && B.animate({ width: b + m.width() / 2 }, j) } l = f; H = b; d.val(f); return g
        } function o() { if (n = a.vertical || q(i, "height") > q(i, "width")) { k = q(i, "height") - q(m, "height"); u = i.offset().top + k } else { k = q(i, "width") - q(m, "width"); u = i.offset().left } }
        function v() { o(); g.setValue(a.value !== undefined ? a.value : a.min) } var g = this, p = a.css, i = e("<div><div/><a href='#'/></div>").data("rangeinput", g), n, l, u, k, H; d.before(i); var m = i.addClass(p.slider).find("a").addClass(p.handle), B = i.find("div").addClass(p.progress); e.each("min,max,step,value".split(","), function (c, b) { c = d.attr(b); if (parseFloat(c)) a[b] = parseFloat(c, 10) }); var z = a.max - a.min, s = a.step == "any" ? 0 : a.step, t = a.precision; if (t === undefined) try { t = s.toString().split(".")[1].length } catch (I) { t = 0 } if (d.attr("type") ==
"range") { var w = e("<input/>"); e.each("class,disabled,id,maxlength,name,readonly,required,size,style,tabindex,title,value".split(","), function (c, b) { w.attr(b, d.attr(b)) }); w.val(a.value); d.replaceWith(w); d = w } d.addClass(p.input); var A = e(g).add(d), D = true; e.extend(g, { getValue: function () { return l }, setValue: function (c, b) { o(); return h(b || e.Event("api"), undefined, c, true) }, getConf: function () { return a }, getProgress: function () { return B }, getHandle: function () { return m }, getInput: function () { return d }, step: function (c,
b) { b = b || e.Event(); var f = a.step == "any" ? 1 : a.step; g.setValue(l + f * (c || 1), b) }, stepUp: function (c) { return g.step(c || 1) }, stepDown: function (c) { return g.step(-c || -1) } 
}); e.each("onSlide,change".split(","), function (c, b) { e.isFunction(a[b]) && e(g).bind(b, a[b]); g[b] = function (f) { f && e(g).bind(b, f); return g } }); m.drag({ drag: false }).bind("dragStart", function () { o(); D = C(e(g)) || C(d) }).bind("drag", function (c, b, f) { if (d.is(":disabled")) return false; h(c, n ? b : f) }).bind("dragEnd", function (c) {
    if (!c.isDefaultPrevented()) {
        c.type =
"change"; A.trigger(c, [l])
    } 
}).click(function (c) { return c.preventDefault() }); i.click(function (c) { if (d.is(":disabled") || c.target == m[0]) return c.preventDefault(); o(); var b = m.width() / 2; h(c, n ? k - u - b + c.pageY : c.pageX - u - b) }); a.keyboard && d.keydown(function (c) { if (!d.attr("readonly")) { var b = c.keyCode, f = e([75, 76, 38, 33, 39]).index(b) != -1, j = e([74, 72, 40, 34, 37]).index(b) != -1; if ((f || j) && !(c.shiftKey || c.altKey || c.ctrlKey)) { if (f) g.step(b == 33 ? 10 : 1, c); else if (j) g.step(b == 34 ? -10 : -1, c); return c.preventDefault() } } }); d.blur(function (c) {
    var b =
e(this).val(); b !== l && g.setValue(b, c)
}); e.extend(d[0], { stepUp: g.stepUp, stepDown: g.stepDown }); v(); k || e(window).load(v)
    } e.tools = e.tools || { version: "1.2.5" }; var E; E = e.tools.rangeinput = { conf: { min: 0, max: 100, step: "any", steps: 0, value: 0, precision: undefined, vertical: 0, keyboard: true, progress: false, speed: 100, css: { input: "range", slider: "slider", progress: "progress", handle: "handle"}} }; var x, y; e.fn.drag = function (d) {
        document.ondragstart = function () { return false }; d = e.extend({ x: true, y: true, drag: true }, d); x = x || e(document).bind("mousedown mouseup",
function (a) { var h = e(a.target); if (a.type == "mousedown" && h.data("drag")) { var o = h.position(), v = a.pageX - o.left, g = a.pageY - o.top, p = true; x.bind("mousemove.drag", function (i) { var n = i.pageX - v; i = i.pageY - g; var l = {}; if (d.x) l.left = n; if (d.y) l.top = i; if (p) { h.trigger("dragStart"); p = false } d.drag && h.css(l); h.trigger("drag", [i, n]); y = h }); a.preventDefault() } else try { y && y.trigger("dragEnd") } finally { x.unbind("mousemove.drag"); y = null } }); return this.data("drag", true)
    }; e.expr[":"].range = function (d) {
        var a = d.getAttribute("type");
        return a && a == "range" || !!e(d).filter("input").data("rangeinput")
    }; e.fn.rangeinput = function (d) { if (this.data("rangeinput")) return this; d = e.extend(true, {}, E.conf, d); var a; this.each(function () { var h = new G(e(this), e.extend(true, {}, d)); h = h.getInput().data("rangeinput", h); a = a ? a.add(h) : h }); return a ? a : this } 
})(jQuery);
(function (e) {
    function t(a, b, c) { var k = a.offset().top, f = a.offset().left, l = c.position.split(/,?\s+/), p = l[0]; l = l[1]; k -= b.outerHeight() - c.offset[0]; f += a.outerWidth() + c.offset[1]; if (/iPad/i.test(navigator.userAgent)) k -= e(window).scrollTop(); c = b.outerHeight() + a.outerHeight(); if (p == "center") k += c / 2; if (p == "bottom") k += c; a = a.outerWidth(); if (l == "center") f -= (a + b.outerWidth()) / 2; if (l == "left") f -= a; return { top: k, left: f} } function y(a) { function b() { return this.getAttribute("type") == a } b.key = "[type=" + a + "]"; return b } function u(a,
b, c) {
        function k(g, d, i) { if (!(!c.grouped && g.length)) { var j; if (i === false || e.isArray(i)) { j = h.messages[d.key || d] || h.messages["*"]; j = j[c.lang] || h.messages["*"].en; (d = j.match(/\$\d/g)) && e.isArray(i) && e.each(d, function (m) { j = j.replace(this, i[m]) }) } else j = i[c.lang] || i; g.push(j) } } var f = this, l = b.add(f); a = a.not(":button, :image, :reset, :submit"); e.extend(f, { getConf: function () { return c }, getForm: function () { return b }, getInputs: function () { return a }, reflow: function () {
            a.each(function () {
                var g = e(this), d = g.data("msg.el");
                if (d) { g = t(g, d, c); d.css({ top: g.top, left: g.left }) } 
            }); return f
        }, invalidate: function (g, d) { if (!d) { var i = []; e.each(g, function (j, m) { j = a.filter("[name='" + j + "']"); if (j.length) { j.trigger("OI", [m]); i.push({ input: j, messages: [m] }) } }); g = i; d = e.Event() } d.type = "onFail"; l.trigger(d, [g]); d.isDefaultPrevented() || q[c.effect][0].call(f, g, d); return f }, reset: function (g) {
            g = g || a; g.removeClass(c.errorClass).each(function () { var d = e(this).data("msg.el"); if (d) { d.remove(); e(this).data("msg.el", null) } }).unbind(c.errorInputEvent ||
""); return f
        }, destroy: function () { b.unbind(c.formEvent + ".V").unbind("reset.V"); a.unbind(c.inputEvent + ".V").unbind("change.V"); return f.reset() }, checkValidity: function (g, d) {
            g = g || a; g = g.not(":disabled"); if (!g.length) return true; d = d || e.Event(); d.type = "onBeforeValidate"; l.trigger(d, [g]); if (d.isDefaultPrevented()) return d.result; var i = []; g.not(":radio:not(:checked)").each(function () {
                var m = [], n = e(this).data("messages", m), v = r && n.is(":date") ? "onHide.v" : c.errorInputEvent + ".v"; n.unbind(v); e.each(w, function () {
                    var o =
this, s = o[0]; if (n.filter(s).length) { o = o[1].call(f, n, n.val()); if (o !== true) { d.type = "onBeforeFail"; l.trigger(d, [n, s]); if (d.isDefaultPrevented()) return false; var x = n.attr(c.messageAttr); if (x) { m = [x]; return false } else k(m, s, o) } } 
                }); if (m.length) { i.push({ input: n, messages: m }); n.trigger("OI", [m]); c.errorInputEvent && n.bind(v, function (o) { f.checkValidity(n, o) }) } if (c.singleError && i.length) return false
            }); var j = q[c.effect]; if (!j) throw 'Validator: cannot find effect "' + c.effect + '"'; if (i.length) { f.invalidate(i, d); return false } else {
                j[1].call(f,
g, d); d.type = "onSuccess"; l.trigger(d, [g]); g.unbind(c.errorInputEvent + ".v")
            } return true
        } 
        }); e.each("onBeforeValidate,onBeforeFail,onFail,onSuccess".split(","), function (g, d) { e.isFunction(c[d]) && e(f).bind(d, c[d]); f[d] = function (i) { i && e(f).bind(d, i); return f } }); c.formEvent && b.bind(c.formEvent + ".V", function (g) { if (!f.checkValidity(null, g)) return g.preventDefault() }); b.bind("reset.V", function () { f.reset() }); a[0] && a[0].validity && a.each(function () { this.oninvalid = function () { return false } }); if (b[0]) b[0].checkValidity =
f.checkValidity; c.inputEvent && a.bind(c.inputEvent + ".V", function (g) { f.checkValidity(e(this), g) }); a.filter(":checkbox, select").filter("[required]").bind("change.V", function (g) { var d = e(this); if (this.checked || d.is("select") && e(this).val()) q[c.effect][1].call(f, d, g) }); var p = a.filter(":radio").change(function (g) { f.checkValidity(p, g) }); e(window).resize(function () { f.reflow() })
    } e.tools = e.tools || { version: "1.2.5" }; var z = /\[type=([a-z]+)\]/, A = /^-?[0-9]*(\.[0-9]+)?$/, r = e.tools.dateinput, B = /^([a-z0-9_\.\-\+]+)@([\da-z\.\-]+)\.([a-z\.]{2,6})$/i,
C = /^(https?:\/\/)?[\da-z\.\-]+\.[a-z\.]{2,6}[#&+_\?\/\w \.\-=]*$/i, h; h = e.tools.validator = { conf: { grouped: false, effect: "default", errorClass: "invalid", inputEvent: null, errorInputEvent: "keyup", formEvent: "submit", lang: "en", message: "<div/>", messageAttr: "data-message", messageClass: "error", offset: [0, 0], position: "center right", singleError: false, speed: "normal" }, messages: { "*": { en: "Please correct this value"} }, localize: function (a, b) { e.each(b, function (c, k) { h.messages[c] = h.messages[c] || {}; h.messages[c][a] = k }) },
    localizeFn: function (a, b) { h.messages[a] = h.messages[a] || {}; e.extend(h.messages[a], b) }, fn: function (a, b, c) { if (e.isFunction(b)) c = b; else { if (typeof b == "string") b = { en: b }; this.messages[a.key || a] = b } if (b = z.exec(a)) a = y(b[1]); w.push([a, c]) }, addEffect: function (a, b, c) { q[a] = [b, c] } 
}; var w = [], q = { "default": [function (a) {
    var b = this.getConf(); e.each(a, function (c, k) {
        c = k.input; c.addClass(b.errorClass); var f = c.data("msg.el"); if (!f) { f = e(b.message).addClass(b.messageClass).appendTo(document.body); c.data("msg.el", f) } f.css({ visibility: "hidden" }).find("p").remove();
        e.each(k.messages, function (l, p) { e("<p/>").html(p).appendTo(f) }); f.outerWidth() == f.parent().width() && f.add(f.find("p")).css({ display: "inline" }); k = t(c, f, b); f.css({ visibility: "visible", position: "absolute", top: k.top, left: k.left }).fadeIn(b.speed)
    })
}, function (a) { var b = this.getConf(); a.removeClass(b.errorClass).each(function () { var c = e(this).data("msg.el"); c && c.css({ visibility: "hidden" }) }) } ]
}; e.each("email,url,number".split(","), function (a, b) { e.expr[":"][b] = function (c) { return c.getAttribute("type") === b } });
    e.fn.oninvalid = function (a) { return this[a ? "bind" : "trigger"]("OI", a) }; h.fn(":email", "Please enter a valid email address", function (a, b) { return !b || B.test(b) }); h.fn(":url", "Please enter a valid URL", function (a, b) { return !b || C.test(b) }); h.fn(":number", "Please enter a numeric value.", function (a, b) { return A.test(b) }); h.fn("[max]", "Please enter a value smaller than $1", function (a, b) { if (b === "" || r && a.is(":date")) return true; a = a.attr("max"); return parseFloat(b) <= parseFloat(a) ? true : [a] }); h.fn("[min]", "Please enter a value larger than $1",
function (a, b) { if (b === "" || r && a.is(":date")) return true; a = a.attr("min"); return parseFloat(b) >= parseFloat(a) ? true : [a] }); h.fn("[required]", "Please complete this mandatory field.", function (a, b) { if (a.is(":checkbox")) return a.is(":checked"); return !!b }); h.fn("[pattern]", function (a) { var b = new RegExp("^" + a.attr("pattern") + "$"); return b.test(a.val()) }); e.fn.validator = function (a) {
    var b = this.data("validator"); if (b) { b.destroy(); this.removeData("validator") } a = e.extend(true, {}, h.conf, a); if (this.is("form")) return this.each(function () {
        var c =
e(this); b = new u(c.find(":input"), c, a); c.data("validator", b)
    }); else { b = new u(this, this.eq(0).closest("form"), a); return this.data("validator", b) } 
} 
})(jQuery);
