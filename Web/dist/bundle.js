! function (t) {
    function e(n) {
        if (i[n]) return i[n].exports;
        var o = i[n] = {
            i: n,
            l: !1,
            exports: {}
        };
        return t[n].call(o.exports, o, o.exports, e), o.l = !0, o.exports
    }
    var i = {};
    e.m = t, e.c = i, e.i = function (t) {
        return t
    }, e.d = function (t, i, n) {
        e.o(t, i) || Object.defineProperty(t, i, {
            configurable: !1,
            enumerable: !0,
            get: n
        })
    }, e.n = function (t) {
        var i = t && t.__esModule ? function () {
            return t.default
        } : function () {
            return t
        };
        return e.d(i, "a", i), i
    }, e.o = function (t, e) {
        return Object.prototype.hasOwnProperty.call(t, e)
    }, e.p = "./", e(e.s = 5)
}([
    function (t, e) {
        t.exports = jQuery
    },
    function (t, e, i) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var n = i(0);
        i.n(n);
    },
    function (t, e, i) {
        var n, o, a, r, s, n, d, c, u, l, n, h, n, f, p, n, m, n, f, y, n, f, v, n, f, g, n, f, b, n, f, w, n, f, _, n, o, C = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) {
            return typeof t
        } : function (t) {
            return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t
        };
        ! function (a, r) {
            "use strict";
            n = [i(0)], void 0 !== (o = function (t) {
                r(a, t)
            }.apply(e, n)) && (t.exports = o)
        }(window, function (t, e) {
            "use strict";

            function i(i, a, s) {
                function d(t, e, n) {
                    var o, a = "$()." + i + '("' + e + '")';
                    return t.each(function (t, d) {
                        var c = s.data(d, i);
                        if (!c) return void r(i + " not initialized. Cannot call methods, i.e. " + a);
                        var u = c[e];
                        if (!u || "_" == e.charAt(0)) return void r(a + " is not a valid method");
                        var l = u.apply(c, n);
                        o = void 0 === o ? l : o
                    }), void 0 !== o ? o : t
                }

                function c(t, e) {
                    t.each(function (t, n) {
                        var o = s.data(n, i);
                        o ? (o.option(e), o._init()) : (o = new a(n, e), s.data(n, i, o))
                    })
                } (s = s || e || t.jQuery) && (a.prototype.option || (a.prototype.option = function (t) {
                    s.isPlainObject(t) && (this.options = s.extend(!0, this.options, t))
                }), s.fn[i] = function (t) {
                    if ("string" == typeof t) {
                        return d(this, t, o.call(arguments, 1))
                    }
                    return c(this, t), this
                }, n(s))
            }

            function n(t) {
                !t || t && t.bridget || (t.bridget = i)
            }
            var o = Array.prototype.slice,
                a = t.console,
                r = void 0 === a ? function () { } : function (t) {
                    a.error(t)
                };
            return n(e || t.jQuery), i
        }),
            function (t, e) {
                r = e, s = {
                    id: "ev-emitter/ev-emitter",
                    exports: {},
                    loaded: !1
                }, a = "function" == typeof r ? r.call(s.exports, i, s.exports, s) : r, s.loaded = !0, void 0 === a && (a = s.exports)
            }("undefined" != typeof window && window, function () {
                function t() { }
                var e = t.prototype;
                return e.on = function (t, e) {
                    if (t && e) {
                        var i = this._events = this._events || {},
                            n = i[t] = i[t] || [];
                        return -1 == n.indexOf(e) && n.push(e), this
                    }
                }, e.once = function (t, e) {
                    if (t && e) {
                        this.on(t, e);
                        var i = this._onceEvents = this._onceEvents || {};
                        return (i[t] = i[t] || {})[e] = !0, this
                    }
                }, e.off = function (t, e) {
                    var i = this._events && this._events[t];
                    if (i && i.length) {
                        var n = i.indexOf(e);
                        return -1 != n && i.splice(n, 1), this
                    }
                }, e.emitEvent = function (t, e) {
                    var i = this._events && this._events[t];
                    if (i && i.length) {
                        var n = 0,
                            o = i[n];
                        e = e || [];
                        for (var a = this._onceEvents && this._onceEvents[t]; o;) {
                            var r = a && a[o];
                            r && (this.off(t, o), delete a[o]), o.apply(this, e), n += r ? 0 : 1, o = i[n]
                        }
                        return this
                    }
                }, t
            }),
            function (t, i) {
                "use strict";
                n = [], d = function () {
                    return i()
                }.apply(e, n)
            }(window, function () {
                "use strict";

                function t(t) {
                    var e = parseFloat(t);
                    return -1 == t.indexOf("%") && !isNaN(e) && e
                }

                function e() { }

                function i() {
                    for (var t = {
                        width: 0,
                        height: 0,
                        innerWidth: 0,
                        innerHeight: 0,
                        outerWidth: 0,
                        outerHeight: 0
                    }, e = 0; c > e; e++) {
                        t[d[e]] = 0
                    }
                    return t
                }

                function n(t) {
                    var e = getComputedStyle(t);
                    return e || s("Style returned " + e + ". Are you running this code in a hidden iframe on Firefox? See http://bit.ly/getsizebug1"), e
                }

                function o() {
                    if (!u) {
                        u = !0;
                        var e = document.createElement("div");
                        e.style.width = "200px", e.style.padding = "1px 2px 3px 4px", e.style.borderStyle = "solid", e.style.borderWidth = "1px 2px 3px 4px", e.style.boxSizing = "border-box";
                        var i = document.body || document.documentElement;
                        i.appendChild(e);
                        var o = n(e);
                        a.isBoxSizeOuter = r = 200 == t(o.width), i.removeChild(e)
                    }
                }

                function a(e) {
                    if (o(), "string" == typeof e && (e = document.querySelector(e)), e && "object" == (void 0 === e ? "undefined" : C(e)) && e.nodeType) {
                        var a = n(e);
                        if ("none" == a.display) return i();
                        var s = {};
                        s.width = e.offsetWidth, s.height = e.offsetHeight;
                        for (var u = s.isBorderBox = "border-box" == a.boxSizing, l = 0; c > l; l++) {
                            var h = d[l],
                                f = a[h],
                                p = parseFloat(f);
                            s[h] = isNaN(p) ? 0 : p
                        }
                        var m = s.paddingLeft + s.paddingRight,
                            y = s.paddingTop + s.paddingBottom,
                            v = s.marginLeft + s.marginRight,
                            g = s.marginTop + s.marginBottom,
                            b = s.borderLeftWidth + s.borderRightWidth,
                            w = s.borderTopWidth + s.borderBottomWidth,
                            _ = u && r,
                            x = t(a.width);
                        !1 !== x && (s.width = x + (_ ? 0 : m + b));
                        var I = t(a.height);
                        return !1 !== I && (s.height = I + (_ ? 0 : y + w)), s.innerWidth = s.width - (m + b), s.innerHeight = s.height - (y + w), s.outerWidth = s.width + v, s.outerHeight = s.height + g, s
                    }
                }
                var r, s = "undefined" == typeof console ? e : function (t) {
                    console.error(t)
                },
                    d = ["paddingLeft", "paddingRight", "paddingTop", "paddingBottom", "marginLeft", "marginRight", "marginTop", "marginBottom", "borderLeftWidth", "borderRightWidth", "borderTopWidth", "borderBottomWidth"],
                    c = d.length,
                    u = !1;
                return a
            }),
            function (t, e) {
                "use strict";
                u = e, l = {
                    id: "desandro-matches-selector/matches-selector",
                    exports: {},
                    loaded: !1
                }, c = "function" == typeof u ? u.call(l.exports, i, l.exports, l) : u, l.loaded = !0, void 0 === c && (c = l.exports)
            }(window, function () {
                "use strict";
                var t = function () {
                    var t = Element.prototype;
                    if (t.matches) return "matches";
                    if (t.matchesSelector) return "matchesSelector";
                    for (var e = ["webkit", "moz", "ms", "o"], i = 0; i < e.length; i++) {
                        var n = e[i],
                            o = n + "MatchesSelector";
                        if (t[o]) return o
                    }
                }();
                return function (e, i) {
                    return e[t](i)
                }
            }),
            function (t, i) {
                n = [c], h = function (e) {
                    return i(t, e)
                }.apply(e, n)
            }(window, function (t, e) {
                var i = {};
                i.extend = function (t, e) {
                    for (var i in e) t[i] = e[i];
                    return t
                }, i.modulo = function (t, e) {
                    return (t % e + e) % e
                }, i.makeArray = function (t) {
                    var e = [];
                    if (Array.isArray(t)) e = t;
                    else if (t && "number" == typeof t.length)
                        for (var i = 0; i < t.length; i++) e.push(t[i]);
                    else e.push(t);
                    return e
                }, i.removeFrom = function (t, e) {
                    var i = t.indexOf(e); - 1 != i && t.splice(i, 1)
                }, i.getParent = function (t, i) {
                    for (; t != document.body;)
                        if (t = t.parentNode, e(t, i)) return t
                }, i.getQueryElement = function (t) {
                    return "string" == typeof t ? document.querySelector(t) : t
                }, i.handleEvent = function (t) {
                    var e = "on" + t.type;
                    this[e] && this[e](t)
                }, i.filterFindElements = function (t, n) {
                    t = i.makeArray(t);
                    var o = [];
                    return t.forEach(function (t) {
                        if (t instanceof HTMLElement) {
                            if (!n) return void o.push(t);
                            e(t, n) && o.push(t);
                            for (var i = t.querySelectorAll(n), a = 0; a < i.length; a++) o.push(i[a])
                        }
                    }), o
                }, i.debounceMethod = function (t, e, i) {
                    var n = t.prototype[e],
                        o = e + "Timeout";
                    t.prototype[e] = function () {
                        var t = this[o];
                        t && clearTimeout(t);
                        var e = arguments,
                            a = this;
                        this[o] = setTimeout(function () {
                            n.apply(a, e), delete a[o]
                        }, i || 100)
                    }
                }, i.docReady = function (t) {
                    var e = document.readyState;
                    "complete" == e || "interactive" == e ? t() : document.addEventListener("DOMContentLoaded", t)
                }, i.toDashed = function (t) {
                    return t.replace(/(.)([A-Z])/g, function (t, e, i) {
                        return e + "-" + i
                    }).toLowerCase()
                };
                var n = t.console;
                return i.htmlInit = function (e, o) {
                    i.docReady(function () {
                        var a = i.toDashed(o),
                            r = "data-" + a,
                            s = document.querySelectorAll("[" + r + "]"),
                            d = document.querySelectorAll(".js-" + a),
                            c = i.makeArray(s).concat(i.makeArray(d)),
                            u = r + "-options",
                            l = t.jQuery;
                        c.forEach(function (t) {
                            var i, a = t.getAttribute(r) || t.getAttribute(u);
                            try {
                                i = a && JSON.parse(a)
                            } catch (e) {
                                return void (n && n.error("Error parsing " + r + " on " + t.className + ": " + e))
                            }
                            var s = new e(t, i);
                            l && l.data(t, o, s)
                        })
                    })
                }, i
            }),
            function (t, i) {
                n = [a, d], f = i, p = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t, e) {
                "use strict";

                function i(t) {
                    for (var e in t) return !1;
                    return null, !0
                }

                function n(t, e) {
                    t && (this.element = t, this.layout = e, this.position = {
                        x: 0,
                        y: 0
                    }, this._create())
                }
                var o = document.documentElement.style,
                    a = "string" == typeof o.transition ? "transition" : "WebkitTransition",
                    r = "string" == typeof o.transform ? "transform" : "WebkitTransform",
                    s = {
                        WebkitTransition: "webkitTransitionEnd",
                        transition: "transitionend"
                    }[a],
                    d = {
                        transform: r,
                        transition: a,
                        transitionDuration: a + "Duration",
                        transitionProperty: a + "Property",
                        transitionDelay: a + "Delay"
                    },
                    c = n.prototype = Object.create(t.prototype);
                c.constructor = n, c._create = function () {
                    this._transn = {
                        ingProperties: {},
                        clean: {},
                        onEnd: {}
                    }, this.css({
                        position: "absolute"
                    })
                }, c.handleEvent = function (t) {
                    var e = "on" + t.type;
                    this[e] && this[e](t)
                }, c.getSize = function () {
                    this.size = e(this.element)
                }, c.css = function (t) {
                    var e = this.element.style;
                    for (var i in t) {
                        e[d[i] || i] = t[i]
                    }
                }, c.getPosition = function () {
                    var t = getComputedStyle(this.element),
                        e = this.layout._getOption("originLeft"),
                        i = this.layout._getOption("originTop"),
                        n = t[e ? "left" : "right"],
                        o = t[i ? "top" : "bottom"],
                        a = this.layout.size,
                        r = -1 != n.indexOf("%") ? parseFloat(n) / 100 * a.width : parseInt(n, 10),
                        s = -1 != o.indexOf("%") ? parseFloat(o) / 100 * a.height : parseInt(o, 10);
                    r = isNaN(r) ? 0 : r, s = isNaN(s) ? 0 : s, r -= e ? a.paddingLeft : a.paddingRight, s -= i ? a.paddingTop : a.paddingBottom, this.position.x = r, this.position.y = s
                }, c.layoutPosition = function () {
                    var t = this.layout.size,
                        e = {},
                        i = this.layout._getOption("originLeft"),
                        n = this.layout._getOption("originTop"),
                        o = i ? "paddingLeft" : "paddingRight",
                        a = i ? "left" : "right",
                        r = i ? "right" : "left",
                        s = this.position.x + t[o];
                    e[a] = this.getXValue(s), e[r] = "";
                    var d = n ? "paddingTop" : "paddingBottom",
                        c = n ? "top" : "bottom",
                        u = n ? "bottom" : "top",
                        l = this.position.y + t[d];
                    e[c] = this.getYValue(l), e[u] = "", this.css(e), this.emitEvent("layout", [this])
                }, c.getXValue = function (t) {
                    var e = this.layout._getOption("horizontal");
                    return this.layout.options.percentPosition && !e ? t / this.layout.size.width * 100 + "%" : t + "px"
                }, c.getYValue = function (t) {
                    var e = this.layout._getOption("horizontal");
                    return this.layout.options.percentPosition && e ? t / this.layout.size.height * 100 + "%" : t + "px"
                }, c._transitionTo = function (t, e) {
                    this.getPosition();
                    var i = this.position.x,
                        n = this.position.y,
                        o = parseInt(t, 10),
                        a = parseInt(e, 10),
                        r = o === this.position.x && a === this.position.y;
                    if (this.setPosition(t, e), r && !this.isTransitioning) return void this.layoutPosition();
                    var s = t - i,
                        d = e - n,
                        c = {};
                    c.transform = this.getTranslate(s, d), this.transition({
                        to: c,
                        onTransitionEnd: {
                            transform: this.layoutPosition
                        },
                        isCleaning: !0
                    })
                }, c.getTranslate = function (t, e) {
                    var i = this.layout._getOption("originLeft"),
                        n = this.layout._getOption("originTop");
                    return t = i ? t : -t, e = n ? e : -e, "translate3d(" + t + "px, " + e + "px, 0)"
                }, c.goTo = function (t, e) {
                    this.setPosition(t, e), this.layoutPosition()
                }, c.moveTo = c._transitionTo, c.setPosition = function (t, e) {
                    this.position.x = parseInt(t, 10), this.position.y = parseInt(e, 10)
                }, c._nonTransition = function (t) {
                    this.css(t.to), t.isCleaning && this._removeStyles(t.to);
                    for (var e in t.onTransitionEnd) t.onTransitionEnd[e].call(this)
                }, c.transition = function (t) {
                    if (!parseFloat(this.layout.options.transitionDuration)) return void this._nonTransition(t);
                    var e = this._transn;
                    for (var i in t.onTransitionEnd) e.onEnd[i] = t.onTransitionEnd[i];
                    for (i in t.to) e.ingProperties[i] = !0, t.isCleaning && (e.clean[i] = !0);
                    if (t.from) {
                        this.css(t.from);
                        this.element.offsetHeight;
                        null
                    }
                    this.enableTransition(t.to), this.css(t.to), this.isTransitioning = !0
                };
                var u = "opacity," + function (t) {
                    return t.replace(/([A-Z])/g, function (t) {
                        return "-" + t.toLowerCase()
                    })
                }(r);
                c.enableTransition = function () {
                    if (!this.isTransitioning) {
                        var t = this.layout.options.transitionDuration;
                        t = "number" == typeof t ? t + "ms" : t, this.css({
                            transitionProperty: u,
                            transitionDuration: t,
                            transitionDelay: this.staggerDelay || 0
                        }), this.element.addEventListener(s, this, !1)
                    }
                }, c.onwebkitTransitionEnd = function (t) {
                    this.ontransitionend(t)
                }, c.onotransitionend = function (t) {
                    this.ontransitionend(t)
                };
                var l = {
                    "-webkit-transform": "transform"
                };
                c.ontransitionend = function (t) {
                    if (t.target === this.element) {
                        var e = this._transn,
                            n = l[t.propertyName] || t.propertyName;
                        if (delete e.ingProperties[n], i(e.ingProperties) && this.disableTransition(), n in e.clean && (this.element.style[t.propertyName] = "", delete e.clean[n]), n in e.onEnd) {
                            e.onEnd[n].call(this), delete e.onEnd[n]
                        }
                        this.emitEvent("transitionEnd", [this])
                    }
                }, c.disableTransition = function () {
                    this.removeTransitionStyles(), this.element.removeEventListener(s, this, !1), this.isTransitioning = !1
                }, c._removeStyles = function (t) {
                    var e = {};
                    for (var i in t) e[i] = "";
                    this.css(e)
                };
                var h = {
                    transitionProperty: "",
                    transitionDuration: "",
                    transitionDelay: ""
                };
                return c.removeTransitionStyles = function () {
                    this.css(h)
                }, c.stagger = function (t) {
                    t = isNaN(t) ? 0 : t, this.staggerDelay = t + "ms"
                }, c.removeElem = function () {
                    this.element.parentNode.removeChild(this.element), this.css({
                        display: ""
                    }), this.emitEvent("remove", [this])
                }, c.remove = function () {
                    return a && parseFloat(this.layout.options.transitionDuration) ? (this.once("transitionEnd", function () {
                        this.removeElem()
                    }), void this.hide()) : void this.removeElem()
                }, c.reveal = function () {
                    delete this.isHidden, this.css({
                        display: ""
                    });
                    var t = this.layout.options,
                        e = {};
                    e[this.getHideRevealTransitionEndProperty("visibleStyle")] = this.onRevealTransitionEnd, this.transition({
                        from: t.hiddenStyle,
                        to: t.visibleStyle,
                        isCleaning: !0,
                        onTransitionEnd: e
                    })
                }, c.onRevealTransitionEnd = function () {
                    this.isHidden || this.emitEvent("reveal")
                }, c.getHideRevealTransitionEndProperty = function (t) {
                    var e = this.layout.options[t];
                    if (e.opacity) return "opacity";
                    for (var i in e) return i
                }, c.hide = function () {
                    this.isHidden = !0, this.css({
                        display: ""
                    });
                    var t = this.layout.options,
                        e = {};
                    e[this.getHideRevealTransitionEndProperty("hiddenStyle")] = this.onHideTransitionEnd, this.transition({
                        from: t.visibleStyle,
                        to: t.hiddenStyle,
                        isCleaning: !0,
                        onTransitionEnd: e
                    })
                }, c.onHideTransitionEnd = function () {
                    this.isHidden && (this.css({
                        display: "none"
                    }), this.emitEvent("hide"))
                }, c.destroy = function () {
                    this.css({
                        position: "",
                        left: "",
                        right: "",
                        top: "",
                        bottom: "",
                        transition: "",
                        transform: ""
                    })
                }, n
            }),
            function (t, i) {
                "use strict";
                n = [a, d, h, p], m = function (e, n, o, a) {
                    return i(t, e, n, o, a)
                }.apply(e, n)
            }(window, function (t, e, i, n, o) {
                "use strict";

                function a(t, e) {
                    var i = n.getQueryElement(t);
                    if (!i) return void (d && d.error("Bad element for " + this.constructor.namespace + ": " + (i || t)));
                    this.element = i, c && (this.$element = c(this.element)), this.options = n.extend({}, this.constructor.defaults), this.option(e);
                    var o = ++l;
                    this.element.outlayerGUID = o, h[o] = this, this._create(), this._getOption("initLayout") && this.layout()
                }

                function r(t) {
                    function e() {
                        t.apply(this, arguments)
                    }
                    return e.prototype = Object.create(t.prototype), e.prototype.constructor = e, e
                }

                function s(t) {
                    if ("number" == typeof t) return t;
                    var e = t.match(/(^\d*\.?\d*)(\w*)/),
                        i = e && e[1],
                        n = e && e[2];
                    return i.length ? (i = parseFloat(i)) * (p[n] || 1) : 0
                }
                var d = t.console,
                    c = t.jQuery,
                    u = function () { },
                    l = 0,
                    h = {};
                a.namespace = "outlayer", a.Item = o, a.defaults = {
                    containerStyle: {
                        position: "relative"
                    },
                    initLayout: !0,
                    originLeft: !0,
                    originTop: !0,
                    resize: !0,
                    resizeContainer: !0,
                    transitionDuration: "0.4s",
                    hiddenStyle: {
                        opacity: 0,
                        transform: "scale(0.001)"
                    },
                    visibleStyle: {
                        opacity: 1,
                        transform: "scale(1)"
                    }
                };
                var f = a.prototype;
                n.extend(f, e.prototype), f.option = function (t) {
                    n.extend(this.options, t)
                }, f._getOption = function (t) {
                    var e = this.constructor.compatOptions[t];
                    return e && void 0 !== this.options[e] ? this.options[e] : this.options[t]
                }, a.compatOptions = {
                    initLayout: "isInitLayout",
                    horizontal: "isHorizontal",
                    layoutInstant: "isLayoutInstant",
                    originLeft: "isOriginLeft",
                    originTop: "isOriginTop",
                    resize: "isResizeBound",
                    resizeContainer: "isResizingContainer"
                }, f._create = function () {
                    this.reloadItems(), this.stamps = [], this.stamp(this.options.stamp), n.extend(this.element.style, this.options.containerStyle), this._getOption("resize") && this.bindResize()
                }, f.reloadItems = function () {
                    this.items = this._itemize(this.element.children)
                }, f._itemize = function (t) {
                    for (var e = this._filterFindItemElements(t), i = this.constructor.Item, n = [], o = 0; o < e.length; o++) {
                        var a = e[o],
                            r = new i(a, this);
                        n.push(r)
                    }
                    return n
                }, f._filterFindItemElements = function (t) {
                    return n.filterFindElements(t, this.options.itemSelector)
                }, f.getItemElements = function () {
                    return this.items.map(function (t) {
                        return t.element
                    })
                }, f.layout = function () {
                    this._resetLayout(), this._manageStamps();
                    var t = this._getOption("layoutInstant"),
                        e = void 0 !== t ? t : !this._isLayoutInited;
                    this.layoutItems(this.items, e), this._isLayoutInited = !0
                }, f._init = f.layout, f._resetLayout = function () {
                    this.getSize()
                }, f.getSize = function () {
                    this.size = i(this.element)
                }, f._getMeasurement = function (t, e) {
                    var n, o = this.options[t];
                    o ? ("string" == typeof o ? n = this.element.querySelector(o) : o instanceof HTMLElement && (n = o), this[t] = n ? i(n)[e] : o) : this[t] = 0
                }, f.layoutItems = function (t, e) {
                    t = this._getItemsForLayout(t), this._layoutItems(t, e), this._postLayout()
                }, f._getItemsForLayout = function (t) {
                    return t.filter(function (t) {
                        return !t.isIgnored
                    })
                }, f._layoutItems = function (t, e) {
                    if (this._emitCompleteOnItems("layout", t), t && t.length) {
                        var i = [];
                        t.forEach(function (t) {
                            var n = this._getItemLayoutPosition(t);
                            n.item = t, n.isInstant = e || t.isLayoutInstant, i.push(n)
                        }, this), this._processLayoutQueue(i)
                    }
                }, f._getItemLayoutPosition = function () {
                    return {
                        x: 0,
                        y: 0
                    }
                }, f._processLayoutQueue = function (t) {
                    this.updateStagger(), t.forEach(function (t, e) {
                        this._positionItem(t.item, t.x, t.y, t.isInstant, e)
                    }, this)
                }, f.updateStagger = function () {
                    var t = this.options.stagger;
                    return null === t || void 0 === t ? void (this.stagger = 0) : (this.stagger = s(t), this.stagger)
                }, f._positionItem = function (t, e, i, n, o) {
                    n ? t.goTo(e, i) : (t.stagger(o * this.stagger), t.moveTo(e, i))
                }, f._postLayout = function () {
                    this.resizeContainer()
                }, f.resizeContainer = function () {
                    if (this._getOption("resizeContainer")) {
                        var t = this._getContainerSize();
                        t && (this._setContainerMeasure(t.width, !0), this._setContainerMeasure(t.height, !1))
                    }
                }, f._getContainerSize = u, f._setContainerMeasure = function (t, e) {
                    if (void 0 !== t) {
                        var i = this.size;
                        i.isBorderBox && (t += e ? i.paddingLeft + i.paddingRight + i.borderLeftWidth + i.borderRightWidth : i.paddingBottom + i.paddingTop + i.borderTopWidth + i.borderBottomWidth), t = Math.max(t, 0), this.element.style[e ? "width" : "height"] = t + "px"
                    }
                }, f._emitCompleteOnItems = function (t, e) {
                    function i() {
                        o.dispatchEvent(t + "Complete", null, [e])
                    }

                    function n() {
                        ++r == a && i()
                    }
                    var o = this,
                        a = e.length;
                    if (!e || !a) return void i();
                    var r = 0;
                    e.forEach(function (e) {
                        e.once(t, n)
                    })
                }, f.dispatchEvent = function (t, e, i) {
                    var n = e ? [e].concat(i) : i;
                    if (this.emitEvent(t, n), c)
                        if (this.$element = this.$element || c(this.element), e) {
                            var o = c.Event(e);
                            o.type = t, this.$element.trigger(o, i)
                        } else this.$element.trigger(t, i)
                }, f.ignore = function (t) {
                    var e = this.getItem(t);
                    e && (e.isIgnored = !0)
                }, f.unignore = function (t) {
                    var e = this.getItem(t);
                    e && delete e.isIgnored
                }, f.stamp = function (t) {
                    (t = this._find(t)) && (this.stamps = this.stamps.concat(t), t.forEach(this.ignore, this))
                }, f.unstamp = function (t) {
                    (t = this._find(t)) && t.forEach(function (t) {
                        n.removeFrom(this.stamps, t), this.unignore(t)
                    }, this)
                }, f._find = function (t) {
                    return t ? ("string" == typeof t && (t = this.element.querySelectorAll(t)), t = n.makeArray(t)) : void 0
                }, f._manageStamps = function () {
                    this.stamps && this.stamps.length && (this._getBoundingRect(), this.stamps.forEach(this._manageStamp, this))
                }, f._getBoundingRect = function () {
                    var t = this.element.getBoundingClientRect(),
                        e = this.size;
                    this._boundingRect = {
                        left: t.left + e.paddingLeft + e.borderLeftWidth,
                        top: t.top + e.paddingTop + e.borderTopWidth,
                        right: t.right - (e.paddingRight + e.borderRightWidth),
                        bottom: t.bottom - (e.paddingBottom + e.borderBottomWidth)
                    }
                }, f._manageStamp = u, f._getElementOffset = function (t) {
                    var e = t.getBoundingClientRect(),
                        n = this._boundingRect,
                        o = i(t);
                    return {
                        left: e.left - n.left - o.marginLeft,
                        top: e.top - n.top - o.marginTop,
                        right: n.right - e.right - o.marginRight,
                        bottom: n.bottom - e.bottom - o.marginBottom
                    }
                }, f.handleEvent = n.handleEvent, f.bindResize = function () {
                    t.addEventListener("resize", this), this.isResizeBound = !0
                }, f.unbindResize = function () {
                    t.removeEventListener("resize", this), this.isResizeBound = !1
                }, f.onresize = function () {
                    this.resize()
                }, n.debounceMethod(a, "onresize", 100), f.resize = function () {
                    this.isResizeBound && this.needsResizeLayout() && this.layout()
                }, f.needsResizeLayout = function () {
                    var t = i(this.element);
                    return this.size && t && t.innerWidth !== this.size.innerWidth
                }, f.addItems = function (t) {
                    var e = this._itemize(t);
                    return e.length && (this.items = this.items.concat(e)), e
                }, f.appended = function (t) {
                    var e = this.addItems(t);
                    e.length && (this.layoutItems(e, !0), this.reveal(e))
                }, f.prepended = function (t) {
                    var e = this._itemize(t);
                    if (e.length) {
                        var i = this.items.slice(0);
                        this.items = e.concat(i), this._resetLayout(), this._manageStamps(), this.layoutItems(e, !0), this.reveal(e), this.layoutItems(i)
                    }
                }, f.reveal = function (t) {
                    if (this._emitCompleteOnItems("reveal", t), t && t.length) {
                        var e = this.updateStagger();
                        t.forEach(function (t, i) {
                            t.stagger(i * e), t.reveal()
                        })
                    }
                }, f.hide = function (t) {
                    if (this._emitCompleteOnItems("hide", t), t && t.length) {
                        var e = this.updateStagger();
                        t.forEach(function (t, i) {
                            t.stagger(i * e), t.hide()
                        })
                    }
                }, f.revealItemElements = function (t) {
                    var e = this.getItems(t);
                    this.reveal(e)
                }, f.hideItemElements = function (t) {
                    var e = this.getItems(t);
                    this.hide(e)
                }, f.getItem = function (t) {
                    for (var e = 0; e < this.items.length; e++) {
                        var i = this.items[e];
                        if (i.element == t) return i
                    }
                }, f.getItems = function (t) {
                    t = n.makeArray(t);
                    var e = [];
                    return t.forEach(function (t) {
                        var i = this.getItem(t);
                        i && e.push(i)
                    }, this), e
                }, f.remove = function (t) {
                    var e = this.getItems(t);
                    this._emitCompleteOnItems("remove", e), e && e.length && e.forEach(function (t) {
                        t.remove(), n.removeFrom(this.items, t)
                    }, this)
                }, f.destroy = function () {
                    var t = this.element.style;
                    t.height = "", t.position = "", t.width = "", this.items.forEach(function (t) {
                        t.destroy()
                    }), this.unbindResize();
                    var e = this.element.outlayerGUID;
                    delete h[e], delete this.element.outlayerGUID, c && c.removeData(this.element, this.constructor.namespace)
                }, a.data = function (t) {
                    t = n.getQueryElement(t);
                    var e = t && t.outlayerGUID;
                    return e && h[e]
                }, a.create = function (t, e) {
                    var i = r(a);
                    return i.defaults = n.extend({}, a.defaults), n.extend(i.defaults, e), i.compatOptions = n.extend({}, a.compatOptions), i.namespace = t, i.data = a.data, i.Item = r(o), n.htmlInit(i, t), c && c.bridget && c.bridget(t, i), i
                };
                var p = {
                    ms: 1,
                    s: 1e3
                };
                return a.Item = o, a
            }),
            function (t, i) {
                n = [m], f = i, y = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t) {
                "use strict";

                function e() {
                    t.Item.apply(this, arguments)
                }
                var i = e.prototype = Object.create(t.Item.prototype),
                    n = i._create;
                i._create = function () {
                    this.id = this.layout.itemGUID++ , n.call(this), this.sortData = {}
                }, i.updateSortData = function () {
                    if (!this.isIgnored) {
                        this.sortData.id = this.id, this.sortData["original-order"] = this.id, this.sortData.random = Math.random();
                        var t = this.layout.options.getSortData,
                            e = this.layout._sorters;
                        for (var i in t) {
                            var n = e[i];
                            this.sortData[i] = n(this.element, this)
                        }
                    }
                };
                var o = i.destroy;
                return i.destroy = function () {
                    o.apply(this, arguments), this.css({
                        display: ""
                    })
                }, e
            }),
            function (t, i) {
                n = [d, m], f = i, v = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t, e) {
                "use strict";

                function i(t) {
                    this.isotope = t, t && (this.options = t.options[this.namespace], this.element = t.element, this.items = t.filteredItems, this.size = t.size)
                }
                var n = i.prototype;
                return ["_resetLayout", "_getItemLayoutPosition", "_manageStamp", "_getContainerSize", "_getElementOffset", "needsResizeLayout", "_getOption"].forEach(function (t) {
                    n[t] = function () {
                        return e.prototype[t].apply(this.isotope, arguments)
                    }
                }), n.needsVerticalResizeLayout = function () {
                    var e = t(this.isotope.element);
                    return this.isotope.size && e && e.innerHeight != this.isotope.size.innerHeight
                }, n._getMeasurement = function () {
                    this.isotope._getMeasurement.apply(this, arguments)
                }, n.getColumnWidth = function () {
                    this.getSegmentSize("column", "Width")
                }, n.getRowHeight = function () {
                    this.getSegmentSize("row", "Height")
                }, n.getSegmentSize = function (t, e) {
                    var i = t + e,
                        n = "outer" + e;
                    if (this._getMeasurement(i, n), !this[i]) {
                        var o = this.getFirstItemSize();
                        this[i] = o && o[n] || this.isotope.size["inner" + e]
                    }
                }, n.getFirstItemSize = function () {
                    var e = this.isotope.filteredItems[0];
                    return e && e.element && t(e.element)
                }, n.layout = function () {
                    this.isotope.layout.apply(this.isotope, arguments)
                }, n.getSize = function () {
                    this.isotope.getSize(), this.size = this.isotope.size
                }, i.modes = {}, i.create = function (t, e) {
                    function o() {
                        i.apply(this, arguments)
                    }
                    return o.prototype = Object.create(n), o.prototype.constructor = o, e && (o.options = e), o.prototype.namespace = t, i.modes[t] = o, o
                }, i
            }),
            function (t, i) {
                n = [m, d], f = i, g = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t, e) {
                var i = t.create("masonry");
                return i.compatOptions.fitWidth = "isFitWidth", i.prototype._resetLayout = function () {
                    this.getSize(), this._getMeasurement("columnWidth", "outerWidth"), this._getMeasurement("gutter", "outerWidth"), this.measureColumns(), this.colYs = [];
                    for (var t = 0; t < this.cols; t++) this.colYs.push(0);
                    this.maxY = 0
                }, i.prototype.measureColumns = function () {
                    if (this.getContainerWidth(), !this.columnWidth) {
                        var t = this.items[0],
                            i = t && t.element;
                        this.columnWidth = i && e(i).outerWidth || this.containerWidth
                    }
                    var n = this.columnWidth += this.gutter,
                        o = this.containerWidth + this.gutter,
                        a = o / n,
                        r = n - o % n,
                        s = r && 1 > r ? "round" : "floor";
                    a = Math[s](a), this.cols = Math.max(a, 1)
                }, i.prototype.getContainerWidth = function () {
                    var t = this._getOption("fitWidth"),
                        i = t ? this.element.parentNode : this.element,
                        n = e(i);
                    this.containerWidth = n && n.innerWidth
                }, i.prototype._getItemLayoutPosition = function (t) {
                    t.getSize();
                    var e = t.size.outerWidth % this.columnWidth,
                        i = e && 1 > e ? "round" : "ceil",
                        n = Math[i](t.size.outerWidth / this.columnWidth);
                    n = Math.min(n, this.cols);
                    for (var o = this._getColGroup(n), a = Math.min.apply(Math, o), r = o.indexOf(a), s = {
                        x: this.columnWidth * r,
                        y: a
                    }, d = a + t.size.outerHeight, c = this.cols + 1 - o.length, u = 0; c > u; u++) this.colYs[r + u] = d;
                    return s
                }, i.prototype._getColGroup = function (t) {
                    if (2 > t) return this.colYs;
                    for (var e = [], i = this.cols + 1 - t, n = 0; i > n; n++) {
                        var o = this.colYs.slice(n, n + t);
                        e[n] = Math.max.apply(Math, o)
                    }
                    return e
                }, i.prototype._manageStamp = function (t) {
                    var i = e(t),
                        n = this._getElementOffset(t),
                        o = this._getOption("originLeft"),
                        a = o ? n.left : n.right,
                        r = a + i.outerWidth,
                        s = Math.floor(a / this.columnWidth);
                    s = Math.max(0, s);
                    var d = Math.floor(r / this.columnWidth);
                    d -= r % this.columnWidth ? 0 : 1, d = Math.min(this.cols - 1, d);
                    for (var c = this._getOption("originTop"), u = (c ? n.top : n.bottom) + i.outerHeight, l = s; d >= l; l++) this.colYs[l] = Math.max(u, this.colYs[l])
                }, i.prototype._getContainerSize = function () {
                    this.maxY = Math.max.apply(Math, this.colYs);
                    var t = {
                        height: this.maxY
                    };
                    return this._getOption("fitWidth") && (t.width = this._getContainerFitWidth()), t
                }, i.prototype._getContainerFitWidth = function () {
                    for (var t = 0, e = this.cols; --e && 0 === this.colYs[e];) t++;
                    return (this.cols - t) * this.columnWidth - this.gutter
                }, i.prototype.needsResizeLayout = function () {
                    var t = this.containerWidth;
                    return this.getContainerWidth(), t != this.containerWidth
                }, i
            }),
            function (t, i) {
                n = [v, g], f = i, b = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t, e) {
                "use strict";
                var i = t.create("masonry"),
                    n = i.prototype,
                    o = {
                        _getElementOffset: !0,
                        layout: !0,
                        _getMeasurement: !0
                    };
                for (var a in e.prototype) o[a] || (n[a] = e.prototype[a]);
                var r = n.measureColumns;
                n.measureColumns = function () {
                    this.items = this.isotope.filteredItems, r.call(this)
                };
                var s = n._getOption;
                return n._getOption = function (t) {
                    return "fitWidth" == t ? void 0 !== this.options.isFitWidth ? this.options.isFitWidth : this.options.fitWidth : s.apply(this.isotope, arguments)
                }, i
            }),
            function (t, i) {
                n = [v], f = i, w = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t) {
                "use strict";
                var e = t.create("fitRows"),
                    i = e.prototype;
                return i._resetLayout = function () {
                    this.x = 0, this.y = 0, this.maxY = 0, this._getMeasurement("gutter", "outerWidth")
                }, i._getItemLayoutPosition = function (t) {
                    t.getSize();
                    var e = t.size.outerWidth + this.gutter,
                        i = this.isotope.size.innerWidth + this.gutter;
                    0 !== this.x && e + this.x > i && (this.x = 0, this.y = this.maxY);
                    var n = {
                        x: this.x,
                        y: this.y
                    };
                    return this.maxY = Math.max(this.maxY, this.y + t.size.outerHeight), this.x += e, n
                }, i._getContainerSize = function () {
                    return {
                        height: this.maxY
                    }
                }, e
            }),
            function (t, i) {
                n = [v], f = i, _ = "function" == typeof f ? f.apply(e, n) : f
            }(window, function (t) {
                "use strict";
                var e = t.create("vertical", {
                    horizontalAlignment: 0
                }),
                    i = e.prototype;
                return i._resetLayout = function () {
                    this.y = 0
                }, i._getItemLayoutPosition = function (t) {
                    t.getSize();
                    var e = (this.isotope.size.innerWidth - t.size.outerWidth) * this.options.horizontalAlignment,
                        i = this.y;
                    return this.y += t.size.outerHeight, {
                        x: e,
                        y: i
                    }
                }, i._getContainerSize = function () {
                    return {
                        height: this.y
                    }
                }, e
            }),
            function (i, a) {
                n = [m, d, c, h, y, v, b, w, _], void 0 !== (o = function (t, e, n, o, r, s) {
                    return a(i, t, e, n, o, r, s)
                }.apply(e, n)) && (t.exports = o)
            }(window, function (t, e, i, n, o, a, r) {
                function s(t, e) {
                    return function (i, n) {
                        for (var o = 0; o < t.length; o++) {
                            var a = t[o],
                                r = i.sortData[a],
                                s = n.sortData[a];
                            if (r > s || s > r) {
                                var d = void 0 !== e[a] ? e[a] : e,
                                    c = d ? 1 : -1;
                                return (r > s ? 1 : -1) * c
                            }
                        }
                        return 0
                    }
                }
                var d = t.jQuery,
                    c = String.prototype.trim ? function (t) {
                        return t.trim()
                    } : function (t) {
                        return t.replace(/^\s+|\s+$/g, "")
                    },
                    u = e.create("isotope", {
                        layoutMode: "masonry",
                        isJQueryFiltering: !0,
                        sortAscending: !0
                    });
                u.Item = a, u.LayoutMode = r;
                var l = u.prototype;
                l._create = function () {
                    this.itemGUID = 0, this._sorters = {}, this._getSorters(), e.prototype._create.call(this), this.modes = {}, this.filteredItems = this.items, this.sortHistory = ["original-order"];
                    for (var t in r.modes) this._initLayoutMode(t)
                }, l.reloadItems = function () {
                    this.itemGUID = 0, e.prototype.reloadItems.call(this)
                }, l._itemize = function () {
                    for (var t = e.prototype._itemize.apply(this, arguments), i = 0; i < t.length; i++) {
                        t[i].id = this.itemGUID++
                    }
                    return this._updateItemsSortData(t), t
                }, l._initLayoutMode = function (t) {
                    var e = r.modes[t],
                        i = this.options[t] || {};
                    this.options[t] = e.options ? o.extend(e.options, i) : i, this.modes[t] = new e(this)
                }, l.layout = function () {
                    return !this._isLayoutInited && this._getOption("initLayout") ? void this.arrange() : void this._layout()
                }, l._layout = function () {
                    var t = this._getIsInstant();
                    this._resetLayout(), this._manageStamps(), this.layoutItems(this.filteredItems, t), this._isLayoutInited = !0
                }, l.arrange = function (t) {
                    this.option(t), this._getIsInstant();
                    var e = this._filter(this.items);
                    this.filteredItems = e.matches, this._bindArrangeComplete(), this._isInstant ? this._noTransition(this._hideReveal, [e]) : this._hideReveal(e), this._sort(), this._layout()
                }, l._init = l.arrange, l._hideReveal = function (t) {
                    this.reveal(t.needReveal), this.hide(t.needHide)
                }, l._getIsInstant = function () {
                    var t = this._getOption("layoutInstant"),
                        e = void 0 !== t ? t : !this._isLayoutInited;
                    return this._isInstant = e, e
                }, l._bindArrangeComplete = function () {
                    function t() {
                        e && i && n && o.dispatchEvent("arrangeComplete", null, [o.filteredItems])
                    }
                    var e, i, n, o = this;
                    this.once("layoutComplete", function () {
                        e = !0, t()
                    }), this.once("hideComplete", function () {
                        i = !0, t()
                    }), this.once("revealComplete", function () {
                        n = !0, t()
                    })
                }, l._filter = function (t) {
                    var e = this.options.filter;
                    e = e || "*";
                    for (var i = [], n = [], o = [], a = this._getFilterTest(e), r = 0; r < t.length; r++) {
                        var s = t[r];
                        if (!s.isIgnored) {
                            var d = a(s);
                            d && i.push(s), d && s.isHidden ? n.push(s) : d || s.isHidden || o.push(s)
                        }
                    }
                    return {
                        matches: i,
                        needReveal: n,
                        needHide: o
                    }
                }, l._getFilterTest = function (t) {
                    return d && this.options.isJQueryFiltering ? function (e) {
                        return d(e.element).is(t)
                    } : "function" == typeof t ? function (e) {
                        return t(e.element)
                    } : function (e) {
                        return n(e.element, t)
                    }
                }, l.updateSortData = function (t) {
                    var e;
                    t ? (t = o.makeArray(t), e = this.getItems(t)) : e = this.items, this._getSorters(), this._updateItemsSortData(e)
                }, l._getSorters = function () {
                    var t = this.options.getSortData;
                    for (var e in t) {
                        var i = t[e];
                        this._sorters[e] = h(i)
                    }
                }, l._updateItemsSortData = function (t) {
                    for (var e = t && t.length, i = 0; e && e > i; i++) {
                        t[i].updateSortData()
                    }
                };
                var h = function () {
                    function t(t) {
                        if ("string" != typeof t) return t;
                        var i = c(t).split(" "),
                            n = i[0],
                            o = n.match(/^\[(.+)\]$/),
                            a = o && o[1],
                            r = e(a, n),
                            s = u.sortDataParsers[i[1]];
                        return t = s ? function (t) {
                            return t && s(r(t))
                        } : function (t) {
                            return t && r(t)
                        }
                    }

                    function e(t, e) {
                        return t ? function (e) {
                            return e.getAttribute(t)
                        } : function (t) {
                            var i = t.querySelector(e);
                            return i && i.textContent
                        }
                    }
                    return t
                }();
                u.sortDataParsers = {
                    parseInt: function (t) {
                        function e(e) {
                            return t.apply(this, arguments)
                        }
                        return e.toString = function () {
                            return t.toString()
                        }, e
                    }(function (t) {
                        return parseInt(t, 10)
                    }),
                    parseFloat: function (t) {
                        function e(e) {
                            return t.apply(this, arguments)
                        }
                        return e.toString = function () {
                            return t.toString()
                        }, e
                    }(function (t) {
                        return parseFloat(t)
                    })
                }, l._sort = function () {
                    var t = this.options.sortBy;
                    if (t) {
                        var e = [].concat.apply(t, this.sortHistory),
                            i = s(e, this.options.sortAscending);
                        this.filteredItems.sort(i), t != this.sortHistory[0] && this.sortHistory.unshift(t)
                    }
                }, l._mode = function () {
                    var t = this.options.layoutMode,
                        e = this.modes[t];
                    if (!e) throw new Error("No layout mode: " + t);
                    return e.options = this.options[t], e
                }, l._resetLayout = function () {
                    e.prototype._resetLayout.call(this), this._mode()._resetLayout()
                }, l._getItemLayoutPosition = function (t) {
                    return this._mode()._getItemLayoutPosition(t)
                }, l._manageStamp = function (t) {
                    this._mode()._manageStamp(t)
                }, l._getContainerSize = function () {
                    return this._mode()._getContainerSize()
                }, l.needsResizeLayout = function () {
                    return this._mode().needsResizeLayout()
                }, l.appended = function (t) {
                    var e = this.addItems(t);
                    if (e.length) {
                        var i = this._filterRevealAdded(e);
                        this.filteredItems = this.filteredItems.concat(i)
                    }
                }, l.prepended = function (t) {
                    var e = this._itemize(t);
                    if (e.length) {
                        this._resetLayout(), this._manageStamps();
                        var i = this._filterRevealAdded(e);
                        this.layoutItems(this.filteredItems), this.filteredItems = i.concat(this.filteredItems), this.items = e.concat(this.items)
                    }
                }, l._filterRevealAdded = function (t) {
                    var e = this._filter(t);
                    return this.hide(e.needHide), this.reveal(e.matches), this.layoutItems(e.matches, !0), e.matches
                }, l.insert = function (t) {
                    var e = this.addItems(t);
                    if (e.length) {
                        var i, n, o = e.length;
                        for (i = 0; o > i; i++) n = e[i], this.element.appendChild(n.element);
                        var a = this._filter(e).matches;
                        for (i = 0; o > i; i++) e[i].isLayoutInstant = !0;
                        for (this.arrange(), i = 0; o > i; i++) delete e[i].isLayoutInstant;
                        this.reveal(a)
                    }
                };
                var f = l.remove;
                return l.remove = function (t) {
                    t = o.makeArray(t);
                    var e = this.getItems(t);
                    f.call(this, t);
                    for (var i = e && e.length, n = 0; i && i > n; n++) {
                        var a = e[n];
                        o.removeFrom(this.filteredItems, a)
                    }
                }, l.shuffle = function () {
                    for (var t = 0; t < this.items.length; t++) {
                        this.items[t].sortData.random = Math.random()
                    }
                    this.options.sortBy = "random", this._sort(), this._layout()
                }, l._noTransition = function (t, e) {
                    var i = this.options.transitionDuration;
                    this.options.transitionDuration = 0;
                    var n = t.apply(this, e);
                    return this.options.transitionDuration = i, n
                }, l.getFilteredItemElements = function () {
                    return this.filteredItems.map(function (t) {
                        return t.element
                    })
                }, u
            })
    },
    function (t, e) {
        var i = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) {
            return typeof t
        } : function (t) {
            return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t
        },
            n = function (t, e, n) {
                "use strict";

                function o(e) {
                    e = void 0 === e ? t : e, s.documentReady.concat(s.documentReadyDeferred).forEach(function (t) {
                        t(e)
                    })
                }

                function a(e) {
                    e = "object" == (void 0 === e ? "undefined" : i(e)) ? t : e, s.windowLoad.concat(s.windowLoadDeferred).forEach(function (t) {
                        t(e)
                    })
                }
                var r = {},
                    s = {
                        documentReady: [],
                        documentReadyDeferred: [],
                        windowLoad: [],
                        windowLoadDeferred: []
                    };
                return t(n).ready(o), t(e).on("load", a), r.setContext = function (e) {
                    var i = t;
                    return void 0 !== e ? function (i) {
                        return t(e).find(i)
                    } : i
                }, r.components = s, r.documentReady = o, r.windowLoad = a, r
            }(jQuery, window, document);
        n = function (t, e, i, n) {
            "use strict";
            return t.util = {}, t.util.requestAnimationFrame = i.requestAnimationFrame || i.mozRequestAnimationFrame || i.webkitRequestAnimationFrame || i.msRequestAnimationFrame, t.util.documentReady = function (t) {
                var e = new Date,
                    i = e.getFullYear();
                t(".update-year").text(i)
            }, t.util.getURLParameter = function (t) {
                return decodeURIComponent((new RegExp("[?|&]" + t + "=([^&;]+?)(&|#|;|$)").exec(location.search) || [void 0, ""])[1].replace(/\+/g, "%20")) || null
            }, t.util.capitaliseFirstLetter = function (t) {
                return t.charAt(0).toUpperCase() + t.slice(1)
            }, t.util.slugify = function (t, e) {
                return void 0 !== e ? t.replace(/ +/g, "") : t.toLowerCase().replace(/[\~\!\@\#\$\%\^\&\*\(\)\-\_\=\+\]\[\}\{\'\"\;\\\:\?\/\>\<\.\,]+/g, "").replace(/ +/g, "-")
            }, t.util.sortChildrenByText = function (t, i) {
                var n = e(t),
                    o = n.children().get(),
                    a = -1,
                    r = 1;
                void 0 !== i && (a = 1, r = -1), o.sort(function (t, i) {
                    var n = e(t).text(),
                        o = e(i).text();
                    return o > n ? a : n > o ? r : 0
                }), n.empty(), e(o).each(function (t, e) {
                    n.append(e)
                })
            }, t.util.idleSrc = function (t, i) {
                i = void 0 !== i ? i : "", (t.is(i + "[src]") ? t : t.find(i + "[src]")).each(function (t, i) {
                    i = e(i);
                    var n = i.attr("src");
                    void 0 === i.attr("data-src") && i.attr("data-src", n), i.attr("src", "")
                })
            }, t.util.activateIdleSrc = function (t, i) {
                i = void 0 !== i ? i : "", (t.is(i + "[src]") ? t : t.find(i + "[src]")).each(function (t, i) {
                    i = e(i);
                    var n = i.attr("data-src");
                    void 0 !== n && i.attr("src", n)
                })
            }, t.util.pauseVideo = function (t) {
                (t.is("video") ? t : t.find("video")).each(function (t, i) {
                    e(i).get(0).pause()
                })
            }, t.util.parsePixels = function (t) {
                var n, o = e(i).height();
                return /^[1-9]{1}[0-9]*[p][x]$/.test(t) ? parseInt(t.replace("px", ""), 10) : /^[1-9]{1}[0-9]*[v][h]$/.test(t) ? (n = parseInt(t.replace("vh", ""), 10), o * (n / 100)) : -1
            }, t.components.documentReady.push(t.util.documentReady), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            return t.window = {}, t.window.height = e(i).height(), t.window.width = e(i).width(), e(i).on("resize", function () {
                t.window.height = e(i).height(), t.window.width = e(i).width()
            }), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".accordion__title").on("click", function () {
                    var e = t(this).closest(".accordion"),
                        i = t(this).closest("li");
                    if (i.hasClass("active")) i.removeClass("active");
                    else if (e.hasClass("accordion--oneopen")) {
                        var n = e.find("li.active");
                        n.removeClass("active"), i.addClass("active")
                    } else i.addClass("active")
                }), t(".accordion").each(function () {
                    var e = t(this),
                        i = e.outerHeight(!0);
                    e.css("min-height", i)
                })
            };
            return t.accordions = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".background-image-holder").each(function () {
                    var e = t(this).children("img").attr("src");
                    t(this).css("background", 'url("' + e + '")').css("background-position", "initial").css("opacity", "1")
                })
            };
            return t.backgrounds = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t('.nav-container .bar[data-scroll-class*="fixed"]:not(.bar--absolute)').each(function () {
                    var e = t(this),
                        i = e.outerHeight(!0);
                    e.closest(".nav-container").css("min-height", i)
                })
            };
            return t.bars = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            return t.cookies = {
                getItem: function (t) {
                    return t ? decodeURIComponent(n.cookie.replace(new RegExp("(?:(?:^|.*;)\\s*" + encodeURIComponent(t).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=\\s*([^;]*).*$)|^.*$"), "$1")) || null : null
                },
                setItem: function (t, e, i, o, a, r) {
                    if (!t || /^(?:expires|max\-age|path|domain|secure)$/i.test(t)) return !1;
                    var s = "";
                    if (i) switch (i.constructor) {
                        case Number:
                            s = i === 1 / 0 ? "; expires=Fri, 31 Dec 9999 23:59:59 GMT" : "; max-age=" + i;
                            break;
                        case String:
                            s = "; expires=" + i;
                            break;
                        case Date:
                            s = "; expires=" + i.toUTCString()
                    }
                    return n.cookie = encodeURIComponent(t) + "=" + encodeURIComponent(e) + s + (a ? "; domain=" + a : "") + (o ? "; path=" + o : "") + (r ? "; secure" : ""), !0
                },
                removeItem: function (t, e, i) {
                    return !!this.hasItem(t) && (n.cookie = encodeURIComponent(t) + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT" + (i ? "; domain=" + i : "") + (e ? "; path=" + e : ""), !0)
                },
                hasItem: function (t) {
                    return !!t && new RegExp("(?:^|;\\s*)" + encodeURIComponent(t).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=").test(n.cookie)
                },
                keys: function () {
                    for (var t = n.cookie.replace(/((?:^|\s*;)[^\=]+)(?=;|$)|^\s*|\s*(?:\=[^;]*)?(?:\1|$)/g, "").split(/\s*(?:\=[^;]*)?;\s*/), e = t.length, i = 0; e > i; i++) t[i] = decodeURIComponent(t[i]);
                    return t
                }
            }, t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".countdown[data-date]").each(function () {
                    var e, i = t(this),
                        n = i.attr("data-date"),
                        o = "days";
                    void 0 !== i.attr("data-date-fallback") && (e = i.attr("data-date-fallback")), void 0 !== i.attr("data-days-text") && (o = i.attr("data-days-text")), i.countdown(n, function (t) {
                        t.elapsed ? i.text(e) : i.text(t.strftime("%D " + o + " %H:%M:%S"))
                    })
                })
            };
            return t.countdown = {
                documentReady: o
            }, t.components.documentReadyDeferred.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".datepicker").length && t(".datepicker").pickadate()
            };
            return t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";

            function o(t) {
                t(".dropdown__container").each(function () {
                    var t = jQuery(this),
                        e = t.offset().left,
                        i = jQuery(".containerMeasure").offset().left,
                        n = t.closest(".dropdown").offset().left,
                        o = "";
                    t.css("left", -e + i), t.find('.dropdown__content:not([class*="md-12"])').length && (o = t.find(".dropdown__content"), o.css("left", n - i))
                }), t(".dropdown__content").each(function () {
                    var t = jQuery(this),
                        e = t.offset().left,
                        n = t.outerWidth(!0),
                        o = e + n,
                        a = jQuery(i).outerWidth(!0),
                        r = jQuery(".containerMeasure").outerWidth() - n;
                    o > a && t.css("left", r)
                })
            }

            function a(t) {
                var e = jQuery(i).width();
                t(".dropdown__container").each(function () {
                    var t = jQuery(this),
                        i = e - (t.offset().left + t.outerWidth(!0)),
                        n = jQuery(".containerMeasure").offset().left,
                        o = e - (t.closest(".dropdown").offset().left + t.closest(".dropdown").outerWidth(!0)),
                        a = "";
                    t.css("right", -i + n), t.find('.dropdown__content:not([class*="md-12"])').length && (a = t.find(".dropdown__content"), a.css("right", o - n))
                }), t(".dropdown__content").each(function () {
                    var t = jQuery(this),
                        n = e - (t.offset().left + t.outerWidth(!0)),
                        o = t.outerWidth(!0),
                        a = n + o,
                        r = jQuery(i).outerWidth(!0),
                        s = jQuery(".containerMeasure").outerWidth() - o;
                    a > r && t.css("right", s)
                })
            }
            t.dropdowns = {}, t.dropdowns.done = !1;
            var r = function (e) {
                var r = !1;
                e('html[dir="rtl"]').length && (r = !0), t.dropdowns.done || (jQuery(n).on("click", "body:not(.dropdowns--hover) .dropdown:not(.dropdown--hover), body.dropdowns--hover .dropdown.dropdown--click", function (t) {
                    var i = jQuery(this);
                    jQuery(t.target).is(".dropdown--active > .dropdown__trigger") ? (i.siblings().removeClass("dropdown--active").find(".dropdown").removeClass("dropdown--active"), i.toggleClass("dropdown--active")) : (e(".dropdown--active").removeClass("dropdown--active"), i.addClass("dropdown--active"))
                }), jQuery(n).on("click touchstart", "body", function (t) {
                    jQuery(t.target).is('[class*="dropdown"], [class*="dropdown"] *') || e(".dropdown--active").removeClass("dropdown--active")
                }), jQuery("body").append('<div class="container containerMeasure" style="opacity:0;pointer-events:none;"></div>'), t.dropdowns.done = !0), !1 === r ? o(e) : a(e), jQuery(i).resize(function () { })
            };
            return t.dropdowns.documentReady = r, t.components.documentReady.push(r), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.forms = {};
            var o = function (e) {
                e(".input-checkbox").on("click", function () {
                    var t = e(this);
                    t.toggleClass("checked");
                    var i = t.find("input");
                    return !1 === i.prop("checked") ? i.prop("checked", !0) : i.prop("checked", !1), !1
                }), e(".input-radio").on("click", function (t) {
                    if (!e(t.target).is("input")) {
                        var i = e(this),
                            n = i.find("input[type=radio]").attr("name");
                        return i.closest("form").find("[type=radio][name=" + n + "]").each(function () {
                            e(this).parent().removeClass("checked")
                        }), i.addClass("checked").find("input").click().prop("checked", !0), !1
                    }
                }), e(".input-number__controls > span").on("click", function () {
                    var t = jQuery(this),
                        e = t.closest(".input-number"),
                        i = e.find('input[type="number"]'),
                        n = i.attr("max"),
                        o = i.attr("min"),
                        a = 1,
                        r = parseInt(i.attr("value"), 10);
                    e.is("[data-step]") && (a = parseInt(e.attr("data-step"), 10)), t.hasClass("input-number__increase") ? n >= r + a && i.attr("value", r + a) : r - a >= o && i.attr("value", r - a)
                }), e(".input-file .btn").on("click", function () {
                    return e(this).siblings("input").trigger("click"), !1
                }), e('form.form-email, form[action*="list-manage.com"], form[action*="createsend.com"]').attr("novalidate", !0).off("submit").on("submit", t.forms.submit), e(n).on("change, input, paste, keyup", ".attempted-submit .field-error", function () {
                    e(this).removeClass("field-error")
                })
            };
            return t.forms.documentReady = o, t.forms.submit = function (n) {
                n.preventDefault ? n.preventDefault() : n.returnValue = !1;
                var o, a, r, s, d, c = e("body"),
                    u = e(n.target).closest("form"),
                    l = void 0 !== u.attr("action") ? u.attr("action") : "",
                    h = u.find('button[type="submit"], input[type="submit"]'),
                    f = 0,
                    p = u.attr("original-error");
                if (c.find(".form-error, .form-success").remove(), h.attr("data-text", h.text()), s = u.attr("data-error") ? u.attr("data-error") : "Please fill all fields correctly", d = u.attr("data-success") ? u.attr("data-success") : "Thanks, we'll be in touch shortly", c.append('<div class="form-error" style="display: none;">' + s + "</div>"), c.append('<div class="form-success" style="display: none;">' + d + "</div>"), a = c.find(".form-error"), r = c.find(".form-success"), u.addClass("attempted-submit"), -1 !== l.indexOf("createsend.com") || -1 !== l.indexOf("list-manage.com"))
                    if (void 0 !== p && !1 !== p && a.html(p), 1 !== t.forms.validateFields(u)) {
                        u.removeClass("attempted-submit"), a.fadeOut(200), h.addClass("btn--loading");
                        try {
                            e.ajax({
                                url: u.attr("action"),
                                crossDomain: !0,
                                data: u.serialize(),
                                method: "GET",
                                cache: !1,
                                dataType: "json",
                                contentType: "application/json; charset=utf-8",
                                success: function (e) {
                                    "success" !== e.result && 200 !== e.Status ? (a.attr("original-error", a.text()), a.html(e.msg).stop(!0).fadeIn(1e3), r.stop(!0).fadeOut(1e3), h.removeClass("btn--loading")) : (h.removeClass("btn--loading"), o = u.attr("data-success-redirect"), void 0 !== o && !1 !== o && "" !== o ? i.location = o : (t.forms.resetForm(u), t.forms.showFormSuccess(r, a, 1e3, 5e3, 500)))
                                }
                            })
                        } catch (e) {
                            a.attr("original-error", a.text()), a.html(e.message), t.forms.showFormError(r, a, 1e3, 5e3, 500), h.removeClass("btn--loading")
                        }
                    } else t.forms.showFormError(r, a, 1e3, 5e3, 500);
                else void 0 !== p && !1 !== p && a.text(p), f = t.forms.validateFields(u), 1 === f ? t.forms.showFormError(r, a, 1e3, 5e3, 500) : (u.removeClass("attempted-submit"), a.fadeOut(200), h.addClass("btn--loading"), jQuery.ajax({
                    type: "POST",
                    url: "http://mailform.mediumra.re/stack/mail.php",
                    data: u.serialize() + "&url=" + i.location.href,
                    success: function (n) {
                        h.removeClass("btn--loading"), e.isNumeric(n) ? parseInt(n, 10) > 0 && (o = u.attr("data-success-redirect"), void 0 !== o && !1 !== o && "" !== o && (i.location = o), t.forms.resetForm(u), t.forms.showFormSuccess(r, a, 1e3, 5e3, 500)) : (a.attr("original-error", a.text()), a.text(n).stop(!0).fadeIn(1e3), r.stop(!0).fadeOut(1e3))
                    },
                    error: function (t, e, i) {
                        a.attr("original-error", a.text()), a.text(i).stop(!0).fadeIn(1e3), r.stop(!0).fadeOut(1e3), h.removeClass("btn--loading")
                    }
                }));
                return !1
            }, t.forms.validateFields = function (t) {
                var i, n = e(n),
                    o = !1;
                if (t = e(t), t.find('.validate-required[type="checkbox"]').each(function () {
                    var t = e(this);
                    e('[name="' + e(this).attr("name") + '"]:checked').length || (o = 1, i = e(this).attr("data-name") || "check", t.parent().addClass("field-error"))
                }), t.find(".validate-required, .required, [required]").not('input[type="checkbox"]').each(function () {
                    "" === e(this).val() ? (e(this).addClass("field-error"), o = 1) : e(this).removeClass("field-error")
                }), t.find('.validate-email, .email, [name*="cm-"][type="email"]').each(function () {
                    /(.+)@(.+){2,}\.(.+){2,}/.test(e(this).val()) ? e(this).removeClass("field-error") : (e(this).addClass("field-error"), o = 1)
                }), t.find(".validate-number-dash").each(function () {
                    /^[0-9][0-9-]+[0-9]$/.test(e(this).val()) ? e(this).removeClass("field-error") : (e(this).addClass("field-error"), o = 1)
                }), t.find(".field-error").length) {
                    var a = e(t).find(".field-error:first");
                    a.length && e("html, body").stop(!0).animate({
                        scrollTop: a.offset().top - 100
                    }, 1200, function () {
                        a.focus()
                    })
                } else n.find(".form-error").fadeOut(1e3);
                return o
            }, t.forms.showFormSuccess = function (t, e, i, n, o) {
                t.stop(!0).fadeIn(i), e.stop(!0).fadeOut(i), setTimeout(function () {
                    t.stop(!0).fadeOut(o)
                }, n)
            }, t.forms.showFormError = function (t, e, i, n, o) {
                e.stop(!0).fadeIn(i), t.stop(!0).fadeOut(i), setTimeout(function () {
                    e.stop(!0).fadeOut(o)
                }, n)
            }, t.forms.resetForm = function (t) {
                t = e(t), t.get(0).reset(), t.find(".input-radio, .input-checkbox").removeClass("checked")
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t("[data-gradient-bg]").each(function (e, i) {
                    var n, o, a = t(this),
                        r = "granim-" + e,
                        s = a.attr("data-gradient-bg"),
                        d = [],
                        c = [];
                    if (a.prepend('<canvas id="' + r + '"></canvas>'), !0 === /^(#[0-9|a-f|A-F]{6}){1}([ ]*,[ ]*#[0-9|a-f|A-F]{6})*$/.test(s))
                        for (s = s.replace(" ", ""), s = s.split(","), n = s.length, n % 2 != 0 && s.push(s[n - 1]), o = 0; n / 2 > o; o++) c = [], c.push(s.shift()), c.push(s.shift()), d.push(c);
                    t(this), new Granim({
                        element: "#" + r,
                        name: "basic-gradient",
                        direction: "left-right",
                        opacity: [1, 1],
                        isPausedWhenNotInView: !0,
                        states: {
                            "default-state": {
                                gradients: d
                            }
                        }
                    })
                })
            };
            return t.granim = {
                documentReady: o
            }, t.components.documentReadyDeferred.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                if (t(".instafeed").length) {
                    var e, i, n = "4079540202.b9b1d8a.1d13c245c68d4a17bfbff87919aaeb14",
                        o = "b9b1d8ae049d4153b24a6332f0088686";
                    t(".instafeed[data-access-token][data-client-id]").length && (e = t(".instafeed[data-access-token][data-client-id]").first().attr("data-access-token"), i = t(".instafeed[data-access-token][data-client-id]").first().attr("data-client-id"), "" !== e && (n = e), "" !== i && (o = i)), jQuery.fn.spectragram.accessData = {
                        accessToken: n,
                        clientID: o
                    }
                }
                t(".instafeed").each(function () {
                    var e = t(this),
                        i = e.attr("data-user-name"),
                        n = 12;
                    void 0 !== e.attr("data-amount") && (n = parseInt(e.attr("data-amount"), 10)), e.append("<ul></ul>"), e.children("ul").spectragram("getUserFeed", {
                        query: i,
                        max: n
                    })
                })
            };
            return t.instagram = {
                documentReady: o
            }, t.components.documentReadyDeferred.push(o), t
        }(n, jQuery, window, document), n = function (t, e, n, o) {
            "use strict";
            t.maps = {};
            var a = function (e) {
                e(".map-holder").on("click", function () {
                    e(this).addClass("interact")
                }).removeClass("interact");
                var i = e(".map-container[data-maps-api-key]");
                i.length && (i.addClass("gmaps-active"), t.maps.initAPI(e), t.maps.init())
            };
            return t.maps.documentReady = a, t.maps.initAPI = function (t) {
                if (o.querySelector("[data-maps-api-key]") && !o.querySelector(".gMapsAPI") && t("[data-maps-api-key]").length) {
                    var e = o.createElement("script"),
                        i = t("[data-maps-api-key]:first").attr("data-maps-api-key");
                    "" !== (i = void 0 !== i ? i : "") && (e.type = "text/javascript", e.src = "https://maps.googleapis.com/maps/api/js?key=" + i + "&callback=mr.maps.init", e.className = "gMapsAPI", o.body.appendChild(e))
                }
            }, t.maps.init = function () {
                void 0 !== n.google && void 0 !== n.google.maps && jQuery(".gmaps-active").each(function () {
                    var t, e = this,
                        a = jQuery(this),
                        r = void 0 !== a.attr("data-map-style") && a.attr("data-map-style"),
                        s = JSON.parse(r) || [{
                            featureType: "landscape",
                            stylers: [{
                                saturation: -100
                            }, {
                                lightness: 65
                            }, {
                                visibility: "on"
                            }]
                        }, {
                            featureType: "poi",
                            stylers: [{
                                saturation: -100
                            }, {
                                lightness: 51
                            }, {
                                visibility: "simplified"
                            }]
                        }, {
                            featureType: "road.highway",
                            stylers: [{
                                saturation: -100
                            }, {
                                visibility: "simplified"
                            }]
                        }, {
                            featureType: "road.arterial",
                            stylers: [{
                                saturation: -100
                            }, {
                                lightness: 30
                            }, {
                                visibility: "on"
                            }]
                        }, {
                            featureType: "road.local",
                            stylers: [{
                                saturation: -100
                            }, {
                                lightness: 40
                            }, {
                                visibility: "on"
                            }]
                        }, {
                            featureType: "transit",
                            stylers: [{
                                saturation: -100
                            }, {
                                visibility: "simplified"
                            }]
                        }, {
                            featureType: "administrative.province",
                            stylers: [{
                                visibility: "off"
                            }]
                        }, {
                            featureType: "water",
                            elementType: "labels",
                            stylers: [{
                                visibility: "on"
                            }, {
                                lightness: -25
                            }, {
                                saturation: -100
                            }]
                        }, {
                            featureType: "water",
                            elementType: "geometry",
                            stylers: [{
                                hue: "#ffff00"
                            }, {
                                lightness: -25
                            }, {
                                saturation: -97
                            }]
                        }],
                        d = void 0 !== a.attr("data-map-zoom") && "" !== a.attr("data-map-zoom") ? 1 * a.attr("data-map-zoom") : 17,
                        c = void 0 !== a.attr("data-latlong") && a.attr("data-latlong"),
                        u = !!c && 1 * c.substr(0, c.indexOf(",")),
                        l = !!c && 1 * c.substr(c.indexOf(",") + 1),
                        h = new google.maps.Geocoder,
                        f = void 0 !== a.attr("data-address") ? a.attr("data-address").split(";") : [""],
                        p = void 0 !== a.attr("data-marker-image") ? a.attr("data-marker-image") : "img/mapmarker.png",
                        m = "We Are Here",
                        y = jQuery(o).width() > 766,
                        v = {
                            draggable: y,
                            scrollwheel: !1,
                            zoom: d,
                            disableDefaultUI: !0,
                            styles: s
                        };
                    void 0 !== a.attr("data-marker-title") && "" !== a.attr("data-marker-title") && (m = a.attr("data-marker-title")), void 0 !== f && "" !== f[0] ? h.geocode({
                        address: f[0].replace("[nomarker]", "")
                    }, function (t, o) {
                        if (o === google.maps.GeocoderStatus.OK) {
                            var a = new google.maps.Map(e, v);
                            a.setCenter(t[0].geometry.location), f.forEach(function (t) {
                                var e;
                                if (p = {
                                    url: void 0 === n.mr_variant ? "object" != (void 0 === p ? "undefined" : i(p)) ? p : p.url : "../img/mapmarker.png",
                                    scaledSize: new google.maps.Size(50, 50)
                                }, /(\-?\d+(\.\d+)?),\s*(\-?\d+(\.\d+)?)/.test(t)) var o = t.split(","),
                                    r = new google.maps.Marker({
                                        position: {
                                            lat: 1 * o[0],
                                            lng: 1 * o[1]
                                        },
                                        map: a,
                                        icon: p,
                                        title: m,
                                        optimised: !1
                                    });
                                else t.indexOf("[nomarker]") < 0 && (e = new google.maps.Geocoder, e.geocode({
                                    address: t.replace("[nomarker]", "")
                                }, function (t, e) {
                                    e === google.maps.GeocoderStatus.OK && (r = new google.maps.Marker({
                                        map: a,
                                        icon: p,
                                        title: m,
                                        position: t[0].geometry.location,
                                        optimised: !1
                                    }))
                                }))
                            })
                        }
                    }) : void 0 !== u && "" !== u && !1 !== u && void 0 !== l && "" !== l && !1 !== l && (v.center = {
                        lat: u,
                        lng: l
                    }, t = new google.maps.Map(a, v), new google.maps.Marker({
                        position: {
                            lat: u,
                            lng: l
                        },
                        map: t,
                        icon: p,
                        title: m
                    }))
                })
            }, t.components.documentReady.push(a), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (e) {
                e(".masonry").each(function () {
                    var i, n = e(this),
                        o = n.find(".masonry__container"),
                        a = n.find(".masonry__filters"),
                        r = void 0 !== a.attr("data-filter-all-text") ? a.attr("data-filter-all-text") : "All";
                    o.find(".masonry__item[data-masonry-filter]").length && (a.append("<ul></ul>"), i = a.find("> ul"), o.find(".masonry__item[data-masonry-filter]").each(function () {
                        var n = e(this),
                            o = n.attr("data-masonry-filter"),
                            a = [];
                        void 0 !== o && "" !== o && (a = o.split(",")), jQuery(a).each(function (e, o) {
                            var a = t.util.slugify(o);
                            n.addClass("filter-" + a), i.find('[data-masonry-filter="' + a + '"]').length || i.append('<li data-masonry-filter="' + a + '">' + o + "</li>")
                        })
                    }), t.util.sortChildrenByText(e(this).find(".masonry__filters ul")), i.prepend('<li class="active" data-masonry-filter="*">' + r + "</li>"))
                }), e(n).on("click touchstart", ".masonry__filters li", function () {
                    var t = e(this),
                        i = t.closest(".masonry").find(".masonry__container"),
                        n = "*";
                    "*" !== t.attr("data-masonry-filter") && (n = ".filter-" + t.attr("data-masonry-filter")), t.siblings("li").removeClass("active"), t.addClass("active"), i.removeClass("masonry--animate"), i.on("layoutComplete", function () {
                        e(this).addClass("masonry--active"), "undefined" != typeof mr_parallax && setTimeout(function () {
                            mr_parallax.profileParallaxElements()
                        }, 100)
                    }), i.isotope({
                        filter: n
                    })
                })
            },
                a = function () {
                    e(".masonry").each(function () {
                        var t = e(this).find(".masonry__container"),
                            i = e(this),
                            n = "*";
                        i.is("[data-default-filter]") && (n = i.attr("data-default-filter").toLowerCase(), n = ".filter-" + n, i.find("li[data-masonry-filter]").removeClass("active"), i.find('li[data-masonry-filter="' + i.attr("data-default-filter").toLowerCase() + '"]').addClass("active")), t.on("layoutComplete", function () {
                            t.addClass("masonry--active"), "undefined" != typeof mr_parallax && setTimeout(function () {
                                mr_parallax.profileParallaxElements()
                            }, 100)
                        }), t.isotope({
                            itemSelector: ".masonry__item",
                            filter: n,
                            masonry: {
                                columnWidth: ".masonry__item"
                            }
                        })
                    })
                };
            return t.masonry = {
                documentReady: o,
                windowLoad: a
            }, t.components.documentReady.push(o), t.components.windowLoad.push(a), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.modals = {};
            var o = function (e) {
                var o = '<div class="all-page-modals"></div>',
                    a = e("div.main-container");
                if (a.length ? (jQuery(o).insertAfter(a), t.modals.allModalsContainer = e("div.all-page-modals")) : (jQuery("body").append(o), t.modals.allModalsContainer = jQuery("body div.all-page-modals")), e(".modal-container").each(function () {
                    var n = e(this),
                        o = (e(i), n.find(".modal-content"));
                    if (n.find(".modal-close").length || n.find(".modal-content").append('<div class="modal-close modal-close-cross"></div>'), void 0 !== o.attr("data-width")) {
                        var a = 1 * o.attr("data-width").substr(0, o.attr("data-width").indexOf("%"));
                        o.css("width", a + "%")
                    }
                    if (void 0 !== o.attr("data-height")) {
                        var r = 1 * o.attr("data-height").substr(0, o.attr("data-height").indexOf("%"));
                        o.css("height", r + "%")
                    }
                    t.util.idleSrc(n, "iframe")
                }), e(".modal-instance").each(function (i) {
                    var n = e(this),
                        o = n.find(".modal-container"),
                        a = (n.find(".modal-content"), n.find(".modal-trigger"));
                    a.attr("data-modal-index", i), o.attr("data-modal-index", i), void 0 !== o.attr("data-modal-id") && a.attr("data-modal-id", o.attr("data-modal-id")), o = o.detach(), t.modals.allModalsContainer.append(o)
                }), e(".modal-trigger").on("click", function () {
                    var i, n, o = e(this);
                    return void 0 !== o.attr("data-modal-id") ? (i = o.attr("data-modal-id"), n = t.modals.allModalsContainer.find('.modal-container[data-modal-id="' + i + '"]')) : (i = e(this).attr("data-modal-index"), n = t.modals.allModalsContainer.find('.modal-container[data-modal-index="' + i + '"]')), t.util.activateIdleSrc(n, "iframe"), t.modals.autoplayVideo(n), t.modals.showModal(n), !1
                }), jQuery(n).on("click", ".modal-close", t.modals.closeActiveModal), jQuery(n).keyup(function (e) {
                    27 === e.keyCode && t.modals.closeActiveModal()
                }), e(".modal-container").on("click", function (e) {
                    e.target === this && t.modals.closeActiveModal()
                }), e(".modal-container[data-autoshow]").each(function () {
                    var i = e(this),
                        n = 1 * i.attr("data-autoshow");
                    t.util.activateIdleSrc(i), t.modals.autoplayVideo(i), void 0 !== i.attr("data-cookie") ? t.cookies.hasItem(i.attr("data-cookie")) || t.modals.showModal(i, n) : t.modals.showModal(i, n)
                }), e(".modal-container[data-show-on-exit]").each(function () {
                    var i = jQuery(this),
                        o = i.attr("data-show-on-exit"),
                        a = 0;
                    i.attr("data-delay") && (a = parseInt(i.attr("data-delay"), 10) || 0), e(o).length && (i.prepend(e('<i class="ti-close close-modal">')), jQuery(n).on("mouseleave", o, function () {
                        e(".modal-active").length || (void 0 !== i.attr("data-cookie") ? t.cookies.hasItem(i.attr("data-cookie")) || t.modals.showModal(i, a) : t.modals.showModal(i, a))
                    }))
                }), 2 === i.location.href.split("#").length) {
                    var r = i.location.href.split("#").pop();
                    e('[data-modal-id="' + r + '"]').length && (t.modals.closeActiveModal(), t.modals.showModal(e('[data-modal-id="' + r + '"]')))
                }
                e(n).on("wheel mousewheel scroll", ".modal-content, .modal-content .scrollable", function (t) {
                    t.preventDefault && t.preventDefault(), t.stopPropagation && t.stopPropagation(), this.scrollTop += t.originalEvent.deltaY
                })
            };
            return t.modals.documentReady = o, t.modals.showModal = function (t, i) {
                var n = void 0 !== i ? 1 * i : 0;
                setTimeout(function () {
                    e(t).addClass("modal-active")
                }, n)
            }, t.modals.closeActiveModal = function () {
                var e = jQuery("body div.modal-active");
                t.util.idleSrc(e, "iframe"), t.util.pauseVideo(e), void 0 !== e.attr("data-cookie") && t.cookies.setItem(e.attr("data-cookie"), "true", 1 / 0), e.removeClass("modal-active")
            }, t.modals.autoplayVideo = function (t) {
                if (t.find("video[autoplay]").length) {
                    t.find("video").get(0).play()
                }
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.newsletters = {};
            var o = function (e) {
                var i, n, o, a, r, s;
                e('form[action*="createsend.com"]').each(function () {
                    i = e(this), i.attr("novalidate", "novalidate"), i.is(".form--no-placeholders") ? i.find("input[placeholder]").removeAttr("placeholder") : i.find("input:not([checkbox]):not([radio])").each(function () {
                        var t = e(this);
                        void 0 !== t.attr("placeholder") ? "" === t.attr("placeholder") && t.siblings("label").length && (t.attr("placeholder", t.siblings("label").first().text()), i.is(".form--no-labels") && t.siblings("label").first().remove()) : t.siblings("label").length && (t.attr("placeholder", t.siblings("label").first().text()), i.is(".form--no-labels") && t.siblings("label").first().remove()), t.parent().is("p") && t.unwrap()
                    }), i.find("select").wrap('<div class="input-select"></div>'), i.find('input[type="radio"]').wrap('<div class="input-radio"></div>'), i.find('input[type="checkbox"]').each(function () {
                        n = e(this), a = n.attr("id"), o = i.find("label[for=" + a + "]"), n.before('<div class="input-checkbox" data-id="' + a + '"></div>'), e('.input-checkbox[data-id="' + a + '"]').prepend(n), e('.input-checkbox[data-id="' + a + '"]').prepend(o), e('.input-checkbox[data-id="' + a + '"]').prepend('<div class="inner"></div>')
                    }), i.find('button[type="submit"]').each(function () {
                        var t = e(this);
                        t.addClass("btn"), t.parent().is("p") && t.unwrap()
                    }), i.find("[required]").attr("required", "required").addClass("validate-required"), i.addClass("form--active"), t.newsletters.prepareAjaxAction(i)
                }), e('form[action*="list-manage.com"]').each(function () {
                    i = e(this), i.attr("novalidate", "novalidate"), i.is(".form--no-placeholders") ? i.find("input[placeholder]").removeAttr("placeholder") : i.find("input:not([checkbox]):not([radio])").each(function () {
                        var t = e(this);
                        void 0 !== t.attr("placeholder") ? "" === t.attr("placeholder") && t.siblings("label").length && (t.attr("placeholder", t.siblings("label").first().text()), i.is(".form--no-labels") && t.siblings("label").first().remove()) : t.siblings("label").length && (t.attr("placeholder", t.siblings("label").first().text()), i.is(".form--no-labels") && t.siblings("label").first().remove())
                    }), i.is(".form--no-labels") && i.find("input:not([checkbox]):not([radio])").each(function () {
                        var t = e(this);
                        t.siblings("label").length && t.siblings("label").first().remove()
                    }), i.find("select").wrap('<div class="input-select"></div>'), i.find('input[type="checkbox"]').each(function () {
                        n = e(this), r = n.parent(), o = r.find("label"), n.before('<div class="input-checkbox"><div class="inner"></div></div>'), r.find(".input-checkbox").append(n), r.find(".input-checkbox").append(o)
                    }), i.find('input[type="radio"]').each(function () {
                        s = e(this), r = s.closest("li"), o = r.find("label"), s.before('<div class="input-radio"><div class="inner"></div></div>'), r.find(".input-radio").prepend(s), r.find(".input-radio").prepend(o)
                    }), i.find('input[type="submit"]').each(function () {
                        var t = e(this),
                            i = jQuery("<button/>").attr("type", "submit").attr("class", t.attr("class")).addClass("btn").text(t.attr("value"));
                        t.parent().is("div.clear") && t.unwrap(), i.insertBefore(t), t.remove()
                    }), i.find("input").each(function () {
                        var t = e(this);
                        t.hasClass("required") && t.removeClass("required").addClass("validate-required")
                    }), i.find('input[type="email"]').removeClass("email").addClass("validate-email"), i.find("#mce-responses").remove(), i.find(".mc-field-group").each(function () {
                        e(this).children().first().unwrap()
                    }), i.find("[required]").attr("required", "required").addClass("validate-required"), i.addClass("form--active"), t.newsletters.prepareAjaxAction(i)
                }), t.forms.documentReady(t.setContext("form.form--active"))
            };
            return t.newsletters.documentReady = o, t.newsletters.prepareAjaxAction = function (t) {
                var i = e(t).attr("action");
                /list-manage\.com/.test(i) && (i = i.replace("/post?", "/post-json?") + "&c=?", "//" === i.substr(0, 2) && (i = "http:" + i)), /createsend\.com/.test(i) && (i += "?callback=?"), e(t).attr("action", i)
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.notifications = {};
            var o = function (e) {
                e(".notification").each(function () {
                    var t = e(this);
                    t.find(".notification-close").length || t.append('<div class="notification-close-cross notification-close"></div>')
                }), e(".notification[data-autoshow]").each(function () {
                    var i = e(this),
                        n = parseInt(i.attr("data-autoshow"), 10);
                    void 0 !== i.attr("data-cookie") ? t.cookies.hasItem(i.attr("data-cookie")) || t.notifications.showNotification(i, n) : t.notifications.showNotification(i, n)
                }), e("[data-notification-link]:not(.notification)").on("click", function () {
                    var i = jQuery(this).attr("data-notification-link"),
                        n = e('.notification[data-notification-link="' + i + '"]');
                    return jQuery(".notification--reveal").addClass("notification--dismissed"), n.removeClass("notification--dismissed"), t.notifications.showNotification(n, 0), !1
                }), e(".notification-close").on("click", function () {
                    var e = jQuery(this);
                    return t.notifications.closeNotification(e), "#" !== e.attr("href") && void 0
                }), e(".notification .inner-link").on("click", function () {
                    var e = jQuery(this).closest(".notification").attr("data-notification-link");
                    t.notifications.closeNotification(e)
                })
            };
            return t.notifications.documentReady = o, t.notifications.showNotification = function (e, i) {
                var n = void 0 !== i ? 1 * i : 0;
                if (setTimeout(function () {
                    e.addClass("notification--reveal"), e.closest("nav").addClass("notification--reveal"), e.find("input").length && e.find("input").first().focus()
                }, n), e.is("[data-autohide]")) {
                    var o = parseInt(e.attr("data-autohide"), 10);
                    setTimeout(function () {
                        t.notifications.closeNotification(e)
                    }, o + n)
                }
            }, t.notifications.closeNotification = function (i) {
                var n = jQuery(i);
                i = n.is(".notification") ? n : n.is(".notification-close") ? n.closest(".notification") : e('.notification[data-notification-link="' + i + '"]'), i.addClass("notification--dismissed"), i.closest("nav").removeClass("notification--reveal"), void 0 !== i.attr("data-cookie") && t.cookies.setItem(i.attr("data-cookie"), "true", 1 / 0)
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                var e = t(i),
                    n = e.width(),
                    o = e.height(),
                    a = t("nav").outerHeight(!0);
                if (/Android|iPhone|iPad|iPod|BlackBerry|Windows Phone/i.test(navigator.userAgent || navigator.vendor || i.opera) && t("section").removeClass("parallax"), n > 768) {
                    var r = t(".parallax:nth-of-type(1)"),
                        s = t(".parallax:nth-of-type(1) .background-image-holder");
                    s.css("top", -a), r.outerHeight(!0) === o && s.css("height", o + a)
                }
            };
            return t.parallax = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.easypiecharts = {}, t.easypiecharts.pies = [];
            var o = function (e) {
                t.easypiecharts.init = function () {
                    t.easypiecharts.pies = [], e(".radial").each(function () {
                        var e = {},
                            i = jQuery(this);
                        e.element = i, e.value = parseInt(i.attr("data-value"), 10), e.top = i.offset().top, e.height = i.height() / 2, e.active = !1, t.easypiecharts.pies.push(e)
                    })
                }, t.easypiecharts.activate = function () {
                    t.easypiecharts.pies.forEach(function (e) {
                        Math.round(t.scroll.y + t.window.height) >= Math.round(e.top + e.height) && !1 === e.active && (e.element.data("easyPieChart").enableAnimation(), e.element.data("easyPieChart").update(e.value), e.element.addClass("radial--active"), e.active = !0)
                    })
                }, e(".radial").each(function () {
                    var t = jQuery(this),
                        e = "#000000",
                        i = 2e3,
                        n = 110,
                        o = 3;
                    void 0 !== t.attr("data-timing") && (i = 1 * t.attr("data-timing")), void 0 !== t.attr("data-color") && (e = t.attr("data-color")), void 0 !== t.attr("data-size") && (n = t.attr("data-size")), void 0 !== t.attr("data-bar-width") && (o = t.attr("data-bar-width")), t.css("height", n).css("width", n), t.easyPieChart({
                        animate: {
                            duration: i,
                            enabled: !0
                        },
                        barColor: e,
                        scaleColor: !1,
                        size: n,
                        lineWidth: o
                    }), t.data("easyPieChart").update(0)
                }), e(".radial").length && (t.easypiecharts.init(), t.easypiecharts.activate(), t.scroll.listeners.push(t.easypiecharts.activate))
            };
            return t.easypiecharts.documentReady = o, t.components.documentReadyDeferred.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            t.sliders = {}, t.sliders.draggable = !0;
            var o = function (e) {
                e(".slider").each(function (i) {
                    var n = e(this),
                        o = n.find("ul.slides");
                    o.find(">li").addClass("slide");
                    var a = o.find("li").length,
                        r = !1,
                        s = !1,
                        d = 7e3,
                        c = t.sliders.draggable;
                    r = "true" === n.attr("data-arrows"), "false" !== n.attr("data-autoplay"), s = "true" === n.attr("data-paging") && o.find("li").length > 1, n.attr("data-timing") && (d = 1 * n.attr("data-timing")), n.attr("data-children", a), 2 > a && (c = !1), e(o).flickity({
                        cellSelector: ".slide",
                        cellAlign: "left",
                        wrapAround: !0,
                        pageDots: s,
                        prevNextButtons: r,
                        autoPlay: d,
                        draggable: c,
                        imagesLoaded: !0
                    }), e(o).on("scroll.flickity", function (t, e) {
                        n.find(".is-selected").hasClass("controls--dark") ? n.addClass("controls--dark") : n.removeClass("controls--dark")
                    })
                })
            };
            return t.sliders.documentReady = o, t.components.documentReadyDeferred.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".tabs").each(function () {
                    var e = t(this);
                    e.after('<ul class="tabs-content">'), e.find("li").each(function () {
                        var e = t(this),
                            i = e.find(".tab__content").wrap("<li></li>").parent(),
                            n = i.clone(!0, !0);
                        i.remove(), e.closest(".tabs-container").find(".tabs-content").append(n)
                    })
                }), t(".tabs li").on("click", function () {
                    var e, i = t(this),
                        n = i.closest(".tabs-container"),
                        o = 1 * i.index() + 1,
                        a = n.find("> .tabs-content > li:nth-of-type(" + o + ")");
                    n.find("> .tabs > li").removeClass("active"), n.find("> .tabs-content > li").removeClass("active"), i.addClass("active"), a.addClass("active"), e = a.find("iframe"), e.length && e.attr("src", e.attr("src"))
                }), t(".tabs li.active").trigger("click")
            };
            return t.tabs = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t("[data-toggle-class]").each(function () {
                    var e = t(this),
                        i = e.attr("data-toggle-class").split("|");
                    t(i).each(function () {
                        var i = e,
                            n = [],
                            o = "",
                            a = "",
                            n = this.split(";");
                        2 === n.length && (a = n[0], o = n[1], t(i).on("click", function () {
                            return i.hasClass("toggled-class") || i.toggleClass("toggled-class"), t(a).toggleClass(o), !1
                        }))
                    })
                })
            };
            return t.toggleClass = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document), n = function (t, e, i, n) {
            "use strict";
            var o = function (t) {
                t(".typed-text").each(function () {
                    var e = t(this),
                        i = e.attr("data-typed-strings") ? e.attr("data-typed-strings").split(",") : [];
                    t(e).typed({
                        strings: i,
                        typeSpeed: 100,
                        loop: !0,
                        showCursor: !1
                    })
                })
            };
            return t.typed = {
                documentReady: o
            }, t.components.documentReady.push(o), t
        }(n, jQuery, window, document)
    },
    function (t, e) {
        var i = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) {
            return typeof t
        } : function (t) {
            return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t
        };
        ! function (t) {
            "use strict";
            var e = function (e, i) {
                this.el = t(e), this.options = t.extend({}, t.fn.typed.defaults, i), this.isInput = this.el.is("input"), this.attr = this.options.attr, this.showCursor = !this.isInput && this.options.showCursor, this.elContent = this.attr ? this.el.attr(this.attr) : this.el.text(), this.contentType = this.options.contentType, this.typeSpeed = this.options.typeSpeed, this.startDelay = this.options.startDelay, this.backSpeed = this.options.backSpeed, this.backDelay = this.options.backDelay, this.stringsElement = this.options.stringsElement, this.strings = this.options.strings, this.strPos = 0, this.arrayPos = 0, this.stopNum = 0, this.loop = this.options.loop, this.loopCount = this.options.loopCount, this.curLoop = 0, this.stop = !1, this.cursorChar = this.options.cursorChar, this.shuffle = this.options.shuffle, this.sequence = [], this.build()
            };
            e.prototype = {
                constructor: e,
                init: function () {
                    var t = this;
                    t.timeout = setTimeout(function () {
                        for (var e = 0; e < t.strings.length; ++e) t.sequence[e] = e;
                        t.shuffle && (t.sequence = t.shuffleArray(t.sequence)), t.typewrite(t.strings[t.sequence[t.arrayPos]], t.strPos)
                    }, t.startDelay)
                },
                build: function () {
                    var e = this;
                    if (!0 === this.showCursor && (this.cursor = t('<span class="typed-cursor">' + this.cursorChar + "</span>"), this.el.after(this.cursor)), this.stringsElement) {
                        this.strings = [], this.stringsElement.hide(), console.log(this.stringsElement.children());
                        var i = this.stringsElement.children();
                        t.each(i, function (i, n) {
                            e.strings.push(t(n).html())
                        })
                    }
                    this.init()
                },
                typewrite: function (t, e) {
                    if (!0 !== this.stop) {
                        var i = Math.round(70 * Math.random()) + this.typeSpeed,
                            n = this;
                        n.timeout = setTimeout(function () {
                            var i = 0,
                                o = t.substr(e);
                            if ("^" === o.charAt(0)) {
                                var a = 1;
                                /^\^\d+/.test(o) && (o = /\d+/.exec(o)[0], a += o.length, i = parseInt(o)), t = t.substring(0, e) + t.substring(e + a)
                            }
                            if ("html" === n.contentType) {
                                var r = t.substr(e).charAt(0);
                                if ("<" === r || "&" === r) {
                                    var s = "",
                                        d = "";
                                    for (d = "<" === r ? ">" : ";"; t.substr(e + 1).charAt(0) !== d && (s += t.substr(e).charAt(0), !(++e + 1 > t.length)););
                                    e++ , s += d
                                }
                            }
                            n.timeout = setTimeout(function () {
                                if (e === t.length) {
                                    if (n.options.onStringTyped(n.arrayPos), n.arrayPos === n.strings.length - 1 && (n.options.callback(), n.curLoop++ , !1 === n.loop || n.curLoop === n.loopCount)) return;
                                    n.timeout = setTimeout(function () {
                                        n.backspace(t, e)
                                    }, n.backDelay)
                                } else {
                                    0 === e && n.options.preStringTyped(n.arrayPos);
                                    var i = t.substr(0, e + 1);
                                    n.attr ? n.el.attr(n.attr, i) : n.isInput ? n.el.val(i) : "html" === n.contentType ? n.el.html(i) : n.el.text(i), e++ , n.typewrite(t, e)
                                }
                            }, i)
                        }, i)
                    }
                },
                backspace: function (t, e) {
                    if (!0 !== this.stop) {
                        var i = Math.round(70 * Math.random()) + this.backSpeed,
                            n = this;
                        n.timeout = setTimeout(function () {
                            if ("html" === n.contentType && ">" === t.substr(e).charAt(0)) {
                                for (var i = "";
                                    "<" !== t.substr(e - 1).charAt(0) && (i -= t.substr(e).charAt(0), !(0 > --e)););
                                e-- , i += "<"
                            }
                            var o = t.substr(0, e);
                            n.attr ? n.el.attr(n.attr, o) : n.isInput ? n.el.val(o) : "html" === n.contentType ? n.el.html(o) : n.el.text(o), e > n.stopNum ? (e-- , n.backspace(t, e)) : e <= n.stopNum && (n.arrayPos++ , n.arrayPos === n.strings.length ? (n.arrayPos = 0, n.shuffle && (n.sequence = n.shuffleArray(n.sequence)), n.init()) : n.typewrite(n.strings[n.sequence[n.arrayPos]], e))
                        }, i)
                    }
                },
                shuffleArray: function (t) {
                    var e, i, n = t.length;
                    if (n)
                        for (; --n;) i = Math.floor(Math.random() * (n + 1)), e = t[i], t[i] = t[n], t[n] = e;
                    return t
                },
                reset: function () {
                    var t = this;
                    clearInterval(t.timeout), this.el.attr("id"), this.el.empty(), void 0 !== this.cursor && this.cursor.remove(), this.strPos = 0, this.arrayPos = 0, this.curLoop = 0, this.options.resetCallback()
                }
            }, t.fn.typed = function (n) {
                return this.each(function () {
                    var o = t(this),
                        a = o.data("typed"),
                        r = "object" == (void 0 === n ? "undefined" : i(n)) && n;
                    a && a.reset(), o.data("typed", a = new e(this, r)), "string" == typeof n && a[n]()
                })
            }, t.fn.typed.defaults = {
                strings: ["These are the default values...", "You know what you should do?", "Use your own!", "Have a great day!"],
                stringsElement: null,
                typeSpeed: 0,
                startDelay: 0,
                backSpeed: 0,
                shuffle: !1,
                backDelay: 500,
                loop: !1,
                loopCount: !1,
                showCursor: !0,
                cursorChar: "|",
                attr: null,
                contentType: "html",
                callback: function () { },
                preStringTyped: function () { },
                onStringTyped: function () { },
                resetCallback: function () { }
            }
        }(window.jQuery)
    },
    function (t, e, i) {
        i(1), i(2), i(4), t.exports = i(3)
    }
]);