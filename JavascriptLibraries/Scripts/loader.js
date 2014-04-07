; (function ($, window, document, undefined) {

    // Create the defaults once
    var pluginName = "loader",
        dataPlugin = "plugin_" + pluginName,
        defaults = {
            updateTo: 60,
            updateBy: 10,
            updateEvery: 250,       // milliseconds
            url: '',
            loadComplete: function(element, response, status, xhr) {
                if (status == "error") {
                    $(element).html('<em>Error loading page: ' + xhr.status + ' ' + xhr.statusText + '</em>');
                }
            }
        };

    // The actual plugin constructor
    function Plugin(element, options) {
        this.element = element;
        
        this.options = $.extend({}, defaults, options);

        this._defaults = defaults;
        this._name = pluginName;

        this._html = '<div class="loader-progress"><div class="loader-progress-bar" style="width:0%"></div></div>';
        this._progressBar = null;
        this._currentValue = 0;
        this._worker = null;
        this._progressUpperLimit = 100;

        this.init();
    }

    Plugin.prototype = {
        init: function () {
            this.reload();
        },
        reload: function () {
            
            if (this.options.url === '') {
                return;
            }

            var $el = $(this.element);
            
            this._completeWork();
            this._currentValue = 0;
            
            this._progressBar = $(this._html);
            this._progressBar.css('width', $el.css('width'));
            
            this._createWorker();
            
            var that = this;

            $el
				.before(this._progressBar)
				.load(this.options.url, function (response, status, xhr) {
				    that._completeWork();
				    if (that.options.loadComplete) {
				        that.options.loadComplete(that.element, response, status, xhr);
				    }
				});
        },
        _createWorker: function () {
            this._destroyWorker();
            var that = this;
			this._worker = setInterval(function() {
			    if (that._currentValue >= that.options.updateTo) {
			        that._destroyWorker();
			        return;
			    }
			    that._currentValue += that.options.updateBy;
			    that._performWork(that._currentValue);
			}, this.options.updateEvery);
        },
        _destroyWorker: function() {
            clearInterval(this._worker);
        },
        _performWork: function(value) {
            if (value > this._progressUpperLimit) {
                return;
            }
            this._progressBar
                .children()
                .css('width', value + '%');
        },
        _completeWork: function () {
            if (this._progressBar == null) {
                return;
            }
            this._destroyWorker();
            this._performWork(this._progressUpperLimit);
            var that = this;
            setTimeout(function() {
                that._progressBar
                    .empty()
                    .remove();
                that._progressBar = null;
            }, 450);
        }
    };

    $.fn[pluginName] = function (options) {
        var args = arguments;

        if (options === undefined || typeof options === 'object') {
            return this.each(function () {
                if (!$.data(this, dataPlugin)) {
                    var opts = options === undefined ? $(this).data() : options;
                    $.data(this, dataPlugin, new Plugin(this, opts));
                }
            });
        } else if (typeof options === 'string' && options[0] !== '_' && options !== 'init') {
            var returns;

            this.each(function () {
                var instance = $.data(this, dataPlugin);
                if (instance instanceof Plugin && typeof instance[options] === 'function') {
                    returns = instance[options].apply(instance, Array.prototype.slice.call(args, 1));
                }

                if (options === 'destroy') {
                    $.data(this, dataPlugin, null);
                }
            });

            return returns !== undefined ? returns : this;
        }
    };

})(jQuery, window, document);

$(document).ready(function() {
    $('[data-toggle="loader"]').loader();
});
