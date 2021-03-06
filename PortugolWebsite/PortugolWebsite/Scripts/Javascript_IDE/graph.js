var Graph = function (r){
    this.nodes = [];
    this.lines = [];
    this.r = r;
    self = this;
};

Graph.prototype.add = function (nodev){
    if (this.root === undefined) {
        this.root = nodev;
    }else{
        this.lines.push(new Connection(this.r, this.nodes[this.nodes.length-1], nodev));
    }
    this.nodes.push(nodev);

    for (var i = 0; i < this.nodes.length; i++) {
        this.nodes[i].shape.drag(this.move,this.dragger, this.up);
    };


    //console.log(nodev);

    if (nodev.node.type == 3) {
          nodev.shape.dblclick(function (){
          var t = prompt('Inserir dados:','');
          if(t === undefined || t === null || t.length === 0){
            t = 'Click me';
          }
          nodev.node.data = t;
          nodev.shape[1].attr({
              text: t
          });
       });
    };

};

var self = {};

Graph.prototype.dragger = function (){
    if(this.type == 'circle' || this.type == 'ellipse'){
        this.ox = this.attr('cx');
        this.oy = this.attr('cy');
        this.animate({opacity: .5});
    }else if(this.type == 'rect'){
        this.ox = this.attr("x");
        this.oy = this.attr("y");
        this.animate({opacity:.5});
    }
};


Graph.prototype.move = function (dx, dy){
    if(this.type == 'circle' || this.type == 'ellipse'){
        //para mover a forma se for um circle ou um ellipse
        this.attr({
            cx: this.ox + dx,
            cy: this.oy + dy
        });
        for (var i = 0; i < self.nodes.length; i++) {
            if(self.nodes[i].shape[0].type == 'circle' || self.nodes[i].shape[0].type == 'ellipse'){
                //para mover a label com o texto da forma que se esta a fazer o drag
                self.nodes[i].shape[1].attr({
                    x: self.nodes[i].shape[0].attr('cx'),
                    y: self.nodes[i].shape[0].attr('cy')
                });
            }
        };
    }else if (this.type == 'rect') {
        //para mover a forma se for um rect
        this.attr({
            x: this.ox + dx,
            y: this.oy + dy
        });
        for (var i = 0; i < self.nodes.length; i++) {
            if(self.nodes[i].shape[0].type == 'rect'){
                //para mover a label com o texto da forma que se esta a fazer o drag
                self.nodes[i].shape[1].attr({
                    x: (self.nodes[i].shape[0].attr('x') + (self.nodes[i].shape[0].attr('width')/2)),
                    y: (self.nodes[i].shape[0].attr('y') + (self.nodes[i].shape[0].attr('height')/2))
                });
            }
            
        };
    }
    //refazer as connection para as formas que foram movidas
    for (var i = self.lines.length; i--;) {
        self.r.connection(self.lines[i].shape);
    };
};


Graph.prototype.up = function (){
    if(this.type == 'circle'){
        this.animate({opacity: .5});
    }else if(this.type == 'rect'){
        this.animate({opacity:.5});
    };
}

/*
*   Metodo que retorna a estrutura do fluxograma em JSON
*   para ser enviado para o Core
*/
Graph.prototype.extract = function (){
    //console.log("EXTRACT");
    //console.log(this.root.node);
    return this.root.node;
};
